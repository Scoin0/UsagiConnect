using log4net;
using System;
using UsagiConnect.WForms;

namespace UsagiConnect.Commands.TwitchCommands
{
    public class StarLimitCommand : Command
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(StarLimitCommand).Name);
        public StarLimitCommand()
        {
            Name = "starlimit";
            Description = "Set the star limit";
            Usage.Add("sl <number>");
            Usage.Add("starlimit <number>");
            Aliases = new String[] { "sl" };
        }

        public override void OnCommand(CommandEvent @event)
        {
            if (@event.GetArgs().Length == 0)
            {
                @event.GetClient().SendMessage($"The current star limit is: {MainForm.Config.OsuStarLimit}");
            }

            if (@event.GetArgs().Length == 1)
            {
                if (@event.GetClient().TwitchUser == MainForm.Config.TwitchChannel)
                {
                    try
                    {
                        double newStarLimit = double.Parse(@event.GetArgs()[0]);
                        if (newStarLimit <= 0 || newStarLimit >= 13)
                        {
                            @event.GetClient().SendMessage("Please enter a number between 0.1 and 12.99.");
                        }
                        else
                        {
                            @event.GetClient().SendMessage($"The star limit has been changed to: {newStarLimit}!");
                            Log.Info($"The star limit has been changed to: {newStarLimit}!");
                            MainForm.Config.OsuStarLimit = newStarLimit;
                            MainForm.Config.SaveConfiguration();
                        }
                    }
                    catch (Exception)
                    {
                        @event.GetClient().SendMessage("You've sent something other than a number.");
                    }
                }
                else
                {
                    @event.GetClient().SendMessage($"The current star limit is: {MainForm.Config.OsuStarLimit}");
                }
            }
        }
    }
}