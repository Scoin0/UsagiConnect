using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UsagiConnect.Osu.Enums
{
    public static class ModUtils
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ModUtils).Name);
        private static Dictionary<Mods, string> modName { get; }

        static ModUtils()
        {
            modName = new Dictionary<Mods, string>();
            var m = typeof(Mods);
            var mi = m.GetTypeInfo();
            var mods = Enum.GetValues(m).Cast<Mods>();

            foreach (var mod in mods)
            {
                modName[mod] = mi.DeclaredMembers
                    .FirstOrDefault(dm => dm.Name == mod.ToString())
                    .GetCustomAttribute<ModAttribute>().ShortName;
            }
        }

        public static TAttribute GetAttribute<TAttribute>(this Enum mods)
            where TAttribute : Attribute
        {
            var type = mods.GetType();
            var name = Enum.GetName(type, mods);
            return type.GetField(name)
                .GetCustomAttributes(false)
                .OfType<TAttribute>()
                .SingleOrDefault();
        }

        public static string ToModString(this Mods mods)
        {
            if (mods == Mods.None)
                return modName[Mods.None];

            var m = modName
                .Where(k => k.Key != Mods.None && (mods & k.Key) == k.Key)
                .Select(k => k.Value);
            return string.Join("", m);
        }

        public static int ConvertTime(int time, int mods)
        {
            string modType = ModUtils.ToModString((Mods)mods);

            if (modType.Contains("NC") || modType.Contains("DT"))
            {
                time = Convert.ToInt32(time / 1.5);
            }

            return time;
        }

        public static double ConvertBPM(double bpm, int mods)
        {
            string modType = ModUtils.ToModString((Mods)mods);

            if (modType.Contains("NC") || modType.Contains("DT"))
            {
                bpm = bpm * 1.5;
            }

            return bpm;
        }

        public static int ConvertToInt(string mods)
        {
            ModUtils.TryParse(mods, out Mods m);
            string modType = ModUtils.ToModString(m);
            int modValue = ((int)m);

            if (modType.Contains("NC"))
            {
                modValue += 64;
            }
            else if (modType.Contains("PF"))
            {
                modValue += 32;
            }

            /**
            string a = "";
            Log.Info(ModUtils.ConvertToInt(a));
            ModUtils.TryParse(a, out Mods ab);
            Log.Info(ModUtils.ToModString(ab));
            */

            return modValue;
        }

        public static bool TryParse(string value, out Mods mods)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                mods = Mods.None;
                return false;
            }

            var mod = modName
                .Where(x => value.ToLower().Contains(x.Value.ToLower()))
                .Select(y => y.Key);
            mods = Mods.None;

            foreach (var m in mod)
            {
                if ((mods & m) != 0)
                {
                    continue;
                }
                mods |= m;
            }
            return true;
        }
    }
}