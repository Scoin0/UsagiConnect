using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UsagiConnect.Osu.API.Enums
{
    public static class ModUtils
    {
        //private static readonly ILog Log = LogManager.GetLogger(typeof(Form1));

        private static Dictionary<Mods, string> ModName { get; }

        static ModUtils()
        {
            ModName = new Dictionary<Mods, string>();
            var m = typeof(Mods);
            var mi = m.GetTypeInfo();
            var mods = Enum.GetValues(m).Cast<Mods>();

            foreach (var mod in mods)
            {
                ModName[mod] = mi.DeclaredMembers
                    .FirstOrDefault(dm => dm.Name == mod.ToString())
                    .GetCustomAttribute<ModAttribute>().ShortName;
            }
        }

        public static string ToModString(this Mods mods)
        {
            if (mods == Mods.None)
                return ModName[Mods.None];

            var m = ModName
                .Where(k => k.Key != Mods.None && (mods & k.Key) == k.Key)
                .Select(k => k.Value);
            return string.Join(",", mods);
        }
    }
}
