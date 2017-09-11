namespace _05_Min_Even_Number
{
    using System;
    using System.Linq;

    public class MinEvenNumber
    {
        public static void Main()
        {
            double[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            numbers = numbers.Where(n => n % 2 == 0).ToArray();

            if (numbers.Length == 0)
            {
                Console.WriteLine("No match");
            }
            else
            {
                double result = numbers.Min();
                Console.WriteLine($"{result:F2}");
            }
        }
    }
}
