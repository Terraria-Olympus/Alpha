using Alpha.ID;
using System;
using System.Collections.Generic;

namespace Alpha.Test
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Testing journey research amounts...");
            int[] sacs = MiscTerrariaMethods.LoadSacrificeCountsNeededByItemIdFromFile();
            for (int i = 0; i < sacs.Length; i++)
                Console.WriteLine($"{i}: {sacs[i]}");

            Console.WriteLine("Testing item name getting...");
            for (int i = 0; i < ItemID.Count; i++)
                Console.WriteLine(MiscTerrariaMethods.GetItemName(i));
        }
    }
}
