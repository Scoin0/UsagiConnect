using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsagiConnect.Commands.TwitchCommands
{
    public class NowPlayingCommand : Command
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(NowPlayingCommand).Name);
        public NowPlayingCommand()
        {
            Name = "nowplaying";
            Description = "Sends the currently playing map to twitch chat.";
            Usage.Add("np");
            Usage.Add("nowplaying");
            Aliases = new string[] { "np" };
        }

        public override void OnCommand(CommandEvent pevent)
        {
            Log.Info("Testing.");
        }
    }
}
