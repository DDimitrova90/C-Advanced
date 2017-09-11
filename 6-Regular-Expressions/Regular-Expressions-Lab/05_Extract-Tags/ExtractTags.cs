namespace _05_Extract_Tags
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class ExtractTags
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            string pattern = @"<.+?>";
            Regex regex = new Regex(pattern);
            List<string> tags = new List<string>();

            while (input != "END")
            {
                MatchCollection matches = regex.Matches(input);

                foreach (Match match in matches)
                {
                    tags.Add(match.ToString());
                }

                input = Console.ReadLine();
            }

            if (tags.Count > 0)
            {
                Console.WriteLine(string.Join("\n", tags));
            }
        }
    }
}
