using Newtonsoft.Json;

namespace UsagiConnect.Osu.User
{
    public class ProfileBanner
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("tournament_id")]
        public int TournamentId { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }
    }
}