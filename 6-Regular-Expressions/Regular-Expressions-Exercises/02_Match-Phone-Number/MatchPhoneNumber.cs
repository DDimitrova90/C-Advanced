namespace _02_Match_Phone_Number
{
    using System;
    using System.Text.RegularExpressions;

    public class MatchPhoneNumber
    {
        public static void Main()
        {
            string phoneNumber = Console.ReadLine();

            string pattern = @"\+359( |-)2\1[0-9]{3}\1[0-9]{4}\b";
            Regex regex = new Regex(pattern);

            while (phoneNumber != "end")
            {
                Match match = regex.Match(phoneNumber);

                if (match.Success)
                {
                    Console.WriteLine(match);
                }

                phoneNumber = Console.ReadLine();
            }
        }
    }
}
