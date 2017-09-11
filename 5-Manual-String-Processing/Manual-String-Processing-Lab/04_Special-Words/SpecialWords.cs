namespace _04_Special_Words
{
    using System;
    using System.Collections.Generic;

    public class SpecialWords
    {
        public static void Main()
        {
            char[] delimiters = new char[] { '(', ')', '[', ']', '<', '>', ',', '-', '!', '?', ' ' };
            Dictionary<string, int> specialWordsCount = new Dictionary<string, int>();

            string[] specialWords = Console.ReadLine()
                .Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            string[] words = Console.ReadLine()
                .Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            for (int currSpecialWordIndex = 0; currSpecialWordIndex < specialWords.Length; currSpecialWordIndex++)
            {
                string currSpecialWord = specialWords[currSpecialWordIndex];
                int counter = 0;

                for (int currWordIndex = 0; currWordIndex < words.Length; currWordIndex++)
                {
                    string currWord = words[currWordIndex];

                    if (currSpecialWord == currWord)
                    {
                        counter++;
                    }
                }

                Console.WriteLine($"{currSpecialWord} - {counter}");
            }
        }
    }
}
