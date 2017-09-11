namespace _06_Count_Substring_Occurrences_1
{
    using System;

    public class CountSubstringOccurrences1
    {
        public static void Main()
        {
            string text = Console.ReadLine().ToLower();
            string searchStr = Console.ReadLine().ToLower();

            int index = text.IndexOf(searchStr);
            int counter = 0;

            while (index != -1)
            {
                counter++;
                index = text.IndexOf(searchStr, index + 1);
            }

            Console.WriteLine(counter);
        }
    }
}
