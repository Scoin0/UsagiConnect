using Newtonsoft.Json;

namespace UsagiConnect.Osu.Beatmap
{
    public class BeatmapAttributes
    {
        [JsonProperty("attributes")]
        public Attributes Attribute;
    }
}
