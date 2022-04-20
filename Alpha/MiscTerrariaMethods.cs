using Alpha.ID;
using Alpha.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Alpha
{
    public static class MiscTerrariaMethods
    {
        public static string GetSavePath()
        {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "My Games", "Terraria");
            else
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "My Games");
        }

        private static Dictionary<string, string> itemNames;
        public static string GetItemName(int id) => GetItemName(ItemID.Search.GetName(id));
        public static string GetItemName(string internalName)
        {
            if (itemNames == null)
                itemNames = JsonConvert.DeserializeObject<Dictionary<string, string>>(Resource.ItemNames.GetText());

            if (itemNames.TryGetValue(internalName, out string name))
                return name;

            return internalName;
        }
    }
}
