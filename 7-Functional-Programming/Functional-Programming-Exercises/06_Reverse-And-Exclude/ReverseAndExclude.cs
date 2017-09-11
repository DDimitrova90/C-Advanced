namespace _06_Reverse_And_Exclude
{
    using System;
    using System.Linq;

    public class ReverseAndExclude
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int divider = int.Parse(Console.ReadLine());

            Func<int[], int[]> reverseNumbers = n => n.Reverse().ToArray();
            Predicate<int> isDivisible = n => n % divider == 0;

            numbers = reverseNumbers(numbers);
            numbers = numbers.Where(n => !isDivisible(n)).ToArray();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
