namespace _01_Take_Two
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TakeTwo
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, 
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> result = numbers
                .Where(n => n >= 10 && n <= 20)
                .Distinct()
                .Take(2)
                .ToList();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
