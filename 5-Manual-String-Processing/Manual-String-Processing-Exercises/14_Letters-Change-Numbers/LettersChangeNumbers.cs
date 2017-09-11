namespace _14_Letters_Change_Numbers
{
    using System;

    public class LettersChangeNumbers
    {
        public static void Main()
        {
            string[] inputStrings = Console.ReadLine()
                .Split(new char[] { ' ', '\t', '\r', '\n' }, 
                StringSplitOptions.RemoveEmptyEntries);
            decimal totalSum = 0M;           

            for (int i = 0; i < inputStrings.Length; i++)
            {
                string currString = inputStrings[i];
                char letterBefore = currString[0];
                decimal number = decimal.Parse(currString.Substring(1, currString.Length - 2));
                char letterAfter = currString[currString.Length - 1];
                decimal currSum = 0M;

                int letterBeforePos = GetLetterPosition(letterBefore);
                int letterAfterPos = GetLetterPosition(letterAfter);

                if (number == 0)
                {
                    currSum = 0;
                }
                else
                {
                    if (char.IsUpper(letterBefore))
                    {
                        currSum += (decimal)number / letterBeforePos;
                    }
                    else if (char.IsLower(letterBefore))
                    {
                        currSum += number * letterBeforePos;
                    }
                }
               
                if (char.IsUpper(letterAfter))
                {
                    currSum -= letterAfterPos;
                }
                else if (char.IsLower(letterAfter))
                {
                    currSum += letterAfterPos;
                }

                totalSum += currSum;
            }

            Console.WriteLine($"{totalSum:F2}");
        }

        private static int GetLetterPosition(char letter)
        {
            int letterPos = 0;

            if (char.IsUpper(letter))
            {
                letterPos = letter - 64;
            }
            else if (char.IsLower(letter))
            {
                letterPos = letter - 96;
            }

            return letterPos;
        }
    }
}
