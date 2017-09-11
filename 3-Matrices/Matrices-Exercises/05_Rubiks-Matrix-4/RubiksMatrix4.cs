namespace _05_Rubiks_Matrix_4
{
    using System;    
    using System.Linq;

    public class RubiksMatrix4
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            int[][] matrix = new int[rows][];
            int count = 1;

            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                matrix[rowIndex] = new int[cols];

                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    matrix[rowIndex][colIndex] = count;
                    count++;
                }
            }

            int commandsNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsNum; i++)
            {
                string[] commandTokens = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int rcIndex = int.Parse(commandTokens[0]);
                string direction = commandTokens[1];
                int moves = int.Parse(commandTokens[2]);

                switch (direction)
                {
                    case "up":
                        MoveCol(matrix, rcIndex, moves);
                        break;
                    case "down":
                        MoveCol(matrix, rcIndex, rows - moves % rows);
                        break;
                    case "right":
                        MoveRow(matrix, rcIndex, cols - moves % cols);
                        break;
                    case "left":
                        MoveRow(matrix, rcIndex, moves);
                        break;
                }
            }

            int element = 1;

            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    if (matrix[rowIndex][colIndex] == element)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        for (int r = 0; r < rows; r++)
                        {
                            for (int c = 0; c < cols; c++)
                            {
                                if (matrix[r][c] == element)
                                {
                                    int currentElement = matrix[rowIndex][colIndex];
                                    matrix[rowIndex][colIndex] = matrix[r][c];
                                    matrix[r][c] = currentElement;
                                    Console.WriteLine($"Swap ({rowIndex}, {colIndex}) with ({r}, {c})");
                                    break;
                                }
                            }
                        }
                    }

                    element++;
                } 
            }
        }

        public static void MoveRow(int[][] matrix, int rcIndex, int moves)
        {
            int[] temp = new int[matrix[0].Length];

            for (int colIndex = 0; colIndex < matrix[0].Length; colIndex++)
            {
                temp[colIndex] = matrix[rcIndex][(colIndex + moves) % matrix[0].Length];
            }

            matrix[rcIndex] = temp;
        }

        public static void MoveCol(int[][] matrix, int rcIndex, int moves)
        {
            int[] temp = new int[matrix.Length];

            // Move column up
            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                temp[rowIndex] = matrix[(rowIndex + moves) % matrix.Length][rcIndex];
            }

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                matrix[rowIndex][rcIndex] = temp[rowIndex];
            }
        }
    }
}
