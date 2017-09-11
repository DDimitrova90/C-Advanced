namespace _03_Parse_Tags
{
    using System;

    public class ParseTags
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            string openTag = "<upcase>";
            string closeTag = "</upcase>";

            int openTagIndex = text.IndexOf(openTag);
            
            while (openTagIndex != -1)
            {
                int closeTagIndex = text.IndexOf(closeTag);

                if (closeTagIndex == -1)
                {
                    break;
                }

                string changedCase = text
                    .Substring(openTagIndex + openTag.Length, closeTagIndex - openTagIndex - openTag.Length)
                    .ToUpper();
                text = 
                    text.Substring(0, openTagIndex) + 
                    changedCase + 
                    text.Substring(closeTagIndex + closeTag.Length);
 
                openTagIndex = text.IndexOf("<upcase>");
                closeTagIndex = text.IndexOf("</upcase>");
            }

            Console.WriteLine(text);
        }
    }
}
