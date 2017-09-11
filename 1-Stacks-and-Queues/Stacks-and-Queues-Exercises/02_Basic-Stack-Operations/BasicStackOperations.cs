namespace _02_Basic_Stack_Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BasicStackOperations
    {
        public static void Main()
        {
            int[] args = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int[] elements = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>();
            int elementsToPush = args[0];
            int elementsToPop = args[1];
            int elementToCheck = args[2];

            for (int i = 0; i < elements.Length; i++)
            {
                stack.Push(elements[i]);
            }

            int availableElementsToPop = Math.Min(elementsToPop, stack.Count);

            for (int i = 0; i < availableElementsToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                if (stack.Contains(elementToCheck))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    int smallestNumber = stack.Min();
                    Console.WriteLine(smallestNumber);
                }
            }
        }
    }
}
