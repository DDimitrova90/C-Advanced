namespace _03_Squares_In_Matrix
{
    using System;
    using System.Linq;

    public class SquaresInMatrix
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

            int squareMatrixesCount = 0;
            char[][] matrix = new char[rows][];

            for (int currRow = 0; currRow < rows; currRow++)
            {
                matrix[currRow] = Console.ReadLine()
                    .Trim()
                    .Split(new char[] { ' ' }, 
                    StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
            }

            for (int currRow = 0; currRow < rows - 1; currRow++)
            {
                for (int currCol = 0; currCol < cols - 1; currCol++)
                {
                    if (matrix[currRow][currCol] == matrix[currRow][currCol + 1] && matrix[currRow + 1][currCol] == matrix[currRow + 1][currCol + 1] && matrix[currRow][currCol] == matrix[currRow + 1][currCol + 1])
                    {
                        squareMatrixesCount++;
                    }
                }
            }

            Console.WriteLine(squareMatrixesCount);
        }
    }
}
