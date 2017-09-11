namespace _02_Jedi_Galaxy
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class JediGalaxy
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Trim()
                .Split(new char[] { ' ', '\t', '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            int[][] matrix = CreateAndFillMatrix(rows, cols);
            BigInteger totalSum = 0;

            string line = Console.ReadLine();

            while (line != "Let the Force be with you")
            {
                int[] ivoForce = line
                    .Trim()
                    .Split(new char[] { ' ', '\t', '\r', '\n' },
                    StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int[] evilForce = Console.ReadLine()
                    .Trim()
                    .Split(new char[] { ' ', '\t', '\r', '\n' },
                    StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int ivoRow = ivoForce[0];
                int ivoCol = ivoForce[1];
                int evilRow = evilForce[0];
                int evilCol = evilForce[1];

                DestroyStars(matrix, evilRow, evilCol);
                totalSum += CollectStars(matrix, ivoRow, ivoCol);

                line = Console.ReadLine();
            }

            Console.WriteLine(totalSum);
        }

        private static BigInteger CollectStars(int[][] matrix, int ivoRow, int ivoCol)
        {
            BigInteger currentSum = 0;

            for (int currRow = ivoRow; currRow >= 0; currRow--)
            {
                if (ivoCol >= 0 && ivoCol < matrix[0].Length && currRow < matrix.Length)
                {
                    currentSum += matrix[currRow][ivoCol];
                }

                ivoCol++;
            }

            return currentSum;
        }

        private static void DestroyStars(int[][] matrix, int evilRow, int evilCol)
        {
            for (int currRow = evilRow; currRow >= 0; currRow--)
            {
                if (evilCol >= 0 && evilCol < matrix[0].Length && currRow < matrix.Length)
                {
                    matrix[currRow][evilCol] = 0;
                }

                evilCol--;
            }
        }

        private static int[][] CreateAndFillMatrix(int rows, int cols)
        {
            int[][] matrix = new int[rows][];
            int counter = 0;

            for (int currRow = 0; currRow < rows; currRow++)
            {
                matrix[currRow] = new int[cols];

                for (int currCol = 0; currCol < cols; currCol++)
                {
                    matrix[currRow][currCol] = counter;
                    counter++;
                }
            }

            return matrix;
        }
    }
}