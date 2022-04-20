using Alpha.ID;
using Alpha.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Alpha
{
    public static class JourneyHelpers
    {
        private static readonly Regex sacrificeFileSplitRegex = new("\r\n|\r|\n");
        public static int[] LoadSacrificeCountsNeededByItemIdFromFile()
        {
            int[] ret = new int[ItemID.Count];
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

                    if (amount != null)
                        ret[itemId] = amount.Value;
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

        private static Dictionary<int, Dictionary<string, bool>> JourneyCategoriesByItemId;
        public static Dictionary<string, bool> GetJourneyCategoriesForItem(string name) => GetJourneyCategoriesForItem(ItemID.Search.GetId(name));
        public static Dictionary<string, bool> GetJourneyCategoriesForItem(int id)
        {
            if (JourneyCategoriesByItemId == null)
                JourneyCategoriesByItemId = JsonConvert.DeserializeObject<Dictionary<int, Dictionary<string, bool>>>(Resource.JourneyCategories.GetText());

            return JourneyCategoriesByItemId[id];
        }
    }
}
