namespace _06_Sentence_Extractor
{
    using System;
    using System.Text.RegularExpressions;

    public class SentenceExtractor
    {
        public static void Main()
        {
            string keyWord = Console.ReadLine();
            string text = Console.ReadLine();

            string pattern = @"(\w[^\!\?\.]*)?(\b" + keyWord + @"\b)[^\!\?\.]*[\!\?\.]";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
