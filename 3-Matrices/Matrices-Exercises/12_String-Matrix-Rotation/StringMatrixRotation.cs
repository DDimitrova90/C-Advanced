namespace _12_String_Matrix_Rotation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StringMatrixRotation
    {
        public static void Main()
        {
            string[] inputArgs = Console.ReadLine()
                .Trim()
                .Split(new char[] { '(', ')' }, 
                StringSplitOptions.RemoveEmptyEntries);
            int degree = int.Parse(inputArgs[1]);
            degree /= 90;

            List<List<char>> matrix = new List<List<char>>();

            int maxLength = FillMatrix(matrix);

            int rotations = degree % 4;

            if (rotations == 0)
            {
                PrintMatrix(matrix);
            }
            else if (rotations == 1)
            {
                List<List<char>> rotatedMatrix = RotateMatrixOneTime(matrix, maxLength);
                PrintMatrix(rotatedMatrix);
            }
            else if (rotations == 2)
            {
                List<List<char>> rotatedMatrix = RotateMatrixTwoTimes(matrix);
                PrintMatrix(rotatedMatrix);
            }
            else if (rotations == 3)
            {
                List<List<char>> rotatedMatrix = RotateMatrixThreeTimes(matrix, maxLength);
                PrintMatrix(rotatedMatrix);
            }
        }

        public static List<List<char>> RotateMatrixThreeTimes(List<List<char>> matrix, int maxLength)
        {
            List<List<char>> rotatedMatrix = new List<List<char>>();
            int row = 0;

            for (int currCol = maxLength - 1; currCol >= 0; currCol--)
            {
                rotatedMatrix.Add(new List<char>());

                for (int currRow = 0; currRow < matrix.Count(); currRow++)
                {
                    rotatedMatrix[row].Add(matrix[currRow][currCol]);
                }

                row++;
            }

            return rotatedMatrix;
        }

        public static List<List<char>> RotateMatrixTwoTimes(List<List<char>> matrix)
        {
            List<List<char>> rotatedMatrix = new List<List<char>>();
            int row = 0;

            for (int currRow = matrix.Count() - 1; currRow >= 0; currRow--)
            {     
                rotatedMatrix.Add(new List<char>());

                for (int currCol = matrix[currRow].Count() - 1; currCol >= 0; currCol--)
                {
                    rotatedMatrix[row].Add(matrix[currRow][currCol]);
                }

                row++;
            }

            return rotatedMatrix;
        }

        public static List<List<char>> RotateMatrixOneTime(List<List<char>> matrix, int maxLength)
        {
            List<List<char>> rotatedMatrix = new List<List<char>>();
            int row = 0;

            for (int currCol = 0; currCol < maxLength; currCol++)
            {
                rotatedMatrix.Add(new List<char>());

                for (int currRow = matrix.Count() - 1; currRow >= 0; currRow--)
                {
                    char elementToAdd = matrix[currRow][currCol];
                    rotatedMatrix[row].Add(elementToAdd);
                }

                row++;
            }

            return rotatedMatrix;
        }

        public static void PrintMatrix(List<List<char>> matrix)
        {
            for (int currRow = 0; currRow < matrix.Count(); currRow++)
            {
                Console.WriteLine(string.Join("", matrix[currRow]));
            }
        }

        public static int FillMatrix(List<List<char>> matrix)
        {
            string line = Console.ReadLine();
            int maxLength = int.MinValue;

            while (line != "END")
            {
                matrix.Add(line.ToList());

                if (line.Count() > maxLength)
                {
                    maxLength = line.Count();
                }

                line = Console.ReadLine();
            }

            for (int currRow = 0; currRow < matrix.Count(); currRow++)
            {
                if (matrix[currRow].Count() < maxLength)
                {
                    int elementToAdd = maxLength - matrix[currRow].Count();
                    for (int i = 0; i < elementToAdd; i++)
                    {
                        matrix[currRow].Add(' ');
                    }
                }
            }

            return maxLength;
        }
    }
}
