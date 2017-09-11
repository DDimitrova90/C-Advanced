namespace _04_Average_Of_Doubles
{
    using System;
    using System.Linq;

    public class AverageOfDoubles
    {
        public static void Main()
        {
            double[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            double result = numbers.Sum() / numbers.Length;

            Console.WriteLine($"{result:F2}");
        }
    }
}
