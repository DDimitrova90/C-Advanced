namespace _04_Ashes_Of_Roses
{
    using System;      
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class AshesOfRoses
    {
        public static void Main()
        {
            string line = Console.ReadLine();

            string pattern = @"^Grow (<[A-Z][a-z]*>) (<[A-Za-z0-9]+>) ([0-9]+)$";
            Regex regex = new Regex(pattern);
            Dictionary<string, Dictionary<string, long>> roses = 
                new Dictionary<string, Dictionary<string, long>>();

            while (line != "Icarus, Ignite!")
            {
                Match match = regex.Match(line);

                if (match.Success)
                {
                    string region = match.Groups[1].ToString().Trim(new char[] { '<', '>' });
                    string color = match.Groups[2].ToString().Trim(new char[] { '<', '>' });
                    int roseAmount = int.Parse(match.Groups[3].ToString());

                    if (!roses.ContainsKey(region))
                    {
                        roses.Add(region, new Dictionary<string, long>());
                    }

                    if (!roses[region].ContainsKey(color))
                    {
                        roses[region].Add(color, 0);
                    }

                    roses[region][color] += roseAmount;
                }

                line = Console.ReadLine();
            }

            var orderedRegions = roses
                .OrderByDescending(r => r.Value.Select(a => a.Value).Sum())
                .ThenBy(r => r.Key);

            foreach (var outerPair in orderedRegions)
            {
                Console.WriteLine($"{outerPair.Key}");

                var orderedColors = outerPair.Value
                    .OrderBy(c => c.Value)
                    .ThenBy(c => c.Key);

                foreach (var color in orderedColors)
                {
                    Console.WriteLine($"*--{color.Key} | {color.Value}");
                }
            }
        }
    }
}
