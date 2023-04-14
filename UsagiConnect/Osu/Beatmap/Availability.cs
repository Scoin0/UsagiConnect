using Newtonsoft.Json;

namespace UsagiConnect.Osu.Beatmap
{
    public class Availability
    {
        [JsonProperty("download_disabled")]
        public bool IsDownloadDisabled { get; set; }

        [JsonProperty("more_information")]
        public string MoreInformation { get; set; }
    }
}