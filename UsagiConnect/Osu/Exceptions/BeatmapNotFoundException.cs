using System;

namespace UsagiConnect.Osu.Exceptions
{
    public class BeatmapNotFoundException : Exception
    {
        public BeatmapNotFoundException() { }

        public BeatmapNotFoundException(string message) : base(string.Format("Beatmap Not Found: {0}.", message)) { }
    }
}
