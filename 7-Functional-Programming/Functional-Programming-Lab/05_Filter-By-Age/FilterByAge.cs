namespace _05_Filter_By_Age
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FilterByAge
    {
        public static void Main()
        {
            int lines = int.Parse(Console.ReadLine());

            Dictionary<string, int> names = new Dictionary<string, int>();

            for (int i = 0; i < lines; i++)
            {
                string[] inputArgs = Console.ReadLine()
                    .Split(new char[] { ' ', ',' },
                    StringSplitOptions.RemoveEmptyEntries);

                if (!names.ContainsKey(inputArgs[0]))
                {
                    names.Add(inputArgs[0], 0);
                }

                names[inputArgs[0]] = int.Parse(inputArgs[1]);
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            if (condition == "younger")
            {
                var younger = names.Where(n => n.Value < age);

                PrintResult(younger, format);
            }
            else if (condition == "older")
            {
                var older = names.Where(n => n.Value >= age);

                PrintResult(older, format);
            }
        }

        private static void PrintResult(IEnumerable<KeyValuePair<string, int>> younger, string format)
        {
            if (format == "name")
            {
                foreach (var name in younger)
                {
                    Console.WriteLine(name.Key);
                }
            }
            else if (format == "age")
            {
                foreach (var name in younger)
                {
                    Console.WriteLine(name.Value);
                }
            }
            else if (format == "name age")
            {
                foreach (var name in younger)
                {
                    Console.WriteLine($"{name.Key} - {name.Value}");
                }
            }
        }
    }
}
