using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using UsagiConnect.Osu.API.Beatmap.Enums;

namespace UsagiConnect.Osu.API.Beatmap
{

    /// <summary>
    /// Follows the osu!web documentation of Beatmap (As of February 21st, 2023)
    /// Description: Represents a beatmap.
    /// URL:         https://osu.ppy.sh/docs/index.html#beatmap
    /// </summary>

    public class Beatmap : BeatmapCompact
    {
        [JsonProperty("accuracy")]
        public double Accuracy { get; set; }

        [JsonProperty("ar")]
        public double AR { get; set; }

        [JsonProperty("bpm")]
        public double BPM { get; set; }

        [JsonProperty("convert")]
        public bool IsConverted { get; set; }

        [JsonProperty("count_circles")]
        public int CountCircles { get; set; }

        [JsonProperty("count_sliders")]
        public int CountSliders { get; set; }

        [JsonProperty("count_spinners")]
        public int CountSpinners { get; set; }

        [JsonProperty("cs")]
        public double CS { get; set; }

        [JsonProperty("deleted_at")]
        public DateTimeOffset? DeletedAt { get; set; }

        [JsonProperty("drain")]
        public double Drain { get; set; }

        [JsonProperty("hit_length")]
        public int HitLength { get; set; }

        [JsonProperty("is_scorable")]
        public bool IsScoreable { get; set; }

        [JsonProperty("last_updated")]
        public DateTimeOffset LastUpdated { get; set; }

        [JsonProperty("mode_int")]
        public int ModeInt { get; set; }

        [JsonProperty("ranked")]
        public RankStatus Ranked { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}