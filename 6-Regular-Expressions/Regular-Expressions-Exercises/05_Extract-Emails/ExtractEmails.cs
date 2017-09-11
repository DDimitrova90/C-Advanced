namespace _05_Extract_Emails
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractEmails
    {
        public static void Main()
        {
            string text = Console.ReadLine();

            string pattern = @"\b(?<!\S)([A-Za-z0-9][\w-\.]+[A-Za-z0-9])@([a-z][a-z-]+[a-z])\.([a-z]+)(\.[a-z]+)?\b";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
