using Alpha.ID;
using System;
using System.Collections.Generic;

namespace Alpha.Test
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            goto JourneyCategories;

JourneyAmounts:
            {
                Console.WriteLine("Testing journey research amounts...");
                int[] sacs = JourneyHelpers.LoadSacrificeCountsNeededByItemIdFromFile();
                for (int i = 0; i < sacs.Length; i++)
                    Console.WriteLine($"{i}: {sacs[i]}");
            }

ItemNames:
            {
                Console.WriteLine("Testing item name getting...");
                for (int i = 0; i < ItemID.Count; i++)
                    Console.WriteLine(MiscTerrariaMethods.GetItemName(i));
            }

JourneyCategories:
            {
                Console.WriteLine("Testing item name getting...");
                for (int i = 0; i < ItemID.Count; i++)
                    foreach (KeyValuePair<string, bool> kvp in JourneyHelpers.GetJourneyCategoriesForItem(i))
                        Console.WriteLine($"[{i}] {kvp.Key}: {kvp.Value}");
            }
        }
    }
}
