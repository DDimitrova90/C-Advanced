namespace _10_Use_Your_Chains_Buddy
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class UseYourChainsBuddy
    {
        public static void Main()
        {
            string htmlDoc = Console.ReadLine();

            string pattern = @"<p>(.+?)<\/p>";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(htmlDoc);
            StringBuilder result = new StringBuilder();

            foreach (Match match in matches)
            {
                string text = Regex.Replace(match.Groups[1].ToString(), @"[^a-z0-9\s]", " ");
                string newText = string.Empty;

                for (int i = 0; i < text.Length; i++)
                {                   
                    int currLetter = text[i];

                    if (currLetter >= 97 && currLetter <= 109)
                    {
                        currLetter += 13;
                    }
                    else if (currLetter >= 110 && currLetter <= 122)
                    {
                        currLetter -= 13;
                    }
                    
                    newText += (char)currLetter;
                }

                text = newText;
                text = Regex.Replace(text, @"\s+", " ");
                result.Append(text);
            }

            Console.WriteLine(result);
        }
    }
}
