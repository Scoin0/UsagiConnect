using Newtonsoft.Json;
using System.Collections.Generic;

namespace UsagiConnect.Osu.Beatmap
{
    public class FailTimes
    {
        [JsonProperty("fail")]
        public IEnumerable<int> Fail { get; set; }

        [JsonProperty("exit")]
        public IEnumerable<int> Exit { get; set; }
    }
}