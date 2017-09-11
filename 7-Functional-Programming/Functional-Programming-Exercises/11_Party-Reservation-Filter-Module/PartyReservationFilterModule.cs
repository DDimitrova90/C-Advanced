namespace _11_Party_Reservation_Filter_Module
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PartyReservationFilterModule
    {
        public static void Main()
        {
            List<string> guests = Console.ReadLine()
                .Split(new char[] { ' ' }, 
                StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> result = guests;

            string command = Console.ReadLine();

            while (command != "Print")
            {
                string[] commandTokens = command
                    .Split(new char[] { ';' }, 
                    StringSplitOptions.RemoveEmptyEntries);
                string filterCommand = commandTokens[0];
                string filterType = commandTokens[1];
                string filterParameter = commandTokens[2];

                if (filterCommand == "Add filter")
                {
                    result = AddFilters(result, filterType, filterParameter);
                }
                else if (filterCommand == "Remove filter")
                {
                    RemoveFilters(guests, result, filterType, filterParameter);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", result));
        }

        private static void RemoveFilters(List<string> guests, List<string> result, string filterType, string filterParameter)
        {
            if (filterType == "Starts with")
            {
                result.AddRange(guests.Where(g => g.StartsWith(filterParameter))
                                      .ToList());
            }
            else if (filterType == "Ends with")
            {
                result.AddRange(guests.Where(g => g.EndsWith(filterParameter))
                                     .ToList());
            }
            else if (filterType == "Length")
            {
                result.AddRange(guests.Where(g => g.Length == int.Parse(filterParameter))
                                     .ToList());
            }
            else if (filterType == "Contains")
            {
                result.AddRange(guests.Where(g => g.Contains(filterParameter))
                                      .ToList());
            }
        }

        private static List<string> AddFilters(List<string> result, string filterType, string filterParameter)
        {
            if (filterType == "Starts with")
            {
                result = result
                    .Where(g => !g.StartsWith(filterParameter))
                    .ToList();
            }
            else if (filterType == "Ends with")
            {
                result = result
                   .Where(g => !g.EndsWith(filterParameter))
                   .ToList();
            }
            else if (filterType == "Length")
            {
                result = result
                   .Where(g => g.Length != int.Parse(filterParameter))
                   .ToList();
            }
            else if (filterType == "Contains")
            {
                result = result
                   .Where(g => !g.Contains(filterParameter))
                   .ToList();
            }

            return result;
        }
    }
}
