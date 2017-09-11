namespace _02_Sets_Of_Elements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SetsOfElements
    {
        public static void Main()
        {
            int[] args = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < args[0]; i++)
            {
                int number = int.Parse(Console.ReadLine());

                firstSet.Add(number);
            }

            for (int i = 0; i < args[1]; i++)
            {
                int number = int.Parse(Console.ReadLine());

                secondSet.Add(number);
            }

            foreach (var number in firstSet)
            {
                if (secondSet.Contains(number))
                {
                    Console.Write(number + " ");
                }
            }

            Console.WriteLine();
        }
    }
}
