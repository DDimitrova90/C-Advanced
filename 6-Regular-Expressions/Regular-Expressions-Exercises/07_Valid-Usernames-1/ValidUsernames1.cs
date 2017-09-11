namespace _07_Valid_Usernames_1
{
    using System;        
    using System.Linq;
    using System.Text.RegularExpressions;

    public class ValidUsernames1
    {
        public static void Main()
        {
            string pattern = @"\b[a-zA-Z][\w]{2,24}\b";
            string[] validUsernames = Console.ReadLine()
                .Split(new char[] { '/', '\\', ' ', '(', ')' }, 
                StringSplitOptions.RemoveEmptyEntries)
                .Where(u => Regex.IsMatch(u, pattern))
                .ToArray();

            int bestLengthSum = 0;
            string bestFirstUser = string.Empty;
            string bestSecondUser = string.Empty;

            for (int i = 0; i < validUsernames.Length - 1; i++)
            {
                string firstUser = validUsernames[i];
                string secondUser = validUsernames[i + 1];
                int currentLengthSum = firstUser.Length + secondUser.Length;

                if (currentLengthSum > bestLengthSum)
                {
                    bestLengthSum = currentLengthSum;
                    bestFirstUser = firstUser;
                    bestSecondUser = secondUser;
                }
            }

            Console.WriteLine(bestFirstUser);
            Console.WriteLine(bestSecondUser);
        }
    }
}
