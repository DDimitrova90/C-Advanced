namespace _09_User_Logs_1
{
    using System;             
    using System.Collections.Generic;
    using System.Linq;

    public class UserLogs1
    {
        public static void Main()
        {
            SortedDictionary<string, Dictionary<string, int>> users = 
                new SortedDictionary<string, Dictionary<string, int>>();
            string line = Console.ReadLine();

            while (line != "end")
            {
                string[] messageTokens = line.Split(' ');

                string ip = messageTokens[0].Replace("IP=", "");
                string username = messageTokens[2].Replace("user=", "");

                if (users.ContainsKey(username))
                {
                    if (users[username].ContainsKey(ip))
                    {
                        users[username][ip] += 1;
                    }
                    else
                    {
                        users[username][ip] = 1;
                    }
                }
                else
                {
                    users[username] = new Dictionary<string, int>() { { ip, 1 } };
                }

                line = Console.ReadLine();
            }

            PrintUsersAndIps(users);
        }

        public static void PrintUsersAndIps(SortedDictionary<string, Dictionary<string, int>> users)
        {
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key}:");
                Console.WriteLine("{0}.", 
                    string.Join(", ", user.Value.Select(u => $"{u.Key} => {u.Value}")));
            }
        }
    }
}
