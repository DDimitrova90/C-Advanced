namespace _11_Palindromes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Palindromes
    {
        public static void Main()
        {
            char[] delimiters = new char[] 
            { ' ', '\t', '\r', '\n', ',', '.', '?', '!' };
            string[] words = Console.ReadLine()
                .Split(delimiters, 
                StringSplitOptions.RemoveEmptyEntries);
            List<string> palindromes = new List<string>();

            for (int i = 0; i < words.Length; i++)
            {
                string currWord = words[i];
                string reversedWord = new string(words[i].Reverse().ToArray());

                if (reversedWord == currWord && !palindromes.Contains(currWord))
                {
                    palindromes.Add(currWord);
                }                
            }

            Console.WriteLine("[" + string.Join(", ", palindromes.OrderBy(x => x)) + "]");
        }
    }
}
