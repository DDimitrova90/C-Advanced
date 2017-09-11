namespace _04_Find_Evens_Or_Odds
{
    using System;
    using System.Linq;

    public class FindEvensOrOdds
    {
        public static void Main()
        {
            int[] bounds = Console.ReadLine()
                .Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string command = Console.ReadLine();

            int lowerBound = bounds[0];
            int upperBound = bounds[1];

            Predicate <int> checkEvenOrOdd = n => n % 2 == 0;

            for (int i = lowerBound; i <= upperBound; i++)
            {
                if (command == "even" && checkEvenOrOdd(i))
                {
                    Console.Write(i + " ");
                }
                else if (command == "odd" && !checkEvenOrOdd(i))
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
