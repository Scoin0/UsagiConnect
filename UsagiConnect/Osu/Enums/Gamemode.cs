using System.ComponentModel;

namespace UsagiConnect.Osu.Enums
{
    public enum Gamemode
    {
        [Description("osu!")]
        Osu = 0,
        [Description("osu!taiko")]
        Taiko = 1,
        [Description("osu!catch")]
        Fruits = 2,
        [Description("osu!maina")]
        Maina = 3
    }
}
