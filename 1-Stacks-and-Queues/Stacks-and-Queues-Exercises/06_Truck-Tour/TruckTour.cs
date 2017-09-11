namespace _06_Truck_Tour
{ 
    using System;                         
    using System.Collections.Generic;
    using System.Linq;

    public class TruckTour
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int[]> pumps = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                pumps.Enqueue(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            }

            for (int i = 0; i < n; i++)
            {
                if (IsSolution(pumps, n))
                {
                    Console.WriteLine(i);
                    break;
                }

                int[] startingPump = pumps.Dequeue();
                pumps.Enqueue(startingPump);
            }
        }

        public static bool IsSolution(Queue<int[]> pumps, int n)
        {
            bool isSolution = true;
            int oil = 0;

            for (int i = 0; i < n; i++)
            {
                int[] currentPump = pumps.Dequeue();
                oil += currentPump[0] - currentPump[1];

                if (oil < 0)
                {
                    isSolution = false;
                }

                pumps.Enqueue(currentPump);
            }

            return isSolution;
        }
    }
}
