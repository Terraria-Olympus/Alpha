using System;
using System.Collections.Generic;

namespace Alpha.Test
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            int[] sacs = MiscTerrariaMethods.LoadSacrificeCountsNeededByItemIdFromFile();
            for (int i = 0; i < sacs.Length; i++)
            {                
                Console.WriteLine($"{i}: {sacs[i]}");
            }
        }
    }
}
