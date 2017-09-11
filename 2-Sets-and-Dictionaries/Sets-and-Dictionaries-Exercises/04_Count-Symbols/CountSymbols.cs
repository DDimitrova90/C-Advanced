namespace _04_Count_Symbols
{
    using System;
    using System.Collections.Generic;

    public class CountSymbols
    {
        public static void Main()
        {
            string text = Console.ReadLine();

            SortedDictionary<char, int> occurrences = 
                new SortedDictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!occurrences.ContainsKey(text[i]))
                {
                    occurrences.Add(text[i], 0);
                }

                occurrences[text[i]] += 1;
            }

            foreach (var occurr in occurrences)
            {
                Console.WriteLine($"{occurr.Key}: {occurr.Value} time/s");
            }
        }
    }
}
