using TwitchLib.Client.Models;

namespace UsagiConnect.Commands
{
    public class CommandEvent
    {
        public ChatMessage pevent { get; }
        public string[] args { get; set; }
        public CommandClient client { get; }

        public CommandEvent(ChatMessage pevent, string[] args, CommandClient client)
        {
            this.pevent = pevent;
            this.args = args;
            this.client = client;
        }
    }
}