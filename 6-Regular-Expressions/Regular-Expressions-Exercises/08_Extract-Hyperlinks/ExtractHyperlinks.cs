namespace _08_Extract_Hyperlinks
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class ExtractHyperlinks
    {
        public static void Main()
        {
            string line = Console.ReadLine();

            StringBuilder text = new StringBuilder();
            string pattern = @"<a\s+(?:[^>]+\s+)?href\s*=\s*(?:('[^']+')|(""[^""]+"")|([^\s>]+))[^>]*>";
            Regex regex = new Regex(pattern);

            while (line != "END")
            {
                text.AppendLine(line);

                line = Console.ReadLine();
            }

            MatchCollection matches = regex.Matches(text.ToString());

            foreach (Match match in matches)
            {
                if (match.Groups[1].Success)
                {
                    Console.WriteLine(match.Groups[1].ToString().Trim(new char[] { '"', '\'' }));
                }
                else if (match.Groups[2].Success)
                {
                    Console.WriteLine(match.Groups[2].ToString().Trim(new char[] { '"', '\'' }));
                }
                else if (match.Groups[3].Success)
                {
                    Console.WriteLine(match.Groups[3].ToString().Trim(new char[] { '"', '\'' }));
                }
            }
        }
    }
}
