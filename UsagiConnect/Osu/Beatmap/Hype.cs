using Newtonsoft.Json;

namespace UsagiConnect.Osu.Beatmap
{
    public class Hype
    {
        [JsonProperty("current")]
        public int Current { get; set; }

        [JsonProperty("required")]
        public int Required { get; set; }
    }
}