namespace _11_Semantic_HTML_2
{
    using System;
    using System.IO;     
    using System.Linq;
    using System.Text.RegularExpressions;

    public class SemanticHTML2
    {
        public static void Main()
        {
            var inputBuffer = new byte[4096];
            var inputStream = Console.OpenStandardInput(inputBuffer.Length);
            Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, inputBuffer.Length));

            var input = Console.ReadLine();

            const string pattern = @"(<(div).*?((id|class)\s*=\s*""(.*?)"").*?>)|(<\s*\/(div\s*>\s*<!--\s*(.*?)\s*--\s*)>)";
            var regex = new Regex(pattern);

            while (input != null && !input.Equals("END"))
            {
                var match = regex.Match(input);
                if (match.Success)
                {
                    if (!match.Groups[5].ToString().Equals(""))
                    {
                        input = input.Replace(match.Groups[2].ToString(), match.Groups[5].ToString());
                        input = Regex.Replace(input, $@"{match.Groups[3]}", "");
                        //input = Regex.Replace(input, @"<\s+>", " ");
                        Print(input);
                    }
                    else
                    {
                        input = input.Replace(match.Groups[7].ToString(), match.Groups[8].ToString());
                        Print(input);
                    }
                }
                else
                {
                    Console.WriteLine(input);
                }
                input = Console.ReadLine();
            }
        }

        private static void Print(string input)
        {
            for (var i = 0; i < input.Length - 1; i++)
            {
                if (input.ElementAt(i).Equals(' ') && input.ElementAt(i + 1).Equals(' ') || input.ElementAt(i).Equals(' ') && input.ElementAt(i + 1).Equals('>'))
                {
                    continue;
                }
                Console.Write(input.ElementAt(i));
            }
            Console.WriteLine(input.ElementAt(input.Length - 1));
        }
    }
}
