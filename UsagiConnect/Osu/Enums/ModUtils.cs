using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UsagiConnect.Osu.Enums
{
    public static class ModUtils
    {
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

        public static string ToModString(this Mods mods)
        {
            if (mods == Mods.None)
                return modName[Mods.None];

            var m = modName
                .Where(k => k.Key != Mods.None && (mods & k.Key) == k.Key)
                .Select(k => k.Value);
            return string.Join(",", mods);
        }
    }
}
