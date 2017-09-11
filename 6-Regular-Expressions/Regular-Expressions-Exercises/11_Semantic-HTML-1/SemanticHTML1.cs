namespace _11_Semantic_HTML_1
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public class SemanticHTML1
    {
        public static void Main()
        {
            var sb = new StringBuilder();
            var input = Console.ReadLine();
            var openTags = new Stack<string>();
            var lastOpenTag = "";

            while (input != "END")
            {
                if (openTags.Count > 0)
                {
                    lastOpenTag = openTags.Peek();
                }

                var openPattern = @"<div (.*?)(id|class)\s*=\s*""(header|nav|footer|main|aside|section|article)""(.*?)>";
                var closePattern = $@"<\/div>\s*<!--\s*{lastOpenTag}\s*-->";
                var regexOpen = new Regex(openPattern);
                var regexClose = new Regex(closePattern);

                if (regexOpen.IsMatch(input))
                {
                    input = Regex.Replace(input, @"\s+", " ");
                    var match = regexOpen.Match(input);
                    lastOpenTag = match.Groups[3].Value;
                    var gr1 = match.Groups[1].Value.Trim();
                    var gr4 = match.Groups[4].Value.Trim();
                    if (gr1.Length == 0 && gr4.Length == 0)
                    {
                        input = $@"<{lastOpenTag}>";
                    }
                    else if (gr1.Length != 0 && gr4.Length == 0)
                    {
                        input = $@"<{lastOpenTag} {gr1}>";
                    }
                    else if (gr1.Length == 0 && gr4.Length != 0)
                    {
                        input = $@"<{lastOpenTag} {gr4}>";
                    }
                    else
                    {
                        input = $@"<{lastOpenTag} {gr1} {gr4}>";
                    }
                    sb.AppendLine(input);
                    openTags.Push(lastOpenTag);
                }
                else if (regexClose.IsMatch(input))
                {
                    input = Regex.Replace(input, closePattern, $@"</{openTags.Pop()}>");
                    sb.AppendLine(input);
                }
                else
                {
                    sb.AppendLine(input);
                }

                input = Console.ReadLine();
            }

            Console.Write(sb.ToString());
        }
    }
}