namespace _02_Diagonal_Difference
{
    using System;
    using System.Linq;

    public class DiagonalDifference
    {
        public static void Main()
        {
            int squareSize = int.Parse(Console.ReadLine());
            int[][] matrix = new int[squareSize][];

            for (int currRow = 0; currRow < squareSize; currRow++)
            {
                matrix[currRow] = Console.ReadLine()
                    .Trim()
                    .Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            int primaryDiagonal = 0;
            int secondaryDiagonal = 0;
            int currCol = squareSize - 1;

            for (int currRow = 0; currRow < squareSize; currRow++)
            {
                primaryDiagonal += matrix[currRow][currRow];
                secondaryDiagonal += matrix[currRow][currCol];
                currCol--;
            }

            Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));
        }
    }
}
