﻿using Alpha.ID;
using Alpha.Resources;
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

        private static readonly Regex sacrificeFileSplitRegex = new("\r\n|\r|\n");
        public static Dictionary<int, int> LoadSacrificeCountsNeededByItemIdFromFile()
        {
            Dictionary<int, int> ret = new();
            string[] array = sacrificeFileSplitRegex.Split(Resource.Sacrifices.GetText());

            foreach (string line in array)
            {
                if (line.StartsWith("//"))
                    continue;

                string[] parts = line.Split("\t");
                if (parts.Length >= 3 && ItemID.Search.TryGetId(parts[0], out int itemId))
                {
                    string category = parts[1].ToLower();
                    int? amount = LoadSacrificeCountsNeededByItemIdFromFile_ParseCategory(category);

                    if (!ret.ContainsKey(itemId) && amount != null)
                        ret.Add(itemId, amount.Value);
                }
            }

            return ret;
        }

        public static int? LoadSacrificeCountsNeededByItemIdFromFile_ParseCategory(string category)
        {
            return category switch {
                "" or "a" => 50,
                "b" => 25,
                "c" => 5,
                "d" => 1,
                "e" => null,
                "f" => 2,
                "g" => 3,
                "h" => 10,
                "i" => 15,
                "j" => 30,
                "k" => 99,
                "l" => 100,
                "m" => 200,
                "n" => 20,
                "o" => 400,
                _ => throw new Exception("Category " + category + " uknown."),
            };
        }
    }
}