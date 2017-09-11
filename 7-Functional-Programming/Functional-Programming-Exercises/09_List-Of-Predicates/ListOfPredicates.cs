namespace _09_List_Of_Predicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ListOfPredicates
    {
        public static void Main()
        {
            int rangeEnd = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Distinct()
                .ToArray();

            List<Predicate<int>> predicates = new List<Predicate<int>>();

            foreach (var number in numbers)
            {
                Predicate<int> checkIfDivisible = n => n % number == 0;
                predicates.Add(checkIfDivisible);
            }

            

            for (int i = 1; i <= rangeEnd; i++)
            {
                bool isDivisible = true;

                foreach (var predicate in predicates)
                {
                    if (!predicate(i))
                    {
                        isDivisible = false;
                    }
                }

                if (isDivisible)
                {
                    Console.Write(i + " ");
                }
            }

            Console.WriteLine();
        }
    }
}
