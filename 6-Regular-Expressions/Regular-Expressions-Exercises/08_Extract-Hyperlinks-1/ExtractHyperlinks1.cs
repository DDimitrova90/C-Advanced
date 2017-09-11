namespace _08_Extract_Hyperlinks_1
{
    using System;
    using System.Linq;     
    using System.Text;
    using System.Text.RegularExpressions;

    public class ExtractHyperlinks1
    {
        public static void Main()
        {
            string line = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            while (line != "END")
            {
                sb.Append(line).Append(" ");

                line = Console.ReadLine();
            }

            string pattern = @"<a\s+[^>]*?href\s*=(.*?)>.*?<\s*\/\s*a\s*>";
            MatchCollection matches = Regex.Matches(sb.ToString(), pattern);

            foreach (Match match in matches)
            {
                string candidateHref = match.Groups[1].ToString().Trim();

                if (candidateHref[0] == '"')
                {
                    Console.WriteLine(
                        candidateHref.Split(new char[] { '"' }, 
                        StringSplitOptions.RemoveEmptyEntries)
                        .First()); 
                }
                else if (candidateHref[0] == '\'')
                {
                    Console.WriteLine(
                        candidateHref.Split(new char[] { '\'' },
                        StringSplitOptions.RemoveEmptyEntries)
                        .First());
                }
                else
                {
                    Console.WriteLine(Regex.Split(candidateHref, @"\s+").First());
                }
            }
        }
    }
}
