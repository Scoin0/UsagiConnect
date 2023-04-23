using Newtonsoft.Json;
using System.Numerics;

namespace UsagiConnect.Osu.User
{
    public class UserStatistics
    {
        [JsonProperty("hit_accuracy")]
        public float HitAccuracy { get; set; }
        [JsonProperty("is_ranked")]
        public bool IsRanked { get; set; }
        [JsonProperty("maximum_combo")]
        public int MaximumCombo { get; set; }
        [JsonProperty("play_count")]
        public int PlayCount { get; set; }
        [JsonProperty("play_time")]
        public int PlayTime { get; set; }
        [JsonProperty("pp")]
        public float PP { get; set; }
        [JsonProperty("global_rank")]
        public int GlobalRank { get; set; }
        [JsonProperty("ranked_score")]
        public BigInteger RankedScore { get; set; }
        [JsonProperty("replays_watched_by_others")]
        public int ReplayedWatched { get; set; }
        [JsonProperty("total_hits")]
        public BigInteger TotalHits { get; set; }
        [JsonProperty("total_score")]
        public BigInteger TotalScore { get; set; }
        [JsonProperty("level")]
        public Level Level { get; set; }
        [JsonProperty("grade_counts")]
        public GradeCounts GradeCounts { get; set; }

    }
}