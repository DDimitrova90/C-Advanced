namespace _06_Find_And_Sum_Integers
{
    using System;
    using System.Linq;

    public class FindAndSumIntegers
    {
        public static void Main()
        {
            long[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(e =>
                {
                    long value;
                    bool success = long.TryParse(e, out value);
                    return new { value, success };
                })
                .Where(e => e.success)
                .Select(e => e.value)
                .ToArray();

            if (numbers.Length == 0)
            {
                Console.WriteLine("No match");
            }
            else
            {
                Console.WriteLine(numbers.Sum());
            }
        }
    }
}
