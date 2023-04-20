using Newtonsoft.Json;
using System;
using UsagiConnect.Osu.Enums;

namespace UsagiConnect.Osu.Beatmap
{
    public class Beatmapset : BeatmapsetCompact
    {
        [JsonProperty("availability")]
        public Availability Availability { get; set; }
        [JsonProperty("bpm")]
        public double BPM { get; set; }
        [JsonProperty("can_be_hyped")]
        public bool Hypeable { get; set; }
        [JsonProperty("discussion_locked")]
        public bool IsDiscussionLocked { get; set; }
        [JsonProperty("hype")]
        public Hype Hype { get; set; }
        [JsonProperty("is_scoreable")]
        public bool IsScoreable { get; set; }
        [JsonProperty("last_updated")]
        public DateTimeOffset LastUpdated { get; set; }
        [JsonProperty("legacy_thread_url")]
        public string LegacyThreadUrl { get; set; }
        [JsonProperty("nominations")]
        public Nominations Nominations { get; set; }
        [JsonProperty("ranked_date")]
        public DateTimeOffset? RankedDate { get; set; }
        [JsonProperty("ranked")]
        public RankStatus Ranked { get; set; }
        [JsonProperty("storyboard")]
        public bool HasStoryboard { get; set; }
        [JsonProperty("submitted_date")]
        public DateTimeOffset SubmittedDate { get; set; }
        [JsonProperty("tags")]
        private string TagsObject
        {
            set => Tags = value.Split(' ');
        }
        public string[] Tags { get; set; }
        [JsonProperty("beatmaps")]
        public Beatmap Beatmaps { get; set; }
    }
}