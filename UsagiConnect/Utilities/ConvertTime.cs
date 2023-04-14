using System;

namespace UsagiConnect.Utilities
{
    public class ConvertTime
    {
        public static string HumanReadableTime(int seconds)
        {
            TimeSpan time = TimeSpan.FromSeconds(seconds);
            string formattedTime = "";

            if (time.Hours > 0)
            {
                formattedTime += string.Format("{0:D}:{1:D2}:{2:D2}", time.Hours, time.Minutes, time.Seconds);
            }
            else if (time.Minutes > 0)
            {
                formattedTime += string.Format("{0:D}:{1:D2}", time.Minutes, time.Seconds);
            }
            else
            {
                formattedTime += string.Format("{0:D}", time.Seconds);
            }
            return formattedTime;
        }
    }
}