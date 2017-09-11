namespace _03_Series_Of_Letters
{
    using System;
    using System.Text.RegularExpressions;

    public class SeriesOfLetters
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            string pattern = @"([A-Za-z])\1+";
            Regex regex = new Regex(pattern);
            
            Console.WriteLine(regex.Replace(input, "$1"));
        }
    }
}
