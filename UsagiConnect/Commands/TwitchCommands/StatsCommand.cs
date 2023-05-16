using log4net;
using System;
using System.Globalization;
using System.Text;
using UsagiConnect.Osu.Enums;
using UsagiConnect.Osu.User;
using UsagiConnect.WForms;

namespace UsagiConnect.Commands.TwitchCommands
{
    public class StatsCommand : Command
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(StatsCommand).Name);
        public StatsCommand()
        {
            Name = "stats";
            Description = "Sends streamers osu stats.";
            Usage.Add("stats");
            Usage.Add("stats <user>");
            Usage.Add("stats <user> <gamemode>");
        }

        public override void OnCommand(CommandEvent @event)
        {
            try
            {
                if (@event.GetArgs().Length == 0)
                {
                    @event.GetClient().SendMessage(GetStats(user: @event.GetClient().OsuUser));
                }
                if (@event.GetArgs().Length == 1)
                {
                    if (CheckIfArgIsAGamemode(@event.GetArgs()[0]))
                    {
                        Gamemode gamemode = (Gamemode)Enum.Parse(typeof(Gamemode), @event.GetArgs()[0], true);
                        User user = MainForm.OsuClient.GetUser(@event.GetClient().OsuUser.Username, gamemode).Result;
                        @event.GetClient().SendMessage(GetStats(user));
                    }
                    else
                    {
                        User user = MainForm.OsuClient.GetUser(@event.GetArgs()[0], Gamemode.Osu).Result;
                        @event.GetClient().SendMessage(GetStats(user));
                    }
                }
                if (@event.GetArgs().Length == 2)
                {
                    Gamemode gamemode = (Gamemode)Enum.Parse(typeof(Gamemode), @event.GetArgs()[1], true);
                    User user = MainForm.OsuClient.GetUser(@event.GetArgs()[0], gamemode).Result;
                    @event.GetClient().SendMessage(GetStats(user));
                }
                if (@event.GetArgs().Length >= 3)
                {
                    @event.GetClient().SendMessage("There's too many arguments in this command.");
                }
            }
            catch (Exception)
            {
                Log.Error("Either player or gamemode was typed incorrectly.");
            }
        }

        public bool CheckIfArgIsAGamemode(string arg)
        {
            try
            {
                Gamemode gamemode = (Gamemode)Enum.Parse(typeof(Gamemode), arg, true);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string GetStats(User user)
        {
            try
            {
                if (user != null)
                {
                    NumberFormatInfo nf = new CultureInfo("en-US").NumberFormat;
                    StringBuilder stats = new StringBuilder();
                    stats.Append("Stats for " + user.Username + ":");
                    stats.Append($" PP: {user.Statistics.PP.ToString("N0", nf)}");
                    stats.Append($" | Rank: #{user.Statistics.GlobalRank.ToString("N0", nf)}");
                    stats.Append($" | Level: {user.Statistics.Level.Current}");
                    stats.Append($" | Accuracy: {user.Statistics.HitAccuracy.ToString("N02", nf)}%");
                    stats.Append($" | Play Count: {user.Statistics.PlayCount.ToString("N0", nf)}");
                    return stats.ToString();
                }
            }
            catch (Exception)
            {
                Log.Error("Either player or gamemode was typed incorrectly.");
            }
            return null;
        }
    }
}