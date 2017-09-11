namespace _07_Fix_Emails
{
    using System;
    using System.Collections.Generic;

    public class FixEmails
    {
        public static void Main()
        {
            string name = Console.ReadLine();

            Dictionary<string, string> usersInfo = 
                new Dictionary<string, string>();

            while (name != "stop")
            {
                string email = Console.ReadLine().Trim();

                if (!email.EndsWith("us") && !email.EndsWith("uk"))
                {
                    if (!usersInfo.ContainsKey(name))
                    {
                        usersInfo.Add(name, email);
                    }

                    usersInfo[name] = email;
                }

                name = Console.ReadLine();
            }

            foreach (var entry in usersInfo)
            {
                Console.WriteLine($"{entry.Key} -> {entry.Value}");
            }
        }
    }
}
