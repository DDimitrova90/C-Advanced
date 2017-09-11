namespace _13_Magic_Exchangeable_Words_1
{
    using System;
    using System.Collections.Generic;

    public class MagicExchangeableWords1
    {
        public static void Main()
        {
            string[] words = Console.ReadLine()
                .Split(new char[] { ' ' }, 
                StringSplitOptions.RemoveEmptyEntries);
            string firstWord = words[0];
            string secondWord = words[1];
            bool result;

            if (firstWord.Length >= secondWord.Length)
            {
                result = AreWordsExchangeable(secondWord, firstWord);
            }
            else
            {
                result = AreWordsExchangeable(firstWord, secondWord);
            }

            Console.WriteLine(result.ToString().ToLower());
        }

        private static bool AreWordsExchangeable(string firstWord, string secondWord)
        {
            Dictionary<char, char> letters = new Dictionary<char, char>();

            for (int i = 0; i < firstWord.Length; i++)
            {
                if (!letters.ContainsKey(secondWord[i]))
                {
                    letters[secondWord[i]] = firstWord[i];
                }
                else if (letters[secondWord[i]] != firstWord[i])
                {
                    return false;
                }
            }

            for (int i = firstWord.Length; i < secondWord.Length; i++)
            {
                if (!letters.ContainsKey(secondWord[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
