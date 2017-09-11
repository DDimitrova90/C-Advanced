namespace _04_Replace_a_Tag
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class ReplaceATag
    {
        public static void Main()
        {
            string line = Console.ReadLine();

            string pattern = @"<a href=""(.*?)"">(\w+)(<\/a>)";
            string newPattern = @"[URL href=""$1""]$2[/URL]";
            StringBuilder result = new StringBuilder();

            while (line != "end")
            {
                result.AppendLine(Regex.Replace(line, pattern, newPattern));

                line = Console.ReadLine();
            }

            Console.WriteLine(result.ToString().Trim());
        }
    }

}
