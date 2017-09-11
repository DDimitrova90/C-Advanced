namespace _04_Basic_Queue_Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BasicQueueOperations
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

            Queue<int> queue = new Queue<int>();
            int elementsToAdd = args[0];
            int elementsToRemove = args[1];
            int elementToCheck = args[2];

            for (int i = 0; i < elementsToAdd; i++)
            {
                queue.Enqueue(elements[i]);
            }

            int availableElements = Math.Min(elementsToRemove, queue.Count);

            for (int i = 0; i < availableElements; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count > 0)
            {
                if (queue.Contains(elementToCheck))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
