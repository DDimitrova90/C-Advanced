namespace _01_Sort_Even_Numbers
{
    using System;
    using System.Linq;

    public class SortEvenNumbers
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ', ',' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(string.Join(", ", numbers.Where(n => n % 2 == 0).OrderBy(n => n).ToArray()));

            // OR:
            //Func<string, int> numberParser = n => int.Parse(n);

            //int[] numbers = Console.ReadLine()
            //    .Split(new char[] { ' ', ',' },
            //    StringSplitOptions.RemoveEmptyEntries)
            //    .Select(numberParser)
            //    .ToArray();

            // OR:
            //int[] numbers = Console.ReadLine()
            //    .Split(new char[] { ' ', ',' },
            //    StringSplitOptions.RemoveEmptyEntries)
            //    .Select(ParseToNumber)
            //    .ToArray();
        }

        //private static int ParseToNumber(string n)
        //{
        //    return int.Parse(n);
        //}
    }
}
