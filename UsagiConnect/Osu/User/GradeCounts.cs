﻿using Newtonsoft.Json;

namespace UsagiConnect.Osu.User
{
    public class GradeCounts
    {
        [JsonProperty("a")]
        public int A { get; set; }
        [JsonProperty("s")]
        public int S { get; set; }
        [JsonProperty("sh")]
        public int SH { get; set; }
        [JsonProperty("ss")]
        public int SS { get; set; }
        [JsonProperty("ssh")]
        public int SSH { get; set; }
    }
}
