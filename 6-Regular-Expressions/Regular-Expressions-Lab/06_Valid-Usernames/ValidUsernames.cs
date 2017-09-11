namespace _06_Valid_Usernames
{
    using System;
    using System.Text.RegularExpressions;

    public class ValidUsernames
    {
        public static void Main()
        {
            string line = Console.ReadLine();

            string pattern = @"^[a-zA-Z0-9-_]{3,16}$";
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
