using Newtonsoft.Json;
using System;

namespace UsagiConnect.Osu.API.User
{

    /// <summary>
    /// Follows the osu!web documentation of UserCompact (As of March 9th, 2023)
    /// Description: Mainly used for embedding in certain responses to save additional api lookups.
    /// URL:         https://osu.ppy.sh/docs/index.html#usercompact
    /// </summary>

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

        /// <summary>
        /// Follows the osu!web documentation of UserCompact (As of March 9th, 2023)
        /// Description: Following are attributes which may be additionally included in the response. Relevant endpoints should list them if applicable.
        /// URL:         https://osu.ppy.sh/docs/index.html#usercompact-optionalattributes
        /// </summary>

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

    public class RankHighest
    {
        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }

    public class UserAccountHistory
    {
#nullable enable
        [JsonProperty("description")]
        public string? Description { get; set; }
#nullable disable

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("length")]
        public int Length { get; set; }

        [JsonProperty("permanent")]
        public bool Permanent { get; set; }

        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

    }

    public class ProfileBanner
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("tournament_id")]
        public int TournamentId { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }
    }

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