namespace _02_Parking_System
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ParkingSystem
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            Dictionary<int, HashSet<int>> parking = 
                new Dictionary<int, HashSet<int>>();

            string line = Console.ReadLine();

            while (line != "stop")
            {
                int[] lineArgs = line
                    .Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int entryRow = lineArgs[0];
                int targetRow = lineArgs[1];
                int targetCol = lineArgs[2];
                int moves = 0;
                bool isPlaceOccupied = IsPlaceOccupied(targetRow, targetCol, parking);

                if (!isPlaceOccupied)
                {
                    OccupyPlace(parking, targetRow, targetCol);
                    moves = Math.Abs(targetRow - entryRow) + targetCol + 1;
                    Console.WriteLine(moves);
                }
                else
                {
                    targetCol = TryFindEmptyPlace(parking[targetRow], targetCol, cols);

                    if (targetCol == 0)
                    {
                        Console.WriteLine($"Row {targetRow} full");
                    }
                    else
                    {
                        OccupyPlace(parking, targetRow, targetCol);
                        moves = Math.Abs(targetRow - entryRow) + targetCol + 1;
                        Console.WriteLine(moves);
                    }
                }

                line = Console.ReadLine();
            }
        }

        private static int TryFindEmptyPlace(HashSet<int> targetRow, int targetCol, int cols)
        {
            int currCol = 0;
            int minDistance = int.MaxValue;

            if (targetRow.Count == cols - 1)
            {
                return currCol;
            }
            else
            {
                for (int i = 1; i < cols; i++)
                {
                    int currDistance = Math.Abs(targetCol - i);

                    if (!targetRow.Contains(i) && currDistance < minDistance)
                    {
                        currCol = i;
                        minDistance = currDistance;
                    }
                }

                return currCol;
            }
        }

        private static void OccupyPlace(Dictionary<int, HashSet<int>> parking, int targetRow, int targetCol)
        {
            if (!parking.ContainsKey(targetRow))
            {
                parking.Add(targetRow, new HashSet<int>());
            }

            parking[targetRow].Add(targetCol);
        }

        private static bool IsPlaceOccupied(int targetRow, int targetCol, Dictionary<int, HashSet<int>> parking)
        {
            if (parking.ContainsKey(targetRow) && parking[targetRow].Contains(targetCol))
            {
                return true;
            }

            return false;
        }
    }
}
