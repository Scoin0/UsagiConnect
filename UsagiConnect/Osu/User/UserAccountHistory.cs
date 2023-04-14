using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsagiConnect.Osu.User
{
    public class UserAccountHistory
    {
#nullable enable
        [JsonProperty("description")]
        public string? Description { get; set; }
#nullable disable

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("length")]
        public int Length { get; set; }

        [JsonProperty("permanent")]
        public bool Permanent { get; set; }

        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}