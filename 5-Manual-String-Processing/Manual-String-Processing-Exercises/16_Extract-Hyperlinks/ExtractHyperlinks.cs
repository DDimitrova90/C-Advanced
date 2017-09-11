namespace _16_Extract_Hyperlinks
{
    using System;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    public class ExtractHyperlinks
    {
        public static void Main()
        {
            string line = Console.ReadLine();
            string pattern = @"<a\s+(?:[^>]+\s+)?href\s*=\s*(?:'([^']*)'|""([^""]*)""|([^\s>]+))[^>]*>";
            StringBuilder text = new StringBuilder();

            while (line != "END")
            {
                text.AppendLine(line);
                
                line = Console.ReadLine();
            }

            MatchCollection matches = Regex.Matches(text.ToString(), pattern);

            foreach (Match match in matches)
            {
                if (match.Groups[1].ToString() != "")
                {
                    Console.WriteLine(match.Groups[1]);
                }
                else if (match.Groups[2].ToString() != "")
                {
                    Console.WriteLine(match.Groups[2]);
                }
                else if (match.Groups[3].ToString() != "")
                {
                    Console.WriteLine(match.Groups[3]);
                }
            }
        }
    }
}
