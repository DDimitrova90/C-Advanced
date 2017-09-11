namespace _05_Calculate_Sequence_With_Queue
{
    using System;
    using System.Collections.Generic;

    public class CalculateSequenceWithQueue
    {
        public static void Main()
        {
            long n = long.Parse(Console.ReadLine());

            Queue<long> queue = new Queue<long>();
            List<long> result = new List<long>();
            queue.Enqueue(n);
            result.Add(n);

            while (queue.Count < 50)
            {
                long currentNumber = queue.Dequeue();

                long firstNumber = currentNumber + 1;
                long secondNumber = (2 * currentNumber) + 1;
                long thirdNumber = currentNumber + 2;

                queue.Enqueue(firstNumber);
                queue.Enqueue(secondNumber);
                queue.Enqueue(thirdNumber);

                result.Add(firstNumber);
                result.Add(secondNumber);
                result.Add(thirdNumber);
            }

            for (int i = 0; i < 50; i++)
            {
                Console.Write(result[i] + " ");
            }
        }
    }
}
