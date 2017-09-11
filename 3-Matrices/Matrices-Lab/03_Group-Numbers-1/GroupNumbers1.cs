namespace _03_Group_Numbers_1
{
    using System;
    using System.Linq;

    public class GroupNumbers1
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Trim()
                .Split(new char[] { ' ', ',' }, 
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] zero = numbers
                .Where(n => Math.Abs(n) % 3 == 0)
                .ToArray();
            int[] one = numbers
                .Where(n => Math.Abs(n) % 3 == 1)
                .ToArray();
            int[] two = numbers
                .Where(n => Math.Abs(n) % 3 == 2)
                .ToArray();

            Console.WriteLine(string.Join(" ", zero));
            Console.WriteLine(string.Join(" ", one));
            Console.WriteLine(string.Join(" ", two));
        }
    }
}
