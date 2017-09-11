namespace _03_Maximum_Element_1
{
    using System;              
    using System.Collections.Generic;
    using System.Linq;

    public class MaximumElement1
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> numbers = new Stack<int>();
            Stack<int> maxNumbers = new Stack<int>();
            int maxValue = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                int[] query = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (query[0] == 1)
                {
                    numbers.Push(query[1]);

                    if (query[1] > maxValue)
                    {
                        maxValue = query[1];
                        maxNumbers.Push(query[1]);
                    }
                }
                else if (query[0] == 2)
                {
                    if (numbers.Pop() == maxValue)
                    {
                        maxNumbers.Pop();

                        if (maxNumbers.Count != 0)
                        {
                            maxValue = maxNumbers.Peek();
                        }
                        else
                        {
                            maxValue = int.MinValue;
                        }
                    }
                }
                else if (query[0] == 3)
                {
                    Console.WriteLine(maxValue);
                }
            }
        }
    }
}
