namespace _04_Jedi_Dreams
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class JediDreams
    {
        public static void Main()
        {
            int linesNumber = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> methods =
                new Dictionary<string, List<string>>();   
            string methodName = string.Empty;
            var methodDeclarePattern = @"static\s+[\w<>\[\],]+\s+(\w*[A-Z]{1}\w*)";
            var methodInvokePattern = @"(\w*[A-Z]{1}\w*)\s*(?:\()";

            for (int i = 0; i < linesNumber; i++)
            {
                string line = Console.ReadLine().Trim();

                if (line.StartsWith("static"))
                {
                    Regex regex = new Regex(methodDeclarePattern);
                    Match match = regex.Match(line);
                    methodName = match.Groups[1].ToString();

                    if (!methods.ContainsKey(methodName))
                    {
                        methods.Add(methodName, new List<string>());
                    }
                }
                else
                {
                    Regex regex = new Regex(methodInvokePattern);
                    MatchCollection matches = regex.Matches(line);

                    foreach (Match match in matches)
                    {
                        string currMatch = match.Groups[1].ToString();

                        methods[methodName].Add(currMatch);
                    }
                }
            }

            var orderedMethods = methods
                .OrderByDescending(m => m.Value.Count())
                .ThenBy(m => m.Key);

            foreach (var method in orderedMethods)
            {
                if (method.Value.Count == 0)
                {
                    Console.WriteLine($"{method.Key} -> None");
                }
                else
                {
                    Console.WriteLine($"{method.Key} -> {method.Value.Count()} -> " + string.Join(", ", method.Value.OrderBy(m => m)));
                }
            }
        }
    }
}
