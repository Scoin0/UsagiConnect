using Newtonsoft.Json;
using System.ComponentModel;
using UsagiConnect.Osu.API.Enums;
using UsagiConnect.Osu.Beatmap;

namespace UsagiConnect.Osu.API.Beatmap
{
    public class BeatmapCompact
    {
        [JsonProperty("beatmapset_id")]
        public int BeatmapsetId { get; set; }

        [JsonProperty("difficulty_rating")]
        public double DifficultyRating { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("mode")]
        public Gamemode Mode { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("total_length")]
        public int TotalLength { get; set; }

        [JsonProperty("user_id")]
        public int UserId { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("beatmapset")]
        public Beatmapset Beatmapset { get; set; }

        [JsonProperty("checksum")]
        public string Checksum { get; set; }

        [JsonProperty("failtimes")]
        public FailTimes FailTimes { get; set; }

        [JsonProperty("max_combo")]
        public int MaxCombo { get; set; }
    }
}