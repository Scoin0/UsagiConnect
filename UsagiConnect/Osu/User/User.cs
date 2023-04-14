using Newtonsoft.Json;
using System;
using UsagiConnect.Osu.Enums;

namespace UsagiConnect.Osu.User
{
    public class User : UserCompact
    {
        [JsonProperty("discord")]
        public string Discord { get; set; }

        [JsonProperty("has_supported")]
        public bool HasSupported { get; set; }

#nullable enable
        [JsonProperty("interests")]
        public string? Intrests { get; set; }

        [JsonProperty("join_date")]
        public DateTimeOffset JoinDate { get; set; }
#nullable enable
        [JsonProperty("location")]
        public string? Location { get; set; }
#nullable disable

        [JsonProperty("max_blocks")]
        public int MaxBlocks { get; set; }

        [JsonProperty("max_friends")]
        public int MaxFriends { get; set; }

#nullable enable
        [JsonProperty("occupation")]
        public string? Occupation { get; set; }
#nullable disable

        [JsonProperty("playmode")]
        public Gamemode PlayMode { get; set; }

        [JsonProperty("playstyle")]
        public string[] PlayStyle { get; set; }

        [JsonProperty("post_count")]
        public int PostCount { get; set; }
    }
}