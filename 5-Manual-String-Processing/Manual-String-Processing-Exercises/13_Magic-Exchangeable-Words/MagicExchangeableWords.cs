namespace _13_Magic_Exchangeable_Words
{
    using System;
    using System.Collections.Generic;

    public class MagicExchangeableWords
    {
        public static void Main()
        {
            string[] words = Console.ReadLine()
                .Split(new char[] { ' ' }, 
                StringSplitOptions.RemoveEmptyEntries);
            string firstWord = words[0];
            string secondWord = words[1];

            HashSet<char> firstSet = new HashSet<char>(firstWord);
            HashSet<char> secondSet = new HashSet<char>(secondWord);

            if (firstSet.Count == secondSet.Count)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}
