namespace _11_Semantic_HTML_3
{  
    using System;     
    using System.Text.RegularExpressions;

    public class SemanticHTML3
    {
        public static void Main()
        {
            string line = Console.ReadLine();

            string openingPattern = @"<(div)([^>]+)(?:id|class)\s*=\s*""(.*?)""(.*?)>";
            string closingPattern = @"<\/div>\s*<!--\s*(.*?)\s*-->";

            while (line != "END")
            {
                Match openingMatch = Regex.Match(line, openingPattern);
                Match closingMatch = Regex.Match(line, closingPattern);

                if (openingMatch.Success)
                {
                    line = Regex.Replace(line, openingPattern, @"$3 $2 $4").Trim();
                    line = "<" + Regex.Replace(line, @"\s+", " ") + ">";
                }
                else if (closingMatch.Success)
                {
                    line = "</" + closingMatch.Groups[1] + ">";
                }

                Console.WriteLine(line);

                line = Console.ReadLine();
            } 
        }
    }
}
