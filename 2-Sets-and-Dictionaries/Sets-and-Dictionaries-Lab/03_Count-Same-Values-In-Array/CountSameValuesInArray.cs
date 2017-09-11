namespace _03_Count_Same_Values_In_Array
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CountSameValuesInArray
    {
        public static void Main()
        {
            double[] numbers = Console.ReadLine()
                .Trim()
                .Replace(',', '.')
                .Split(new char[] { ' ' }, 
                StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            SortedDictionary<double, int> numbersOccurrences = 
                new SortedDictionary<double, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (!numbersOccurrences.ContainsKey(numbers[i]))
                {
                    numbersOccurrences.Add(numbers[i], 0);
                }

                numbersOccurrences[numbers[i]] += 1;
            }

            foreach (var record in numbersOccurrences)
            {
                Console.WriteLine($"{record.Key} - {record.Value} times");
            }
        }
    }
}
