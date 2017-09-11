namespace _04_Cubic_Assault
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CubicAssault
    {
        public static void Main()
        {
            string line = Console.ReadLine();

            Dictionary<string, Dictionary<string, long>> regions = 
                new Dictionary<string, Dictionary<string, long>>();

            while (line != "Count em all")
            {
                string[] tokens = line
                    .Split(new string[] { "->" }, 
                    StringSplitOptions.RemoveEmptyEntries);
                string region = tokens[0].Trim();
                string meteor = tokens[1].Trim();
                long meteorCount = long.Parse(tokens[2].Trim());

                if (!regions.ContainsKey(region))
                {
                    regions.Add(region, new Dictionary<string, long>());
                }

                if (!regions[region].ContainsKey("Green"))
                {
                    regions[region].Add("Green", 0);
                }
                if (!regions[region].ContainsKey("Red"))
                {
                    regions[region].Add("Red", 0);
                }
                if (!regions[region].ContainsKey("Black"))
                {
                    regions[region].Add("Black", 0);
                }

                regions[region][meteor] += meteorCount;

                if (regions[region]["Green"] / 1000000 > 0)  // with "!= 0" gives 60/100 in Judge
                {
                    regions[region]["Red"] += regions[region]["Green"] / 1000000;
                    regions[region]["Green"] = regions[region]["Green"] % 1000000;
                }

                if (regions[region]["Red"] / 1000000 > 0)
                {
                    regions[region]["Black"] += regions[region]["Red"] / 1000000;
                    regions[region]["Red"] = regions[region]["Red"] % 1000000;
                }

                line = Console.ReadLine();
            }

            var orderedRegions = regions
                .OrderByDescending(r => r.Value["Black"])
                .ThenBy(r => r.Key.Length)
                .ThenBy(r => r.Key);

            foreach (var region in orderedRegions)
            {
                Console.WriteLine(region.Key);

                var orderedMeteors = region.Value
                    .OrderByDescending(m => m.Value)
                    .ThenBy(m => m.Key);

                foreach (var meteor in orderedMeteors)
                {
                    Console.WriteLine($"-> {meteor.Key} : {meteor.Value}");
                }
            }
        }
    }
}
