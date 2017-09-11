namespace _09_User_Logs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UserLogs
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            SortedDictionary<string, Dictionary<string, int>> logInfo = 
                new SortedDictionary<string, Dictionary<string, int>>();

            while (input != "end")
            {
                string[] inputArgs = input
                    .Trim()
                    .Split(new char[] { ' ', '=' }, 
                    StringSplitOptions.RemoveEmptyEntries);
                string IP = inputArgs[1];
                string username = inputArgs[5];

                if (!logInfo.ContainsKey(username))
                {
                    logInfo.Add(username, new Dictionary<string, int>());
                }

                if (!logInfo[username].ContainsKey(IP))
                {
                    logInfo[username].Add(IP, 0);
                }

                logInfo[username][IP] += 1;

                input = Console.ReadLine();
            }

            foreach (var user in logInfo)
            {
                Console.WriteLine($"{user.Key}:");

                int count = 0;

                foreach (var ip in user.Value)
                {
                    count++;

                    if (count == user.Value.Count())
                    {
                        Console.Write($"{ip.Key} => {ip.Value}.");
                    }
                    else
                    {
                        Console.Write($"{ip.Key} => {ip.Value}, ");
                    }   
                }

                Console.WriteLine();
            }
        }
    }
}
