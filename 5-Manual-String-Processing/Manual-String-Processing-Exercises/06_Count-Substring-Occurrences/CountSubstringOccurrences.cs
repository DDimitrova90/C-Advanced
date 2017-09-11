namespace _06_Count_Substring_Occurrences
{
    using System;

    public class CountSubstringOccurrences
    {
        public static void Main()
        {
            string text = Console.ReadLine().ToLower();
            string searchString = Console.ReadLine().ToLower();

            int counter = 0;

            for (int currChar = 0; currChar < text.Length; currChar++)
            {
                string textPart = text.Substring(currChar);
                
                if (textPart.StartsWith(searchString))
                {
                    counter++;
                }  
            }

            Console.WriteLine(counter);
        }
    }
}
