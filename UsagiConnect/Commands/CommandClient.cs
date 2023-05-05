using log4net;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using UsagiConnect.Commands.TwitchCommands;
using UsagiConnect.Osu.Beatmap;
using UsagiConnect.Osu.Enums;
using UsagiConnect.Osu.Exceptions;
using UsagiConnect.Osu.User;
using UsagiConnect.WForms;

namespace UsagiConnect.Commands
{
    public class CommandClient
    {
        public User OsuUser;
        public string TwitchUser;
        public static string ModString;
        public static string channel = MainForm.Config.TwitchChannel;
        private static readonly ILog Log = LogManager.GetLogger(typeof(CommandClient).Name);
        private string prefix = MainForm.Config.Prefix;
        private static Beatmap beatmap;
        public List<Command> commands;
        private readonly Dictionary<string, int> commandIndex;

        public CommandClient(TwitchClient Client)
        {
            Client.OnMessageReceived += OnChannelMessage;
            commands = new List<Command>();
            commandIndex = new Dictionary<string, int>();
            GetOsuUser();
        }

        // Gets the local osu user
        private async void GetOsuUser()
        {
            OsuUser = await MainForm.OsuClient.GetUser(MainForm.Config.BanchoUsername, Gamemode.Osu);
        }

        // Adds the commands to the command index
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

        // Send a message inside of one twitch channel
        public void SendMessage(string message)
        {
            MainForm.TwiClient.GetTwitchClient().SendMessage(channel, message);
        }

        // Parse incoming Beatmaps
        public static string ParseMessage(string message)
        {
            string delimiters = "https?:\\/\\/osu.ppy.sh\\/(beatmapsets)\\/([0-9]*)(#osu|#taiko|#ctb|#mania)\\/([0-9]*)";
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
                    MainForm.TwiClient.GetTwitchClient().SendMessage(channel, "Invalid Beatmap Sent. Please check your url.");
                    throw new BeatmapNotFoundException("Beatmap not found");
            }
        }

        // Receive incoming Beatmaps
        public static async void ReceiveBeatmap(string beatmapToReceive)
        {
            try
            {
                if (RequestToggleCommand.RequestToggle)
                {
                    Log.Info("Received possible osu song request. Parsing now...");
                    beatmap = await MainForm.OsuClient.GetBeatmap(ParseMessage(beatmapToReceive));
                    Log.Info("Beatmap ID Found: " + beatmap.Id);
                    if (beatmapToReceive.Contains("+"))
                    {
                        string[] splitter = beatmapToReceive.Split('+');
                        string mods = splitter[1];
                        Log.Info("Attached Mods: " + mods);
                        if (beatmap.DifficultyRating > MainForm.Config.OsuStarLimit)
                        {
                            MainForm.TwiClient.GetTwitchClient().SendMessage(channel, MainForm.Config.OsuStarLimitMessage);
                        }
                        else
                        {
                            Log.Info(await MainForm.Config.GetApiParsedMessage(MainForm.Config.TwitchMessage, beatmap));
                            string message = await MainForm.Config.GetApiParsedMessage(MainForm.Config.TwitchMessage, beatmap);
                            MainForm.TwiClient.GetTwitchClient().SendMessage(channel, message);
                        }
                    }
                    else
                    {
                        if (beatmap.DifficultyRating > MainForm.Config.OsuStarLimit)
                        {
                            MainForm.TwiClient.GetTwitchClient().SendMessage(channel, MainForm.Config.OsuStarLimitMessage);
                        }
                        else
                        {
                            Log.Info(await MainForm.Config.GetApiParsedMessage(MainForm.Config.TwitchMessage, beatmap));
                            string message = await MainForm.Config.GetApiParsedMessage(MainForm.Config.TwitchMessage, beatmap);
                            MainForm.TwiClient.GetTwitchClient().SendMessage(channel, message);
                        }
                    }
                }
                else
                {
                    MainForm.TwiClient.GetTwitchClient().SendMessage(channel, "You cannot send a beatmap at this time");
                }
            }
            catch (BeatmapNotFoundException)
            {
                Log.Error("Invalid Beatmap.");
            }
        }

        // Receives all of Twitch Chat Messages.
        public void OnChannelMessage(object sender, OnMessageReceivedArgs e)
        {
            TwitchUser = e.ChatMessage.Username;
            string[] parts = null;
            string message = e.ChatMessage.Message;
            message = Regex.Replace(message, @"\p{C}+", string.Empty); // Added this to remove a random unicode character that shows up. Why is it there???
            string prefix = MainForm.Config.Prefix;

            // Parse incoming beatmap requests
            if (message.Contains("https://osu.ppy.sh/"))
            {
                ReceiveBeatmap(message);
            }

            if (parts == null & message.StartsWith(prefix))
                parts = message.Substring(prefix.Length).Trim().Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);

            // Parse incoming commands and running them
            if (parts != null)
            {
                string name = parts[0];
                string[] args;

                if (parts != null && parts.Length > 1)
                {
                    args = parts[1]?.Split(' ') ?? new string[0];
                }
                else
                {
                    args = Array.Empty<string>();
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