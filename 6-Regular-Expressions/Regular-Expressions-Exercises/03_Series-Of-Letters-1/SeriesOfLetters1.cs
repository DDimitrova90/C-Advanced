namespace _03_Series_Of_Letters_1
{
    using System;   
    using System.Text.RegularExpressions;

    public class SeriesOfLetters1
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            string pattern = @"([A-Za-z])\1+";
            
            Console.WriteLine(Regex.Replace(input, pattern, "$1"));
        }
    }
}
