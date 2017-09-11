namespace _04_Maximal_Sum
{
    using System;
    using System.Linq;

    public class MaximalSum
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
            int[][] matrix = new int[rows][];

            for (int currRow = 0; currRow < rows; currRow++)
            {
                matrix[currRow] = Console.ReadLine()
                    .Trim()
                    .Split(new char[] { ' ' }, 
                    StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            int maxSum = int.MinValue;
            int startRow = 0;
            int startCol = 0;

            for (int currRow = 0; currRow < rows - 2; currRow++)
            {
                for (int currCol = 0; currCol < cols - 2; currCol++)
                {
                    int currSum = 
                        matrix[currRow][currCol] + matrix[currRow][currCol + 1] + 
                        matrix[currRow][currCol + 2] + matrix[currRow + 1][currCol] + 
                        matrix[currRow + 1][currCol + 1] + matrix[currRow + 1][currCol + 2] + 
                        matrix[currRow + 2][currCol] + matrix[currRow + 2][currCol + 1] + 
                        matrix[currRow + 2][currCol + 2];

                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                        startRow = currRow;
                        startCol = currCol;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int currRow = 0; currRow < 3; currRow++)
            {
                for (int currCol = 0; currCol < 3; currCol++)
                {
                    Console.Write(matrix[startRow + currRow][startCol + currCol] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
