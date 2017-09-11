namespace _12_Character_Multiplier
{
    using System;

    public class CharacterMultiplier
    {
        public static void Main()
        {
            string[] words = Console.ReadLine()
                .Split(new char[] { ' ' }, 
                StringSplitOptions.RemoveEmptyEntries);
            string firstWord = words[0];
            string secondWord = words[1];
            int minLength = Math.Min(firstWord.Length, secondWord.Length);
            long sum = 0;

            for (int i = 0; i < minLength; i++)
            {
                sum += firstWord[i] * secondWord[i];
            }

            if (firstWord.Length >= secondWord.Length)
            {
                for (int i = minLength; i < firstWord.Length; i++)
                {
                    sum += firstWord[i];
                }
            }
            else
            {
                for (int i = minLength; i < secondWord.Length; i++)
                {
                    sum += secondWord[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
