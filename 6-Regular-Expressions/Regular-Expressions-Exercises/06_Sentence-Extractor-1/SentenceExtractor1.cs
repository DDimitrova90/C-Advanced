namespace _06_Sentence_Extractor_1
{
    using System;    
    using System.Text.RegularExpressions;

    public class SentenceExtractor1
    {
        public static void Main()
        {
            string keyword = Console.ReadLine();
            string sentence = Console.ReadLine();

            string pattern = $@"[A-Za-z0-9 ]+\b{keyword}\b.*?[\?!\.]";
            MatchCollection matches = Regex.Matches(sentence, pattern);

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
