namespace _07_Valid_Usernames
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class ValidUsernames
    {
        public static void Main()
        {
            char[] delimiters = new char[] { ' ', '/', '\\', '(', ')' };
            string[] usernames = Console.ReadLine()
                .Split(delimiters, 
                StringSplitOptions.RemoveEmptyEntries);
            List<string> validUsernames = new List<string>();

            string pattern = @"\b[A-Za-z][\w]{2,24}\b"; // @"^[A-Za-z][\w]{2,24}$"
            Regex regex = new Regex(pattern);

            for (int i = 0; i < usernames.Length; i++)
            {
                Match match = regex.Match(usernames[i]);

                if (match.Success)
                {
                    validUsernames.Add(usernames[i]);
                }
            }

            int maxSum = int.MinValue;
            int startIndex = -1;

            for (int i = 0; i < validUsernames.Count - 1; i++)
            {
                int currentSum = validUsernames[i].Length + validUsernames[i + 1].Length;

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    startIndex = i;
                }
            }

            Console.WriteLine(validUsernames[startIndex]);
            Console.WriteLine(validUsernames[startIndex + 1]);
        }
    }
}
