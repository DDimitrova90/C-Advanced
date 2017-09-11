namespace _04_Find_Evens_Or_Odds_1
{
    using System;            
    using System.Collections.Generic;
    using System.Linq;

    public class FindEvensOrOdds1
    {
        public static void Main()
        {
            int[] rangeBorders = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            string command = Console.ReadLine();

            int[] numbers = Enumerable
                .Range(rangeBorders[0], rangeBorders[1] - rangeBorders[0] + 1)
                .ToArray();
            Predicate<int> isEven = n => n % 2 == 0;

            PrintChosenNumbers(numbers, command, isEven);
        }

        private static void PrintChosenNumbers(int[] numbers, string command, Predicate<int> isEven)
        {
            List<int> result = new List<int>();

            foreach (var number in numbers)
            {
                if (command == "even" && isEven(number))
                {
                    result.Add(number);
                }
                else if (command == "odd" && !isEven(number))
                {
                    result.Add(number);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
