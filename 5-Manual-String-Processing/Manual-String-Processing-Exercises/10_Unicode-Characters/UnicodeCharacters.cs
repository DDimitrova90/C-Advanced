namespace _10_Unicode_Characters
{
    using System;

    public class UnicodeCharacters
    {
        public static void Main()
        {
            string inputString = Console.ReadLine();
            string result = string.Empty;

            for (int i = 0; i < inputString.Length; i++)
            {
                int currChar = inputString[i];
                result += "\\u" + currChar.ToString("X4").ToLower();
            }

            Console.WriteLine(result);
        }
    }
}
