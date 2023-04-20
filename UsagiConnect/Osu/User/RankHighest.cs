using Newtonsoft.Json;
using System;

namespace UsagiConnect.Osu.User
{
    public class RankHighest
    {
        [JsonProperty("rank")]
        public int Rank { get; set; }
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}