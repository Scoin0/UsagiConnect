using log4net;
using System;
using System.Linq;

namespace UsagiConnect.Commands
{
    public abstract class Command
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Command).Name);
        protected string Name { get; set; } = string.Empty;
        protected string Description { get; set; } = string.Empty;
        protected string[] Aliases { get; set; } = new string[0];
        protected Command[] SubCommands { get; set; } = new Command[0];

        public abstract void OnCommand(CommandEvent pevent);

        public void Run(CommandEvent pevent)
        {
            if (pevent.args.Length > 0) 
            {
                string[] args = pevent.args;

                foreach (Command command in SubCommands)
                {
                    if (command.IsCommandFor(args[0]))
                    {
                        pevent.args = args.Length > 1 ? new ArraySegment<string>(args, 1, args.Length - 1).ToArray() : new string[0];
                        command.Run(pevent);
                    }
                }
            }

            try 
            {
                OnCommand(pevent);
            }
            catch (Exception e)
            {
                Log.Warn(e.Message);
            }
        }

        public bool IsCommandFor(string input)
        {
            if (Name.Equals(input)) return true;

            foreach (string alias in Aliases) 
                if (alias.Equals(input)) return true;

            return false;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetDescription()
        {
            return Description;
        }

        public string[] GetAliases()
        {
            return Aliases;
        }

        public Command[] GetSubCommands()
        {
            return SubCommands;
        }
    }
}