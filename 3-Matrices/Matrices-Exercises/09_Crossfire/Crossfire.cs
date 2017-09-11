namespace _09_Crossfire
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Crossfire
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
            List<List<int>> matrix = new List<List<int>>();

            FillMatrix(matrix, rows, cols);

            string command = Console.ReadLine();

            while (command != "Nuke it from orbit")
            {
                int[] commandArgs = command
                    .Split(new char[] { ' ' }, 
                    StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int targetRow = commandArgs[0];
                int targetCol = commandArgs[1];
                int radius = commandArgs[2];

                bool hasMarkedCells = false;

                hasMarkedCells = MarkCellsForDestoying(matrix, targetRow, targetCol, radius, hasMarkedCells);

                DestroyTargetCells(matrix, hasMarkedCells);

                command = Console.ReadLine();
            }

            PrintMatrix(matrix);
        }

        public static void PrintMatrix(List<List<int>> matrix)
        {
            for (int currRow = 0; currRow < matrix.Count; currRow++)
            {
                Console.WriteLine(string.Join(" ", matrix[currRow]));
            }
        }

        public static void DestroyTargetCells(List<List<int>> matrix, bool hasMarkedCells)
        {
            if (hasMarkedCells)
            {
                for (int currRow = 0; currRow < matrix.Count; currRow++)
                {
                    if (matrix[currRow].Contains(0))
                    {
                        List<int> newRow = new List<int>();

                        for (int currCol = 0; currCol < matrix[currRow].Count; currCol++)
                        {
                            int currElement = matrix[currRow][currCol];

                            if (currElement != 0)
                            {
                                newRow.Add(currElement);
                            }
                        }

                        if (newRow.Count > 0)
                        {
                            matrix[currRow] = newRow;
                        }
                        else
                        {
                            matrix.RemoveAt(currRow);
                            currRow--;
                        }
                    }
                }
            }
        }

        public static bool MarkCellsForDestoying(List<List<int>> matrix, int targetRow, int targetCol, int radius, bool hasMarkedCells)
        {
            if (targetRow >= 0 && targetRow < matrix.Count)
            {
                for (int currCol = Math.Max(0, targetCol - radius); currCol <= Math.Min(targetCol + radius, matrix[targetRow].Count - 1); currCol++)
                {
                    matrix[targetRow][currCol] = 0;
                    hasMarkedCells = true;
                }
            }

            if (targetCol >= 0)
            {
                for (int currRow = Math.Max(0, targetRow - radius); currRow <= Math.Min(targetRow + radius, matrix.Count - 1); currRow++)
                {
                    if (targetCol < matrix[currRow].Count)
                    {
                        matrix[currRow][targetCol] = 0;
                        hasMarkedCells = true;
                    }
                }
            }

            return hasMarkedCells;
        }

        public static void FillMatrix(List<List<int>> matrix, int rows, int cols)
        {
            int number = 1;

            for (int currRow = 0; currRow < rows; currRow++)
            {
                matrix.Add(new List<int>());

                for (int currCol = 0; currCol < cols; currCol++)
                {
                    matrix[currRow].Add(number);
                    number++;
                }
            }
        }
    }
}
