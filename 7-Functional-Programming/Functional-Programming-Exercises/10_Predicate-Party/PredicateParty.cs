namespace _10_Predicate_Party
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PredicateParty
    {
        public static void Main()
        {
            List<string> guests = Console.ReadLine()
                .Split(new char[] { ' ' }, 
                StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = Console.ReadLine();

            while (command != "Party!")
            {
                string[] commandTokens = command
                    .Split(new char[] { ' ' }, 
                    StringSplitOptions.RemoveEmptyEntries);
                string action = commandTokens[0];
                string criteria = commandTokens[1];

                for (int i = 0; i < guests.Count; i++)
                {
                    if (criteria == "StartsWith")
                    {
                        string str = commandTokens[2];
                        
                        if (guests[i].StartsWith(str))
                        {
                            i = RemoveOrDouble(action, guests, i);
                        }
                    }
                    else if (criteria == "EndsWith")
                    {
                        string str = commandTokens[2];

                        if (guests[i].EndsWith(str))
                        {
                            i = RemoveOrDouble(action, guests, i);
                        }
                    }
                    else if (criteria == "Length")
                    {
                        int length = int.Parse(commandTokens[2]);

                        if (guests[i].Length == length)
                        {
                            i = RemoveOrDouble(action, guests, i);
                        }
                    }
                }

                command = Console.ReadLine();
            }

            if (guests.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine(string.Join(", ", guests) + " are going to the party!");
            }
        }

        private static int RemoveOrDouble(string action, List<string> guests, int index)
        {
            if (action == "Remove")
            {
                guests.RemoveAt(index);
                index--;
            }
            else if (action == "Double")
            {
                guests.Insert(index + 1, guests[index]);
                index++;
            }

            return index;
        }
    }
}
