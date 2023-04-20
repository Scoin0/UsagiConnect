using Newtonsoft.Json;

namespace UsagiConnect.Osu.User
{
    public class Level
    {
        [JsonProperty("current")]
        public int Current { get; set; }
        [JsonProperty("progress")]
        public int Progress { get; set; }
    }
}
