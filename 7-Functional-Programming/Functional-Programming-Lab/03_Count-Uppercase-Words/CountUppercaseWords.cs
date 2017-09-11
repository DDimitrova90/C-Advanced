namespace _03_Count_Uppercase_Words
{
    using System;
    using System.Linq;

    public class CountUppercaseWords
    {
        public static void Main()
        {
            Func<string, bool> checkerForUppercase = w => char.IsUpper(w[0]);

            string[] words = Console.ReadLine()
                .Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .Where(checkerForUppercase)   // .Where(w => char.IsUpper(w[0]))
                .ToArray();

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
