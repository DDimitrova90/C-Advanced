namespace _06_Math_Potato
{
    using System;
    using System.Collections.Generic;  

    public class MathPotato
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>(input);
            int cycle = 1;

            while (queue.Count > 1)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    string passer = queue.Dequeue();
                    queue.Enqueue(passer);
                }

                if (IsPrime(cycle))
                {
                    Console.WriteLine($"Prime {queue.Peek()}");
                }
                else
                {
                    Console.WriteLine($"Removed {queue.Dequeue()}");
                }

                cycle++;
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }

        public static bool IsPrime(int cycle)
        {
            bool isPrime = true;

            if (cycle < 2)
            {
                isPrime = false;
            }
            else
            {
                for (int i = 2; i <= Math.Sqrt(cycle); i++)
                {
                    if (cycle % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
            }

            return isPrime;
        }
    }
}
