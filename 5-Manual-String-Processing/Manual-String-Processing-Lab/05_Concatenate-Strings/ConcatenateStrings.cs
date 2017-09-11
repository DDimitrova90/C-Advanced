namespace _05_Concatenate_Strings
{
    using System;
    using System.Text;

    public class ConcatenateStrings
    {
        public static void Main()
        {
            int wordsNumber = int.Parse(Console.ReadLine());

            StringBuilder strBuilder = new StringBuilder();

            for (int wordIndex = 0; wordIndex < wordsNumber; wordIndex++)
            {
                string word = Console.ReadLine();

                strBuilder.Append(word + " ");
            }

            Console.WriteLine(strBuilder.ToString().Trim());
        }
    }
}
