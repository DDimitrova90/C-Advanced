namespace _13_Сръбско_Unleashed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class СръбскоUnleashed
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"(.+) @(.+) (\d+) (\d+)";
            Regex rgx = new Regex(pattern);

            Dictionary<string, Dictionary<string, long>> profitStatistics = 
                new Dictionary<string, Dictionary<string, long>>();

            while (input != "End")
            {          
                Match match = rgx.Match(input);

                if (match.Success)
                {
                    string venue = match.Groups[2].ToString();
                    string singer = match.Groups[1].ToString();
                    long ticketsPrice = long.Parse(match.Groups[3].ToString());
                    long ticketsCount = long.Parse(match.Groups[4].ToString());

                    if (!profitStatistics.ContainsKey(venue))
                    {
                        profitStatistics.Add(venue, new Dictionary<string, long>());
                    }

                    if (!profitStatistics[venue].ContainsKey(singer))
                    {
                        profitStatistics[venue].Add(singer, 0);
                    }

                    profitStatistics[venue][singer] += ticketsPrice * ticketsCount;
                }

                input = Console.ReadLine();
            }

            foreach (var outerPair in profitStatistics)
            {
                Console.WriteLine(outerPair.Key);

                foreach (var innerPair in outerPair.Value.OrderByDescending(p => p.Value))
                {
                    Console.WriteLine($"#  {innerPair.Key} -> {innerPair.Value}");
                }
            }
        }
    }
}
