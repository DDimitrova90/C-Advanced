namespace _11_Party_Reservation_Filter_Module_1
{
    using System;     
    using System.Collections.Generic;
    using System.Linq;

    public class PartyReservationFilterModule1
    {
        public static void Main()
        {
            var people = Console.ReadLine().Split().ToList();

            var input = Console.ReadLine();

            var criteriaString = new List<string>();
            while (!input.Equals("Print"))
            {
                var commands = input.Split(';').ToList();
                var mainCommand = commands[0];
                var criteria = commands[1];
                var filterString = commands[2];

                switch (mainCommand)
                {
                    case "Add filter":
                        criteriaString.Add($"{criteria}\\{filterString}");
                        break;

                    case "Remove filter":
                        criteriaString.Remove($"{criteria}\\{filterString}");
                        break;
                }

                input = Console.ReadLine();
            }

            foreach (var item in criteriaString)
            {
                var comands = item.Split('\\').ToList();
                Predicate<string> filter = ReservationFilterPeople(comands[0], comands[1]);
                people.RemoveAll(filter);
            }

            Console.WriteLine(people.Count == 0 ? "" : string.Join(" ", people));
        }

        public static Predicate<string> ReservationFilterPeople(string criteria, string filterString)
        {
            switch (criteria)
            {
                case "Starts with":
                    return n => n.StartsWith(filterString);

                case "Ends with":
                    return n => n.EndsWith(filterString);

                case "Length":
                    return n => n.Length == int.Parse(filterString);

                case "Contains":
                    return n => n.Contains(filterString);
            }

            return null;
        }
    }
}
