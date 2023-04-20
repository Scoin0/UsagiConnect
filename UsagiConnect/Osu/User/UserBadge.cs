using Newtonsoft.Json;
using System;

namespace UsagiConnect.Osu.User
{
    public class UserBadge
    {
        [JsonProperty("awarded_at")]
        public DateTimeOffset AwardedAt { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("image_url")]
        public int ImageUrl { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}