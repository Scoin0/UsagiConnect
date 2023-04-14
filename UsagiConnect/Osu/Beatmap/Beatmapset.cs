using Newtonsoft.Json;
using System;
using UsagiConnect.Osu.API.Beatmap.Enums;

namespace UsagiConnect.Osu.API.Beatmap
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

    public class Availability
    {
        #region Availability
        [JsonProperty("download_disabled")]
        public bool IsDownloadDisabled { get; set; }

        [JsonProperty("more_information")]
        public string MoreInformation { get; set; }
        #endregion
    }

    public class Nominations
    {
        #region Nominations
        [JsonProperty("current")]
        public int Current { get; set; }

        [JsonProperty("required")]
        public int Required { get; set; }
        #endregion
    }

    public class Hype
    {
        #region Hype
        [JsonProperty("current")]
        public int Current { get; set; }

        [JsonProperty("required")]
        public int Required { get; set; }
        #endregion
    }

    public class Covers
    {
        #region Covers
        [JsonProperty("cover")]
        public string Cover { get; set; }

        [JsonProperty("cover@2x")]
        public string Cover2X { get; set; }

        [JsonProperty("card")]
        public string Card { get; set; }

        [JsonProperty("card@2x")]
        public string Card2X { get; set; }

        [JsonProperty("list")]
        public string List { get; set; }

        [JsonProperty("list@2x")]
        public string List2X { get; set; }

        [JsonProperty("slimcover")]
        public string Slimcover { get; set; }

        [JsonProperty("slimcover@2x")]
        public string Slimcover2X { get; set; }
        #endregion
    }
}