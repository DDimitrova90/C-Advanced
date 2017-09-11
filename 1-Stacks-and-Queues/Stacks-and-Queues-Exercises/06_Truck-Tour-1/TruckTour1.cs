namespace _06_Truck_Tour_1
{
    using System;          
    using System.Collections.Generic;
    using System.Linq;

    public class TruckTour1
    {
        public static void Main()
        {
            int petrolStationsNum = int.Parse(Console.ReadLine());
            Queue<int[]> petrolStations = new Queue<int[]>();

            for (int i = 0; i < petrolStationsNum; i++)
            {
                int[] petrolStation = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                petrolStations.Enqueue(petrolStation);
            }

            bool reachFinal = false;
            int startingIndex = 0;

            while (!reachFinal)
            {
                int totalPetrol = 0;

                for (int i = 0; i <= petrolStationsNum; i++)
                {
                    if (i == petrolStationsNum)
                    {
                        reachFinal = true;
                        break;
                    }

                    int[] petrolStation = petrolStations.Dequeue();
                    petrolStations.Enqueue(petrolStation);

                    int liters = petrolStation[0];
                    int distanceToNext = petrolStation[1];

                    totalPetrol += liters - distanceToNext;

                    if (totalPetrol < 0)
                    {
                        startingIndex += i + 1;
                        break;
                    }
                }
            }

            Console.WriteLine(startingIndex);
        }
    }
}
