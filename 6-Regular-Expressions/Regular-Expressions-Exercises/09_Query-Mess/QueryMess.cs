namespace _09_Query_Mess
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class QueryMess
    {
        public static void Main()
        { 
            string line = Console.ReadLine();

            string whiteSpace = @"%20|\+";
            string whiteSpaces = @"\s+";
            string splitters = @"\?|&";

            while (line != "END")
            {
                line = Regex.Replace(line, whiteSpace, " ");
                line = Regex.Replace(line, whiteSpaces, " ");
                string[] lineTokens = Regex.Split(line, splitters);

                Dictionary<string, List<string>> pairs = new Dictionary<string, List<string>>();

                for (int i = 0; i < lineTokens.Length; i++)
                {
                    if (lineTokens[i].Contains("="))
                    {
                        string[] tokenParts = Regex.Split(lineTokens[i], "=");
                        string field = tokenParts[0].Trim();
                        string value = tokenParts[1].Trim();

                        if (!pairs.ContainsKey(field))
                        {
                            pairs.Add(field, new List<string>());
                        }

                        pairs[field].Add(value);
                    }
                }

                foreach (var pair in pairs)
                {
                    Console.Write($"{pair.Key}=[{string.Join(", ", pair.Value)}]");
                }

                Console.WriteLine();

                line = Console.ReadLine();
            }
        }
    }
}
