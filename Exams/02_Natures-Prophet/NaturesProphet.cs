namespace _02_Natures_Prophet
{
    using System;
    using System.Linq;

    public class NaturesProphet
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Trim()
                .Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            int[][] garden = CreateAndFillGarden(rows, cols);

            string line = Console.ReadLine();

            while (line != "Bloom Bloom Plow")
            {
                int[] tokens = line
                    .Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int plantRow = tokens[0];
                int plantCol = tokens[1];

                BloomFlowers(garden, plantRow, plantCol);

                line = Console.ReadLine();
            }

            PrintGarden(garden);
        }

        private static void PrintGarden(int[][] garden)
        {
            for (int currRow = 0; currRow < garden.Length; currRow++)
            {
                Console.WriteLine(string.Join(" ", garden[currRow]));
            }
        }

        private static void BloomFlowers(int[][] garden, int plantRow, int plantCol)
        {
            for (int currCol = 0; currCol < garden[plantRow].Length; currCol++)
            {
                garden[plantRow][currCol] += 1;
            }

            for (int currRow = 0; currRow < garden.Length; currRow++)
            {
                garden[currRow][plantCol] += 1;
            }

            garden[plantRow][plantCol] -= 1;
        }

        private static int[][] CreateAndFillGarden(int rows, int cols)
        {
            int[][] garden = new int[rows][];

            for (int currRow = 0; currRow < rows; currRow++)
            {
                garden[currRow] = new int[cols];

                for (int currCol = 0; currCol < cols; currCol++)
                {
                    garden[currRow][currCol] = 0;
                }
            }

            return garden;
        }
    }
}
