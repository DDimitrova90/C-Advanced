namespace _02_Maximum_Sum_Of_2x2_Submatrix
{
    using System;
    using System.Linq;

    public class MaximumSumOf2x2Submatrix
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Trim()
                .Split(new char[] { ',', ' ' }, 
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            int[][] matix = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                matix[i] = new int[cols];

                int[] elements = Console.ReadLine()
                    .Trim()
                    .Split(new char[] { ' ', ',' }, 
                    StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matix[i][j] = elements[j];
                }    
            }

            int maxSum = int.MinValue;
            int startRow = -1;
            int startCol = -1;

            for (int currRow = 0; currRow < rows - 1; currRow++)
            {
                for (int currCol = 0; currCol < cols - 1; currCol++)
                {
                    int sum = matix[currRow][currCol] + matix[currRow][currCol + 1] +
                        matix[currRow + 1][currCol] + matix[currRow + 1][currCol + 1];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        startRow = currRow;
                        startCol = currCol;
                    }
                }
            }

            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 2; col++)
                {
                    Console.Write(matix[startRow + row][startCol + col] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(maxSum);
        }
    }
}
