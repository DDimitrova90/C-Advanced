namespace _04_Extract_Integer_Numbers
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractIntegerNumbers
    {
        public static void Main()
        {
            string text = Console.ReadLine();

            string pattern = @"[\d]+";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);

            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    Console.WriteLine(match);
                }
            }
        }
    }
}
