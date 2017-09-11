namespace _03_Basic_Mark_Up_Language
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class BasicMarkUpLanguage
    {
        public static void Main()
        {
            string line = Console.ReadLine().Trim();

            string pattern = @"<\s*([a-z]+)\s+(value\s*=\s*""([0-9]+)""\s+)?(content\s*=\s*""([^""]*?)"")\s*\/>";
            Regex regex = new Regex(pattern);
            int count = 1;

            while (line != "<stop/>")
            {
                Match match = regex.Match(line);
                string command = match.Groups[1].Value;
                string content = match.Groups[5].Value;

                if (command == "inverse" && content != string.Empty)
                {
                    string result = string.Empty;

                    for (int i = 0; i < content.Length; i++)
                    {
                        if (char.IsUpper(content[i]))
                        {
                            result += content[i].ToString().ToLower();
                        }
                        else if (char.IsLower(content[i]))
                        {
                            result += content[i].ToString().ToUpper();
                        }
                        else if (char.IsWhiteSpace(content[i]))
                        {
                            result += content[i].ToString();
                        }
                        else
                        {
                            result += content[i].ToString();
                        }
                    }

                    Console.WriteLine($"{count}. {result}");
                    count++;
                }
                else if (command == "reverse" && content != string.Empty)
                {
                    string result = new string(content.Reverse().ToArray());

                    Console.WriteLine($"{count}. {result}");
                    count++;
                }
                else if (command == "repeat" && content != string.Empty)
                {
                    int value = int.Parse(match.Groups[3].Value);

                    for (int i = 0; i < value; i++)
                    {
                        Console.WriteLine($"{count}. {content}");
                        count++;
                    }
                }

                line = Console.ReadLine().Trim();
            }
        }
    }
}
