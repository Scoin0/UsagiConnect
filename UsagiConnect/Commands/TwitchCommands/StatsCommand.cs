using log4net;
using System.Globalization;
using System.Text;
using UsagiConnect.Osu.User;

namespace UsagiConnect.Commands.TwitchCommands
{
    public class StatsCommand : Command
    {
        public StatsCommand()
        {
            Name = "stats";
            Description = "Sends streamers osu stats.";
            Usage.Add("stats");
            Usage.Add("stats <user>");
        }

        public override void OnCommand(CommandEvent pevent)
        {
            if(pevent.GetArgs().Length == 0)
            {
                pevent.GetClient().SendMessage(GetStats(user: pevent.GetClient().user));
            }

            if(pevent.GetArgs().Length >= 1)
            {
            }
        }
        
        public string GetStats(User user)
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
}
