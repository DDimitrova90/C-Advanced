namespace _01_Match_Full_Name
{
    using System;
    using System.Text.RegularExpressions;

    public class MatchFullName
    {
        public static void Main()
        {
            string name = Console.ReadLine();

            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";
            Regex regex = new Regex(pattern);

            while (name != "end")
            {
                Match match = regex.Match(name);

                if (match.Success)
                {
                    Console.WriteLine(match);
                }

                name = Console.ReadLine();
            }
        }
    }
}
