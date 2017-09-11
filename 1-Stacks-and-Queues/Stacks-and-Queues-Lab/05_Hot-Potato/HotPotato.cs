namespace _05_Hot_Potato
{
    using System;
    using System.Collections.Generic;

    public class HotPotato
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>(input);

            while (queue.Count > 1)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    string passer = queue.Dequeue();
                    queue.Enqueue(passer);
                }

                Console.WriteLine($"Removed {queue.Dequeue()}");
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");     
        }
    }
}
