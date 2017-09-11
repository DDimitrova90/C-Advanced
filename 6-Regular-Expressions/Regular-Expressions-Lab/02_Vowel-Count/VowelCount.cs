namespace _02_Vowel_Count
{
    using System;
    using System.Text.RegularExpressions;

    public class VowelCount
    {
        public static void Main()
        {
            string text = Console.ReadLine().ToLower();

            string pattern = @"[aeouiy]"; // or [AEOUIYaeouiy]
            Regex regex = new Regex(pattern);
            int vowelsCount = regex.Matches(text).Count;

            Console.WriteLine($"Vowels: {vowelsCount}");
        }
    }
}
