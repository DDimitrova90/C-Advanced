namespace _14_Dragon_Army
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DragonArmy
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, SortedDictionary<string, long[]>> gameStatistics = 
                new Dictionary<string, SortedDictionary<string, long[]>>();

            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine()
                    .Trim()
                    .Split(new char[] { ' ' }, 
                    StringSplitOptions.RemoveEmptyEntries);

                string type = inputArgs[0];
                string name = inputArgs[1];
                long damage = inputArgs[2] == "null" ? 45 : long.Parse(inputArgs[2]); // !!!!!
                long health = inputArgs[3] == "null" ? 250 : long.Parse(inputArgs[3]);
                long armor = inputArgs[4] == "null" ? 10 : long.Parse(inputArgs[4]);

                if (!gameStatistics.ContainsKey(type))
                {
                    gameStatistics.Add(type, new SortedDictionary<string, long[]>());
                }

                if (!gameStatistics[type].ContainsKey(name))
                {
                    gameStatistics[type].Add(name, new long[3]);
                }

                gameStatistics[type][name][0] = damage;
                gameStatistics[type][name][1] = health;
                gameStatistics[type][name][2] = armor; 
            }

            foreach (var outerPair in gameStatistics)
            {
                decimal dragonsCount = Convert.ToDecimal(outerPair.Value.Count());
                decimal damageAvg = outerPair.Value.Sum(d => d.Value[0]) / dragonsCount;
                decimal healthAvg = outerPair.Value.Sum(h => h.Value[1]) / dragonsCount;
                decimal armorAvg = outerPair.Value.Sum(a => a.Value[2]) / dragonsCount;
                
                Console.WriteLine($"{outerPair.Key}::({damageAvg:F2}/{healthAvg:F2}/{armorAvg:F2})");

                foreach (var innerPair in outerPair.Value)
                {
                    Console.WriteLine($"-{innerPair.Key} -> damage: {innerPair.Value[0]}, health: {innerPair.Value[1]}, armor: {innerPair.Value[2]}");
                }
            }
        }
    }
}
