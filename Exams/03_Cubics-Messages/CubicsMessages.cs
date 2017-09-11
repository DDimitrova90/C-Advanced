namespace _03_Cubics_Messages
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class CubicsMessages
    {
        public static void Main()
        {
            string line = Console.ReadLine();

            while (line != "Over!")
            {
                int messageLength = int.Parse(Console.ReadLine());
                string pattern = @"^([0-9]+)([A-Za-z]{" + messageLength + @"})([^A-Za-z]*)$";
                Regex regex = new Regex(pattern);
                Match match = regex.Match(line);

                if (match.Success)
                {
                    string message = match.Groups[2].ToString();
                    string digits = match.Groups[1].ToString();

                    for (int i = 0; i < match.Groups[3].Length; i++)
                    {
                        char currChar = match.Groups[3].ToString()[i];

                        if (char.IsDigit(currChar))
                        {
                            digits += currChar.ToString();
                        }
                    }

                    string verificationCode = string.Empty;

                    for (int i = 0; i < digits.Length; i++)
                    {
                        int currDigit = int.Parse(digits[i].ToString());

                        if (currDigit >= 0 && currDigit < message.Length)
                        {
                            verificationCode += message.ElementAt(currDigit);
                        }
                        else
                        {
                            verificationCode += " ";
                        }
                    }

                    Console.WriteLine($"{message} == {verificationCode}");
                }

                line = Console.ReadLine();
            }
        }
    }
}
