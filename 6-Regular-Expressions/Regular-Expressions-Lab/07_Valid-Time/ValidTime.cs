namespace _07_Valid_Time
{
    using System;
    using System.Text.RegularExpressions;

    public class ValidTime
    {
        public static void Main()
        {
            string line = Console.ReadLine();

            string pattern = @"^[0-2][0-9]:[0-5][0-9]:[0-5][0-9] (AM|PM)$";
            Regex regex = new Regex(pattern);

            while (line != "END")
            {
                Match match = regex.Match(line);

                if (match.Success)
                {
                    Console.WriteLine("valid");
                }
                else
                {
                    Console.WriteLine("invalid");
                }

                line = Console.ReadLine();
            }
        }
    }
}
