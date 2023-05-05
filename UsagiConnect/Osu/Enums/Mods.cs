using System;

namespace UsagiConnect.Osu.Enums
{
    [Flags]
    public enum Mods
    {
        [Mod("NM")] None = 0,
        [Mod("NF")] NoFail = 1,
        [Mod("EZ")] Easy = 2,
        [Mod("NV")] TouchDevice = 4,
        [Mod("HD")] Hidden = 8,
        [Mod("HR")] HardRock = 16,
        [Mod("SD")] SuddenDeath = 32,
        [Mod("DT")] DoubleTime = 64,
        [Mod("RX")] Relax = 128,
        [Mod("HT")] HalfTime = 256,
        [Mod("NC")] Nightcore = 512,   // Set along with DoubleTime (Value should be 576)
        [Mod("FL")] FlashLight = 1024,
        [Mod("Auto")] AutoPlay = 2048,
        [Mod("SO")] SpunOut = 4096,
        [Mod("AP")] Relax2 = 8192,  // Autoplay
        [Mod("PF")] Perfect = 16384, // Set along with SuddenDeath (Value should be 16416)
        [Mod("4K")] Key4 = 32768,
        [Mod("5K")] Key5 = 65536,
        [Mod("6K")] Key6 = 131072,
        [Mod("7K")] Key7 = 262144,
        [Mod("8K")] Key8 = 524288,
        [Mod("FadeIn")] FadeIn = 1048576,
        [Mod("Random")] Random = 2097152,
        [Mod("Cinema")] Cinema = 4194304,
        [Mod("Target")] Target = 8388608,
        [Mod("9K")] Key9 = 16777216,
        [Mod("Coop")] KeyCoop = 33554432,
        [Mod("1K")] Key1 = 67108864,
        [Mod("3K")] Key3 = 134217728,
        [Mod("2K")] Key2 = 268435456,
        [Mod("V2")] ScoreV2 = 536870912,
        [Mod("LM")] Mirror = 1073741824,
        [Mod("KeyMod")] KeyMod = Key1 | Key2 | Key3 | Key4 | Key5 | Key6 | Key7 | Key8 | Key9 | KeyCoop,
        [Mod("FreeModAllowed")] FreeModAllowed = NoFail | Easy | Hidden | HardRock | SuddenDeath | SuddenDeath | FlashLight | FadeIn | Relax | Relax2 | SpunOut | KeyMod,
        [Mod("ScoreIncreaseMods")] ScoreIncreaseMods = Hidden | HardRock | DoubleTime | FlashLight | FadeIn
    }
}