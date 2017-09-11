namespace _10_Use_Your_Chains_Buddy_1
{
    using System;        
    using System.Text;
    using System.Text.RegularExpressions;

    public class UseYourChainsBuddy1
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            string pattern = @"<p>(.*?)<\/p>";
            Regex regex = new Regex(pattern);
            string whiteSpaces = "[^a-z0-9]+";
            MatchCollection matches = regex.Matches(input);
            StringBuilder sb = new StringBuilder();

            foreach (Match match in matches)
            { 
                string replaced = Regex.Replace(match.Groups[1].ToString(), whiteSpaces, " ");

                foreach (var letter in replaced)
                {
                    if (letter >= 'a' && letter <= 'm')
                    {
                        sb.Append((char)(letter + 13));
                    }
                    else if (letter >= 'n' && letter <= 'z')
                    {
                        sb.Append((char)(letter - 13));
                    }
                    else
                    {
                        sb.Append(letter);
                    }
                }
            }

            Console.WriteLine(sb);
        }
    }
}
