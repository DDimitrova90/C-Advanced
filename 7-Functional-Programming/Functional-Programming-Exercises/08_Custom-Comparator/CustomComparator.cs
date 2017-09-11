namespace _08_Custom_Comparator
{
    using System;
    using System.Linq;

    public class CustomComparator
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderBy(n => n)
                .ToArray();

            int[] result = numbers.Where(n => n % 2 == 0).OrderBy(n => n).ToArray();
            result = result.Concat(numbers.Where(n => n % 2 != 0).OrderBy(n => n)).ToArray();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
