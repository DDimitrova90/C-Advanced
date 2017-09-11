namespace _12_Legendary_Farming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LegendaryFarming
    {
        public static void Main()
        {
            SortedDictionary<string, long> junks = new SortedDictionary<string, long>();
            Dictionary<string, long> keyMaterials = new Dictionary<string, long>();
            keyMaterials.Add("shards", 0);
            keyMaterials.Add("fragments", 0);
            keyMaterials.Add("motes", 0);
            string legendaryItem = string.Empty;

            while (true)
            {
                string[] inputArgs = Console.ReadLine()
                .ToLower()
                .Trim()
                .Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);      

                for (int i = 0; i < inputArgs.Length; i++)
                {
                    if (i % 2 != 0)
                    {
                        if (inputArgs[i] == "shards" ||
                            inputArgs[i] == "fragments" ||
                            inputArgs[i] == "motes")
                        {
                            keyMaterials[inputArgs[i]] += long.Parse(inputArgs[i - 1]);

                            if (keyMaterials[inputArgs[i]] >= 250)
                            {
                                keyMaterials[inputArgs[i]] -= 250;

                                legendaryItem = GetLegendaryItem(inputArgs[i]);

                                Console.WriteLine($"{legendaryItem} obtained!");

                                PrintKeyMaterials(keyMaterials);

                                PrintJunkMaterials(junks);

                                return;
                            }
                        }
                        else
                        {
                            if (!junks.ContainsKey(inputArgs[i]))
                            {
                                junks.Add(inputArgs[i], 0);
                            }

                            junks[inputArgs[i]] += long.Parse(inputArgs[i - 1]);
                        }
                    }
                }
            }             
        }

        public static void PrintJunkMaterials(SortedDictionary<string, long> junks)
        {
            foreach (var item in junks)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        public static void PrintKeyMaterials(Dictionary<string, long> keyMaterials)
        {
            var orderedKeyMaterials = keyMaterials
                .OrderByDescending(q => q.Value)
                .ThenBy(m => m.Key);

            foreach (var item in orderedKeyMaterials)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        public static string GetLegendaryItem(string material)
        {
            string legendaryItem = string.Empty;

            if (material == "shards")
            {
                legendaryItem =  "Shadowmourne";
            }
            else if (material == "fragments")
            {
                legendaryItem = "Valanyr";
            }
            else if (material == "motes")
            {
                legendaryItem = "Dragonwrath";
            }

            return legendaryItem;
        }
    }
}
