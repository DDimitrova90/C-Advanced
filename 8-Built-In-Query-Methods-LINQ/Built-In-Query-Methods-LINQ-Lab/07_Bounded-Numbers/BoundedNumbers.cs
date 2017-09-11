namespace _07_Bounded_Numbers
{
    using System;
    using System.Linq;

    public class BoundedNumbers
    {
        public static void Main()
        {
            int[] bounds = Console.ReadLine()
                .Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int lowerBound = bounds.Min();
            int upperBound = bounds.Max();

            int[] result = numbers
                .Where(n => n >= lowerBound && n <= upperBound)
                .ToArray();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
