namespace _06_Target_Practice
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TargetPractice
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Trim()
                .Split(new char[] { ' ' }, 
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();         
            string snake = Console.ReadLine();
            int[] shotParameters = Console.ReadLine().
                Trim()
                .Split(new char[] { ' ' }, 
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];
            int impactRow = shotParameters[0];
            int impactCol = shotParameters[1];
            int radius = shotParameters[2];
            char[][] matrix = new char[rows][];

            FillMatrix(matrix, rows, cols, snake);

            DestroySymbolsInShotArea(matrix, rows, cols, impactRow, impactCol, radius);

            for (int currCol = 0; currCol < cols; currCol++)
            {
                FallingDownCHars(matrix, rows, currCol);
            }

            PrintMatrix(matrix, rows, cols);
        }

        public static void PrintMatrix(char[][] matrix, int rows, int cols)
        {
            for (int currRow = 0; currRow < rows; currRow++)
            {
                for (int currCol = 0; currCol < cols; currCol++)
                {
                    Console.Write(matrix[currRow][currCol]);
                }

                Console.WriteLine();
            }
        }

        public static void FallingDownCHars(char[][] matrix, int rows, int currCol)
        {
            Queue<char> queue = new Queue<char>();

            for (int currRow = rows - 1; currRow >= 0; currRow--)
            {
                if (matrix[currRow][currCol] != ' ')
                {
                    queue.Enqueue(matrix[currRow][currCol]);
                }
            }

            for (int currRow = rows - 1; currRow >= 0; currRow--)
            {
                if (queue.Count > 0)
                {
                    matrix[currRow][currCol] = queue.Dequeue();
                }
                else
                {
                    matrix[currRow][currCol] = ' ';
                }
            }
        }

        public static void DestroySymbolsInShotArea(char[][] matrix, int rows, int cols, int impactRow, int impactCol, int radius)
        {
            for (int currRow = 0; currRow < rows; currRow++)
            {
                for (int currCol = 0; currCol < cols; currCol++)
                {
                    bool isInside = IsInsideShotArea(currRow, currCol, radius, impactRow, impactCol);

                    if (isInside)
                    {
                        matrix[currRow][currCol] = ' ';
                    }
                }
            }
        }

        public static bool IsInsideShotArea(int currRow, int currCol, int radius, int impactRow, int impactCol)
        {
            return 
                ((currRow - impactRow) * (currRow - impactRow) + 
                (currCol - impactCol) * (currCol - impactCol)) <= radius * radius;
        }

        public static void FillMatrix(char[][] matrix, int rows, int cols, string snake)
        {
            for (int currRow = 0; currRow < rows; currRow++)
            {
                matrix[currRow] = new char[cols];
            }

            int remainder = (rows - 1) % 2;
            int i = 0;

            for (int currRow = rows - 1; currRow >= 0; currRow--)
            {
                if (currRow % 2 == remainder)
                {
                    for (int currCol = cols - 1; currCol >= 0; currCol--)
                    {
                        matrix[currRow][currCol] = snake[i];
                        i++;

                        if (i > snake.Length - 1)
                        {
                            i = 0;
                        }
                    }
                }
                else
                {
                    for (int currCol = 0; currCol < cols; currCol++)
                    {
                        matrix[currRow][currCol] = snake[i];
                        i++;

                        if (i > snake.Length - 1)
                        {
                            i = 0;
                        }
                    }
                }
            }
        }
    }
}
