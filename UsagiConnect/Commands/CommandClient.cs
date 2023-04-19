using UsagiConnect.Osu.Beatmap;
using UsagiConnect.Osu.User;
using UsagiConnect.Osu.Enums;
using UsagiConnect.WForms;
using TwitchLib.Client;
using System.Collections.Generic;
using TwitchLib.Client.Events;
using System;
using log4net;
using UsagiConnect.Client;
using System.Text.RegularExpressions;
using TwitchLib.Client.Models;
using UsagiConnect.Osu.Exceptions;

namespace UsagiConnect.Commands
{
    public class CommandClient
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(CommandClient).Name);
        private string prefix = MainForm.Config.Prefix;
        private static string channel = MainForm.Config.TwitchChannel;
        private static Beatmap beatmap;
        //private User user = async MainForm.OsuClient.GetUser(MainForm.Config.BanchoUsername, mode: Gamemode.Osu);
        private readonly List<Command> commands;
        private readonly Dictionary<string, int> commandIndex;

        public CommandClient(TwitchClient client)
        {
            client.OnMessageReceived += OnChannelMessage;
            commands = new List<Command>();
            commandIndex = new Dictionary<string, int>();
        }

        public void AddCommand(Command command)
        {
            string name = command.GetName();

            lock (commandIndex)
            {
                if (commandIndex.ContainsKey(name))
                {
                    throw new ArgumentException($"The {name} command already has an index!");
                }

                foreach (string alias in command.GetAliases())
                {
                    if (commandIndex.ContainsKey(alias))
                    {
                        throw new ArgumentException($"The {name} command already has an index!");
                    }
                    commandIndex[alias] = commands.Count;
                }
                commandIndex[name] = commands.Count;
            }

            commands.Add(command);
            Log.Info($"Added the command {command.GetName()}");
        }

        public static void SendMessage(string message)
        {
            MainForm.TwiClient.GetTwitchClient().SendMessage(channel, message);
        }

        public static string ParseMessage(string message)
        {
            string delimiters = 
                "https?:\\/\\/osu.ppy.sh\\/(beatmapsets)\\/([0-9]*)(#osu|#taiko|#ctb|#maina)\\/([0-9]*)";
            Regex urlPattern = new Regex(delimiters, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            MatchCollection matcher = urlPattern.Matches(message);
            List<string> urlSplit = new List<string>();

            foreach (Match match in matcher)
            {
                for (int i = 1; i < match.Groups.Count; i++)
                {
                    urlSplit.Add(match.Groups[i].Value);
                }
            }

            switch (urlSplit.Count)
            {
                case 4:
                    string beatmap = urlSplit[3];
                    return beatmap;
                default:
                    throw new BeatmapNotFoundException("Beatmap not found");
            }
        }

        public static async void ReceiveBeatmap(string beatmapToReceive)
        {
            try
            {
                Log.Info("Received possible osu song request. Parsing now...");
                beatmap = await MainForm.OsuClient.GetBeatmap(ParseMessage(beatmapToReceive));
            }
            catch
            {
                Log.Error("Beatmap invalid.");
            }
        }

        public void OnChannelMessage(object sender, OnMessageReceivedArgs e)
        {
            // Don't listen to self.
            if (e.ChatMessage.IsMe) return;

            string[] parts = null;
            string message = e.ChatMessage.Message;

            if (message.Contains("https://osu.ppy.sh/"))
            {
                ReceiveBeatmap(message);
            }
        }
    }
}
