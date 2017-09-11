namespace _04_Add_VAT
{
    using System;
    using System.Linq;

    public class AddVAT
    {
        public static void Main()
        {
            Func<string, decimal> parser = s => decimal.Parse(s);
            Func<decimal, decimal> addVAT = p => p + (0.2M * p);

            decimal[] prices = Console.ReadLine()
                .Split(new char[] { ' ', ',' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .Select(addVAT)
                .ToArray();

            foreach (var price in prices)
            {
                Console.WriteLine($"{price:F2}");
            }
        }
    }
}
