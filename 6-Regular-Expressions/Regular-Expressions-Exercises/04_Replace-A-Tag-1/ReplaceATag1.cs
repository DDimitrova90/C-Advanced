namespace _04_Replace_A_Tag_1
{
    using System;       
    using System.Text;
    using System.Text.RegularExpressions;

    public class ReplaceATag1
    {
        public static void Main()
        {
            string input = Console.ReadLine();
 
            StringBuilder sb = new StringBuilder();

            while (input != "end")
            { 
                sb.AppendLine(input);

                input = Console.ReadLine();
            }

            string pattern = @"<a (href=.+?)>(.+)<\/a>";

            string result = Regex.Replace(sb.ToString(), pattern, t => $"[URL {t.Groups[1]}]{t.Groups[2]}[/URL]");

            Console.WriteLine(result);           
        }
    }
}
