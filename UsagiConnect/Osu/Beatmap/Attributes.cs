using Newtonsoft.Json;

namespace UsagiConnect.Osu.Beatmap
{
    public class Attributes
    {
        // Maps Data

        [JsonProperty("max_combo")]
        public int MaxCombo { get; set; }
        [JsonProperty("star_rating")]
        public float StarRating { get; set; }
        [JsonProperty("approach_rate")]
        public float ApproachRate { get; set; }
        [JsonProperty("great_hit_window")]
        public float GreatHitWindow { get; set; }

        // Standard
        [JsonProperty("aim_difficulty")]
        public float AimDifficulty { get; set; }
        [JsonProperty("flashlight_difficulty")]
        public float FlashlightDifficulty { get; set; }
        [JsonProperty("overall_difficulty")]
        public float OverallDifficulty { get; set; }
        [JsonProperty("slider_factor")]
        public float SliderFactor { get; set; }
        [JsonProperty("speed_difficulty")]
        public float SpeedDifficulty { get; set; }

        // Taiko
        [JsonProperty("stamina_difficulty")]
        public float StaminaDifficulty { get; set; }
        [JsonProperty("rhythm_difficulty")]
        public float RhythmDifficulty { get; set; }
        [JsonProperty("colour_diffculty")]
        public float ColorDifficulty { get; set; }

        // Maina
        [JsonProperty("score_multiplier")]
        public float ScoreMultiplier { get; set; }
    }
}