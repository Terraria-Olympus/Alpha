﻿using System;
using System.Collections.Generic;

namespace Alpha.Test
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<int, int> sacs = MiscTerrariaMethods.LoadSacrificeCountsNeededByItemIdFromFile();
            for (int i = 0; i < sacs.Count; i++)
            {
                if (!sacs.ContainsKey(i))
                    continue;
                
                Console.WriteLine($"{i}: {sacs[i]}");
            }
        }
    }
}
