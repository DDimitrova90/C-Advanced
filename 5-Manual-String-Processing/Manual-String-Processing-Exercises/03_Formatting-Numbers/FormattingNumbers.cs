namespace _03_Formatting_Numbers
{
    using System;

    public class FormattingNumbers
    {
        public static void Main()
        {
            string[] numbers = Console.ReadLine()
                .Split(new char[] { ' ', '\t', '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries);

            int numberA = int.Parse(numbers[0]);
            double numberB = double.Parse(numbers[1]);
            double numberC = double.Parse(numbers[2]);

            string numberAHex = numberA.ToString("X");
            string numberABinary = Convert.ToString(numberA, 2);

            if (numberABinary.Length > 10)
            {
                numberABinary = numberABinary.Substring(0, 10);
            }
            else if (numberABinary.Length < 10)
            {
                numberABinary = numberABinary.PadLeft(10, '0');
            }

            Console.WriteLine($"|{numberAHex,-10}|{numberABinary,10}|{numberB,10:F2}|{numberC,-10:F3}|");
        }
    }
}
