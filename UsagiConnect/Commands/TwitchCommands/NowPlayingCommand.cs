using log4net;
using System;
using UsagiConnect.Client;
using UsagiConnect.WForms;

namespace UsagiConnect.Commands.TwitchCommands
{
    public class NowPlayingCommand : Command
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(NowPlayingCommand).Name);
        private GOsuMemoryClient gOsuMemory = new GOsuMemoryClient();
        public NowPlayingCommand()
        {
            Name = "nowplaying";
            Description = "Sends the currently playing map to twitch chat.";
            Usage.Add("np");
            Usage.Add("nowplaying");
            Aliases = new string[] { "np" };
        }

        public override void OnCommand(CommandEvent evnt)
        {
            try
            {
                string mods = gOsuMemory.GetModsFromGOsuMemory();

                // If GOsuMemory isn't connected. Just move on.
                if (mods == null)
                    return;

                if (!mods.Contains("NM"))
                {
                    evnt.GetClient().SendMessage(MainForm.Config.GetLocalParsedMessage(MainForm.Config.NowPlayingMessage) + " +" + mods);
                }
                else
                {
                    evnt.GetClient().SendMessage(MainForm.Config.GetLocalParsedMessage(MainForm.Config.NowPlayingMessage));
                }
            }
            catch (Exception)
            {
                Log.Error("Either GOsuMemory is not running or the GOsuMemoryPath is incorrect.\n");
            }
        }
    }
}