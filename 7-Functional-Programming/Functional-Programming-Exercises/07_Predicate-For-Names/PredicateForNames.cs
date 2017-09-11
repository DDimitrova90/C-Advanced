namespace _07_Predicate_For_Names
{
    using System;
    using System.Linq;

    public class PredicateForNames
    {
        public static void Main()
        {
            int nameLength = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split(new char[] { ' ' }, 
                StringSplitOptions.RemoveEmptyEntries);

            Func<int, bool> checkLength = l => l <= nameLength;

            Console.WriteLine(string.Join("\n", names.Where(n => checkLength(n.Length))));
        }
    }
}
