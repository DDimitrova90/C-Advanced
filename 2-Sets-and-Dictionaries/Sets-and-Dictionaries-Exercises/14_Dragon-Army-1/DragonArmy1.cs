namespace _14_Dragon_Army_1
{
    using System;                 
    using System.Collections.Generic;
    using System.Text;

    public class DragonArmy1
    {
        private const long DefaultDamage = 45;   
        private const long DefaultHealth = 250;
        private const long DefaultArmor = 10;

        public static void Main()
        {
            Dictionary<string, SortedDictionary<string, long[]>> allDragons =
                new Dictionary<string, SortedDictionary<string, long[]>>();

            int numberOfDragons = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfDragons; i++)
            {
                string[] dragon = Console.ReadLine()
                    .Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                string dragonType = dragon[0];
                string dragonName = dragon[1];
                long dragonDamage =
                    dragon[2] == "null" ? DefaultDamage : long.Parse(dragon[2]);
                long dragonHealth =
                    dragon[3] == "null" ? DefaultHealth : long.Parse(dragon[3]);
                long dragonArmor =
                    dragon[4] == "null" ? DefaultArmor : long.Parse(dragon[4]);

                if (allDragons.ContainsKey(dragonType))
                {
                    allDragons[dragonType][dragonName] =
                        new long[] { dragonDamage, dragonHealth, dragonArmor };
                }
                else
                {
                    allDragons[dragonType] = 
                        new SortedDictionary<string, long[]>()
                        { { dragonName, new long[] { dragonDamage, dragonHealth, dragonArmor } } };
                }
            }

            PrintAllDragons(allDragons);
        }

        public static void PrintAllDragons(Dictionary<string, SortedDictionary<string, long[]>> allDragons)
        {

            foreach (var dragonType in allDragons)
            {
                StringBuilder dragonTypeInfo = new StringBuilder();
                double avgDamage = 0;
                double avgHealth = 0;
                double avgArmor = 0;

                foreach (var dragon in dragonType.Value)
                {
                    dragonTypeInfo.Append($"-{dragon.Key} -> damage: {dragon.Value[0]}, health: {dragon.Value[1]}, armor: {dragon.Value[2]}\n");

                    avgDamage += dragon.Value[0];
                    avgHealth += dragon.Value[1];
                    avgArmor += dragon.Value[2];
                }

                avgDamage /= dragonType.Value.Count;
                avgHealth /= dragonType.Value.Count;
                avgArmor /= dragonType.Value.Count;

                Console.WriteLine($"{dragonType.Key}::" + 
                    $"({avgDamage:F2}/{avgHealth:F2}/{avgArmor:F2})");
                Console.Write(dragonTypeInfo.ToString());
            }
        }
    }
}
