namespace _11_Semantic_HTML
{
    using System;                             
    using System.Text;                                
    using System.Text.RegularExpressions;     // @"<div\s*(.*)(?:id|class)\s*=\s*""(\w+)""(.*?)>";

    public class SemanticHTML
    {
        public static void Main()
        {
            string line = Console.ReadLine();

            string pattern = @"(<div(\s+\w+\s*=\s*"".+"")?\s+(id|class)\s*=\s*""(main|header|nav|article|section|aside|footer)""(\s+\w+\s*=\s*"".+"")?\s*>)|(<\/div>\s+<!--\s*(\w+)\s*-->)";
            Regex regex = new Regex(pattern);
            StringBuilder result = new StringBuilder();  

            while (line != "END")
            {
                Match match = regex.Match(line);

                if (match.Groups[1].Success)
                {
                    string newTag = match.Groups[4].ToString(); 
                    string newLine = match.Groups[1].ToString().Replace("div", newTag);
                    newLine = Regex.Replace(newLine, @"((id|class)\s*=\s*""(main|header|nav|article|section|aside|footer)"")", "");
                    newLine = Regex.Replace(newLine, @"\s+", " ");
                    newLine = Regex.Replace(newLine, @"(\s+)>", ">");
                    result.AppendLine(newLine);
                }
                else if (match.Groups[6].Success)
                {
                    string newTag = match.Groups[7].ToString();
                    string newLine = match.Groups[6].ToString().Replace("div", newTag);
                    newLine = Regex.Replace(newLine, @"\s+<!--\s*(\w+)\s*-->", "");
                    result.AppendLine(newLine);
                }
                else
                {
                    result.AppendLine(line);
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(result.ToString().TrimEnd());
        }
    }
}
