using log4net;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using UsagiConnect.Osu.Beatmap;
using UsagiConnect.Osu.Enums;
using UsagiConnect.Osu.Exceptions;
using UsagiConnect.Osu.User;
using UsagiConnect.WForms;

namespace UsagiConnect.Commands
{
    public class CommandClient
    {
        public User user;
        private static readonly ILog Log = LogManager.GetLogger(typeof(CommandClient).Name);
        private string prefix = MainForm.Config.Prefix;
        private static string channel = MainForm.Config.TwitchChannel;
        private static Beatmap beatmap;
        private readonly List<Command> commands;
        private readonly Dictionary<string, int> commandIndex;

        public CommandClient(TwitchClient client)
        {
            client.OnMessageReceived += OnChannelMessage;
            commands = new List<Command>();
            commandIndex = new Dictionary<string, int>();
            GetUser();
        }

        private async void GetUser()
        {
            user = await MainForm.OsuClient.GetUser(MainForm.Config.BanchoUsername, Gamemode.Osu);
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

        public void SendMessage(string message)
        {
            MainForm.TwiClient.GetTwitchClient().SendMessage(channel, message);
        }

        public static string ParseMessage(string message)
        {
            string delimiters = "https?:\\/\\/osu.ppy.sh\\/(beatmapsets)\\/([0-9]*)(#osu|#taiko|#ctb|#maina)\\/([0-9]*)";
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
            string[] parts = null;
            string message = e.ChatMessage.Message;
            message = Regex.Replace(message, @"\p{C}+", string.Empty); // Add this to remove a random unicode character that shows up. Why is it there???
            string prefix = MainForm.Config.Prefix;

            if (message.Contains("https://osu.ppy.sh/"))
            {
                ReceiveBeatmap(message);
            }

            if (parts == null & message.StartsWith(prefix))
                parts = message.Substring(prefix.Length).Trim().Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);

            if (parts != null)
            {
                string name = parts[0];
                string[] args = null;

                if (parts != null && parts.Length > 1)
                {
                    args = parts[1]?.Split(' ') ?? new string[0];
                    Log.Info(parts.Length);
                }
                else
                {
                    args = Array.Empty<string>();
                    Log.Info(parts.Length);
                }

                Command command;
                lock (commandIndex)
                {
                    int i = commandIndex.TryGetValue(name.ToLower(), out int value) ? value : -1;
                    command = i != -1 ? commands[i] : null;
                }

                if (command != null)
                {
                    CommandEvent commandEvent = new CommandEvent(e.ChatMessage, args, this);
                    Log.Info($"Sending { commandEvent.GetClient().prefix }{ command.GetName() } command in #{ e.ChatMessage.Channel }");
                    command.Run(commandEvent);
                    return;
                }
            }
        }
    }
}