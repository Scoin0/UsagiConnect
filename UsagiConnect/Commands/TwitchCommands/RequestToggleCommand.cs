using System;
using UsagiConnect.WForms;

namespace UsagiConnect.Commands.TwitchCommands
{
    public class RequestToggleCommand : Command
    {
        public static bool RequestToggle = true;

        public RequestToggleCommand()
        {
            Name = "requesttoggle";
            Description = "Turns on/off the requesting feature (Default = on)";
            Aliases = new string[] { "rq" };
            Usage.Add("rq");
            Usage.Add("rq toggle");
            Usage.Add("rq on|off");
        }

        public override void OnCommand(CommandEvent @event)
        {
            if (@event.GetArgs().Length == 0)
            {
                @event.GetClient().SendMessage($"The current status of requesting beatmaps is: {RequestToggle}");
            }
            else if (@event.GetClient().TwitchUser.Equals(MainForm.Config.TwitchChannel, StringComparison.OrdinalIgnoreCase))
            {
                if (@event.GetArgs()[0].Equals("toggle", StringComparison.OrdinalIgnoreCase))
                {
                    RequestToggle = !RequestToggle;
                    @event.GetClient().SendMessage($"The current status of requesting beatmaps is: {RequestToggle}");
                }
                if (@event.GetArgs()[0].Equals("on", StringComparison.OrdinalIgnoreCase))
                {
                    RequestToggle = true;
                    @event.GetClient().SendMessage($"The current status of requesting beatmaps is: {RequestToggle}");
                }
                if (@event.GetArgs()[0].Equals("off", StringComparison.OrdinalIgnoreCase))
                {
                    RequestToggle = false;
                    @event.GetClient().SendMessage($"The current status of requesting beatmaps is: {RequestToggle}");
                }
            }
            else
            {
                @event.GetClient().SendMessage($"The current status of requesting beatmaps is: {RequestToggle}");
            }
        }
    }
}