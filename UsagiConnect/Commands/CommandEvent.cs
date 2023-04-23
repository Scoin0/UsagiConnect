using log4net;
using TwitchLib.Client.Models;

namespace UsagiConnect.Commands
{
    public class CommandEvent
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(CommandEvent).Name);
        private ChatMessage pevent { get; }
        public string[] args { get; set; }
        private CommandClient client { get; }

        public CommandEvent(ChatMessage pevent, string[] args, CommandClient client)
        {
            this.pevent = pevent;
            this.args = args;
            this.client = client;
        }

        public string[] GetArgs()
        {
            return args;
        }

        public CommandClient GetClient()
        {
            return client;
        }
    }
}