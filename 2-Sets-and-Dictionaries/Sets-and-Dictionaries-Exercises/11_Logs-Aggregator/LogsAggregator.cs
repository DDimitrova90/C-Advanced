namespace _11_Logs_Aggregator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LogsAggregator
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            SortedDictionary<string, SortedDictionary<string, int>> logsInfo = 
                new SortedDictionary<string, SortedDictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine()
                    .Trim()
                    .Split(new char[] { ' ' }, 
                    StringSplitOptions.RemoveEmptyEntries);
                string IP = inputArgs[0];
                string username = inputArgs[1];
                int duration = int.Parse(inputArgs[2]);

                if (!logsInfo.ContainsKey(username))
                {
                    logsInfo.Add(username, new SortedDictionary<string, int>());
                }

                if (!logsInfo[username].ContainsKey(IP))
                {
                    logsInfo[username].Add(IP, 0);
                }

                logsInfo[username][IP] += duration;
            }

            foreach (var outerPair in logsInfo)
            {
                int totalDuration = outerPair.Value.Sum(d => d.Value);

                Console.WriteLine($"{outerPair.Key}: {totalDuration} [{string.Join(", ", outerPair.Value.Keys)}]");
            }
        }
    }
}
