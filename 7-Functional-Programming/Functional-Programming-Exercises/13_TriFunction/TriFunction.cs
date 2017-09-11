namespace _13_TriFunction
{
    using System;
    using System.Linq;

    public class TriFunction
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split(new char[] { ' ' }, 
                StringSplitOptions.RemoveEmptyEntries);

            foreach (var name in names)
            {
                Func<string, bool> checkCharsSum = n => name.Select(c => (int)c).Sum() >= number;

                if (checkCharsSum(name))
                {
                    Console.WriteLine(name);
                    return;
                }
            }
        }
    }
}
