namespace _05_Rubiks_Matrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RubiksMatrix
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

            FillMatrix(matrix, rows, cols);

            ExecuteCommands(rows, cols, matrix);

            RearrangeMatrix(rows, cols, matrix);
        }

        public static void RearrangeMatrix(int rows, int cols, int[][] matrix)
        {
            int number = 1;

            for (int currRow = 0; currRow < rows; currRow++)
            {
                for (int currCol = 0; currCol < cols; currCol++)
                {
                    if (matrix[currRow][currCol] == number)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        int swapedRow = 0;
                        int swapedCol = 0;

                        for (int row = currRow; row < rows; row++)
                        {
                            for (int col = 0; col < cols; col++)
                            {
                                if (matrix[row][col] == number)
                                {
                                    swapedRow = row;
                                    swapedCol = col;
                                    int tempElement = matrix[row][col];
                                    matrix[row][col] = matrix[currRow][currCol];
                                    matrix[currRow][currCol] = tempElement; 
                                }
                            }
                        }

                        Console.WriteLine($"Swap ({currRow}, {currCol}) with ({swapedRow}, {swapedCol})");
                    }

                    number++;
                }
            }
        }

        public static void ExecuteCommands(int rows, int cols, int[][] matrix)
        {
            int commandsNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsNumber; i++)
            {
                string[] commandArgs = Console.ReadLine()
                    .Trim()
                    .Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                int rowOrCol = int.Parse(commandArgs[0]);
                string direction = commandArgs[1];
                long moves = long.Parse(commandArgs[2]);

                if (direction == "right")
                {
                    SwapMatrixRowRight(matrix, rows, cols, rowOrCol, moves);
                }
                else if (direction == "left")
                {
                    SwapMatrixRowLeft(matrix, rows, cols, rowOrCol, moves);
                }
                else if (direction == "up")
                {
                    SwapMatrixColUp(matrix, rows, cols, rowOrCol, moves);
                }
                else if (direction == "down")
                {
                    SwapMatrixColDown(matrix, rows, cols, rowOrCol, moves);
                }
            }
        }

        public static void SwapMatrixColDown(int[][] matrix, int rows, int cols, int rowOrCol, long moves)
        {
            Queue<int> queue = new Queue<int>();

            for (int currRow = rows - 1; currRow >= 0; currRow--)
            {
                queue.Enqueue(matrix[currRow][rowOrCol]);
            }

            for (int i = 0; i < moves % rows; i++)
            {
                int number = queue.Dequeue();
                queue.Enqueue(number);
            }

            for (int currRow = rows - 1; currRow >= 0; currRow--)
            {
                matrix[currRow][rowOrCol] = queue.Dequeue();
            }
        }

        public static void SwapMatrixColUp(int[][] matrix, int rows, int cols, int rowOrCol, long moves)
        {
            Queue<int> queue = new Queue<int>();

            for (int currRow = 0; currRow < rows; currRow++)
            {
                queue.Enqueue(matrix[currRow][rowOrCol]);
            }

            for (int i = 0; i < moves % rows; i++)
            {
                int number = queue.Dequeue();
                queue.Enqueue(number);
            }

            for (int currRow = 0; currRow < rows; currRow++)
            {
                matrix[currRow][rowOrCol] = queue.Dequeue();
            }
        }

        public static void SwapMatrixRowLeft(int[][] matrix, int rows, int cols, int rowOrCol, long moves)
        {
            Queue<int> queue = new Queue<int>();

            for (int currCol = 0; currCol < cols; currCol++)
            {
                queue.Enqueue(matrix[rowOrCol][currCol]);
            }

            for (int i = 0; i < moves % cols; i++)
            {
                int number = queue.Dequeue();
                queue.Enqueue(number);
            }

            for (int currCol = 0; currCol < cols; currCol++)
            {
                matrix[rowOrCol][currCol] = queue.Dequeue();
            }
        }

        public static void SwapMatrixRowRight(int[][] matrix, int rows, int cols, int rowOrCol, long moves)
        {
            Queue<int> queue = new Queue<int>();

            for (int currCol = cols - 1; currCol >= 0; currCol--)
            {
                queue.Enqueue(matrix[rowOrCol][currCol]);
            }

            for (int i = 0; i < moves % cols; i++)
            {
                int number = queue.Dequeue();
                queue.Enqueue(number);
            }

            for (int currCol = cols - 1; currCol >= 0; currCol--)
            {
                matrix[rowOrCol][currCol] = queue.Dequeue();
            }
        }

        public static void FillMatrix(int[][] matrix, int rows, int cols)
        {
            int number = 1;

            for (int currRow = 0; currRow < rows; currRow++)
            {
                matrix[currRow] = new int[cols];

                for (int currCol = 0; currCol < cols; currCol++)
                {
                    matrix[currRow][currCol] = number;
                    number++;
                }
            }
        }
    }
}
