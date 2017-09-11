namespace _03_Non_Digit_Count
{
    using System;
    using System.Text.RegularExpressions;

    public class NonDigitCount
    {
        public static void Main()
        {
            string text = Console.ReadLine();

            string pattern = @"\D";
            Regex regex = new Regex(pattern);
            int nonDigitCharsCount = regex.Matches(text).Count;

            Console.WriteLine($"Non-digits: {nonDigitCharsCount}");
        }
    }
}
