using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using UsagiConnect.Osu.API.Enums;

namespace UsagiConnect.Osu.API.Beatmap
{

    /// <summary>
    /// Follows the osu!web documentation of BeatmapCompact (As of February 21st, 2023)
    /// Description: Represent a beatmap.
    /// URL:         https://osu.ppy.sh/docs/index.html#beatmapcompact
    /// </summary>

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

        [Description("Optional Attributes")]
        [JsonProperty("beatmapset")]
        public Beatmapset Beatmapset { get; set; }

        [JsonProperty("checksum")]
        public string Checksum { get; set; }

        [JsonProperty("failtimes")]
        public FailTimes FailTimes { get; set; }

        [JsonProperty("max_combo")]
        public int MaxCombo { get; set; }
    }

    /// <summary>
    /// Follows the osu!web documentation of FailTimes (As of February 21st, 2023)
    /// Description: All fields are optional but there's always at least one field returned.
    /// URL:         https://osu.ppy.sh/docs/index.html#beatmapcompact-failtimes
    /// </summary>

    public class FailTimes
    {
        #region Failtimes
        [JsonProperty("fail")]
        public IEnumerable<int> Fail { get; set; }

        [JsonProperty("exit")]
        public IEnumerable<int> Exit { get; set; }
        #endregion
    }
}
