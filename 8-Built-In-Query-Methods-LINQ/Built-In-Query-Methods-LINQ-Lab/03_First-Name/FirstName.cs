namespace _03_First_Name
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FirstName
    {
        public static void Main()
        {
            List<string> names = Console.ReadLine()
                .Split(' ')
                .ToList();
            SortedSet<string> letters =
                new SortedSet<string>(Console.ReadLine().Split(' '));

            string name = string.Empty;

            foreach (var letter in letters)
            {
                name = names.FirstOrDefault(n => n.ToLower().StartsWith(letter.ToLower()));

                if (name != null)
                {
                    Console.WriteLine(name);
                    return;
                }
            }

            Console.WriteLine("No match");
        }
    }
}
