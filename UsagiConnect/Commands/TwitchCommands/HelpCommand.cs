using System;
using System.Linq;

namespace UsagiConnect.Commands.TwitchCommands
{
    public class HelpCommand : Command
    {
        public HelpCommand()
        {
            Name = "help";
            Description = "Sends a link to the command wiki page.";
            Usage.Add("help");
            Usage.Add("help <command>");
            Aliases = new string[] { "commands" };
        }

        public override void OnCommand(CommandEvent pevent)
        {
            if (pevent.GetArgs().Length == 0)
            {
                SendHelp(pevent);
            }
            else
            {
                SendCommandHelp(pevent, pevent.GetArgs()[0]);
            }
        }

        private void SendHelp(CommandEvent pevent)
        {
            pevent.GetClient().SendMessage("All Commands: https://github.com/Scoin0/UsagiBot/wiki/Commands");
        }

        private void SendCommandHelp(CommandEvent pevent, string commandName)
        {
            bool isCommandFound = false;
            bool isAliasCommandFound = false;

            Command command = pevent.GetClient().commands.FirstOrDefault(c => c.GetName().Equals(commandName, StringComparison.OrdinalIgnoreCase));
            Command aliasCommand = pevent.GetClient().commands.FirstOrDefault(c => c.IsCommandFor(commandName));

            if (command != null)
            {
                isCommandFound = !command.GetName().Equals("unassigned", StringComparison.OrdinalIgnoreCase);
            }

            if (aliasCommand != null)
            {
                isAliasCommandFound = !aliasCommand.GetName().Equals("unassigned", StringComparison.OrdinalIgnoreCase);
            }

            if (isCommandFound)
            {
                string usageList = string.Join(", ", command.GetUsages());
                pevent.GetClient().SendMessage($"{command.GetDescription()} | Usage: {usageList}");
            }
            else if (isAliasCommandFound)
            {
                string usageList = string.Join(", ", aliasCommand.GetUsages());
                pevent.GetClient().SendMessage($"{aliasCommand.GetDescription()} | Usage: {usageList}");
            }
            else
            {
                pevent.GetClient().SendMessage("Command not found or does not exist.");
            }
        }
    }
}