using Newtonsoft.Json;
using System;

namespace UsagiConnect.Osu.User
{
    public class UserCompact
    {
        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("default_group")]
        public string DefaultGroup { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        [JsonProperty("is_bot")]
        public bool IsBot { get; set; }

        [JsonProperty("is_deleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("is_online")]
        public bool IsOnline { get; set; }

        [JsonProperty("is_supporter")]
        public bool IsSupporter { get; set; }

        [JsonProperty("last_visit")]
        public DateTimeOffset LastVisit { get; set; }

        [JsonProperty("pm_friends_only")]
        public bool PmFriendsOnly { get; set; }

        [JsonProperty("profile_colour")]
        public string ProfileColor { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("account_history")]
        public UserAccountHistory[] UserAccountHistory { get; set; }

#nullable enable
        [JsonProperty("active_tournament_banner")]
        public ProfileBanner? ActiveTournamentBanner { get; set; }
#nullable disable
        [JsonProperty("badges")]
        public UserBadge[] Badges { get; set; }

        [JsonProperty("beatmap_playcounts_count")]
        public int BeatmapPlaycount { get; set; }

        [JsonProperty("favourite_beatmapset_count")]
        public int FacouriteBeatmapsetCount { get; set; }

        [JsonProperty("follower_count")]
        public int FollowerCount { get; set; }

        [JsonProperty("graveyard_beatmapset_count")]
        public int GraveyardBeatmapsetCount { get; set; }

        [JsonProperty("is_restricted")]
        public bool? IsRestricted { get; set; }

        [JsonProperty("loved_beatmapset_count")]
        public int LovedBeatmapsetCount { get; set; }
#nullable enable
        [JsonProperty("rank_highest")]
        public RankHighest? RankedHighest { get; set; }
#nullable disable

        [JsonProperty("score_best_count")]
        public int ScoreBestCount { get; set; }

        [JsonProperty("score_first_count")]
        public int ScoreFirstCount { get; set; }

        [JsonProperty("score_recent_count")]
        public int ScoreRecentCount { get; set; }
    }
}