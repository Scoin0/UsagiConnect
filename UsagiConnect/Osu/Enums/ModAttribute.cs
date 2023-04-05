using System;

namespace UsagiConnect.Osu.API.Enums
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class ModAttribute : Attribute
    {
        public ModAttribute(string Name)
        {
            ShortName = Name;
        }

        public string ShortName { get; }
    }
}
