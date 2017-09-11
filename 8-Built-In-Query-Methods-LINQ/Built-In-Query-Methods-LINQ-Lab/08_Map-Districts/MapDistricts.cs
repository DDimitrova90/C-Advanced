namespace _08_Map_Districts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MapDistricts
    {
        public static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(new char[] { ' ' }, 
                StringSplitOptions.RemoveEmptyEntries);
            long minPopulation = long.Parse(Console.ReadLine());

            Dictionary<string, List<long>> districts = 
                new Dictionary<string, List<long>>();

            foreach (var element in input)
            {
                string[] elementArgs = element.Split(':');
                string town = elementArgs[0];
                long population = long.Parse(elementArgs[1]);

                if (!districts.ContainsKey(town))
                {
                    districts.Add(town, new List<long>());
                }

                districts[town].Add(population);
            }

            var filteresDistricts = districts
                .Where(d => d.Value.Sum() > minPopulation)
                .OrderByDescending(d => d.Value.Sum());

            foreach (var district in filteresDistricts)
            {
                Console.WriteLine($"{district.Key}: {string.Join(" ", district.Value.OrderByDescending(p => p).Take(5))}");
            }
        }
    }
}
