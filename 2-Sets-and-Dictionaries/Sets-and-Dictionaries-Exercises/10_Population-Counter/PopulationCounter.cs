namespace _10_Population_Counter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PopulationCounter
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            Dictionary<string, Dictionary<string, long>> aggregatedData = 
                new Dictionary<string, Dictionary<string, long>>();

            while (input != "report")
            {
                string[] inputArgs = input
                    .Split(new char[] { '|' }, 
                    StringSplitOptions.RemoveEmptyEntries);
                string city = inputArgs[0];
                string country = inputArgs[1];
                long population = long.Parse(inputArgs[2]);

                if (!aggregatedData.ContainsKey(country))
                {
                    aggregatedData.Add(country, new Dictionary<string, long>());
                }

                if (!aggregatedData[country].ContainsKey(city))
                {
                    aggregatedData[country].Add(city, 0);
                }

                aggregatedData[country][city] += population;

                input = Console.ReadLine();
            }

            var orderedCountries = aggregatedData.OrderByDescending(c => c.Value.Sum(p => p.Value));

            foreach (var outerPair in orderedCountries)
            {
                long totalPopulation = outerPair.Value.Sum(p => p.Value);

                Console.WriteLine($"{outerPair.Key} (total population: {totalPopulation})");

                foreach (var innerPair in outerPair.Value.OrderByDescending(p => p.Value))
                {
                    Console.WriteLine($"=>{innerPair.Key}: {innerPair.Value}");
                }
            }
        }
    }
}
