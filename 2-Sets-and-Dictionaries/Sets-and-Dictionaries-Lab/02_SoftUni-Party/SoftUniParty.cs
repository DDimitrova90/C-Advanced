namespace _02_SoftUni_Party
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SoftUniParty
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            SortedSet<string> reservations = new SortedSet<string>();
            SortedSet<string> comings = new SortedSet<string>();
            bool isPartyStarted = false;

            while (input != "END")
            {
                if (input == "PARTY")
                {
                    isPartyStarted = true;
                }

                if (!isPartyStarted && input != "PARTY")
                {
                    reservations.Add(input);
                }
                else if (isPartyStarted && input != "PARTY")
                {
                    comings.Add(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(reservations.Count() - comings.Count());

            foreach (var record in reservations)
            {
                if (!comings.Contains(record))
                {
                    Console.WriteLine(record);
                }
            }
        }
    }
}
