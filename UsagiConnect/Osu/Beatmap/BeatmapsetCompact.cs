using Newtonsoft.Json;
using UsagiConnect.Osu.Enums;
using UsagiConnect.Osu.Beatmap;

namespace UsagiConnect.Osu.Beatmap
{
    public class BeatmapsetCompact
    {
        [JsonProperty("artist")]
        public string Artist { get; set; }

        [JsonProperty("artist_unicode")]
        public string ArtistUnicode { get; set; }

        [JsonProperty("covers")]
        public Covers Covers { get; set; }

        [JsonProperty("creator")]
        public string Creator { get; set; }

        [JsonProperty("favourite_count")]
        public int FavouriteCount { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nsfw")]
        public bool IsNsfw { get; set; }

        [JsonProperty("play_count")]
        public int PlayCount { get; set; }

        [JsonProperty("preview_url")]
        public string PreviewUrl { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("status")]
        public RankStatus Status { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("title_unicode")]
        public string TitleUnicode { get; set; }

        [JsonProperty("user_id")]
        public int UserId { get; set; }

        [JsonProperty("video")]
        public bool HasVideo { get; set; }
    }
}