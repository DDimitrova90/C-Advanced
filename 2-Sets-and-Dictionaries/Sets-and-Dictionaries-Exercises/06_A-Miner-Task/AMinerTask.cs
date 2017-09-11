namespace _06_A_Miner_Task
{
    using System;
    using System.Collections.Generic;

    public class AMinerTask
    {
        public static void Main()
        {
            Dictionary<string, long> resourcesStat = 
                new Dictionary<string, long>();

            while (true)
            {
                string resource = Console.ReadLine();

                if (resource.ToLower() == "stop")
                {
                    break;
                }

                long quantity = long.Parse(Console.ReadLine());         

                if (!resourcesStat.ContainsKey(resource))
                {
                    resourcesStat.Add(resource, 0);
                }

                resourcesStat[resource] += quantity;
            }

            foreach (var record in resourcesStat)
            {
                Console.WriteLine($"{record.Key} -> {record.Value}");
            }
        }
    }
}
