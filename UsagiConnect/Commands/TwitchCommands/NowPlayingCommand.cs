using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsagiConnect.Commands.TwitchCommands
{
    public class NowPlayingCommand : Command
    {
        public NowPlayingCommand()
        {
            Name = "nowplaying";
            Description = "Sends the currently playing map to twitch chat.";
            Aliases = new string[] { "np" };
        }

        public override void OnCommand(CommandEvent pevent)
        {
            throw new NotImplementedException();
        }
    }
}
