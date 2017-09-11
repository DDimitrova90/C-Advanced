namespace _07_Lego_Blocks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LegoBlocks
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] firstJaggedArray = new int[rows][];
            int[][] secondJaggedArray = new int[rows][];

            FillJaggedArrays(firstJaggedArray, secondJaggedArray, rows);

            ReverseJaggedArray(secondJaggedArray, rows);

            bool hasMatch = CheckArraysIfMatch(firstJaggedArray, secondJaggedArray, rows);

            if (!hasMatch)
            {
                int totalCells = CountTotalCells(firstJaggedArray, secondJaggedArray, rows);
                Console.WriteLine($"The total number of cells is: {totalCells}");
            }
            else
            {
                PrintNewMatrix(firstJaggedArray, secondJaggedArray, rows);
            }
        }

        public static void PrintNewMatrix(int[][] firstJaggedArray, int[][] secondJaggedArray, int rows)
        {
            for (int currRow = 0; currRow < rows; currRow++)
            {
                Console.WriteLine(
                    "[" + 
                    string.Join(", ", firstJaggedArray[currRow]
                    .Concat(secondJaggedArray[currRow])) + 
                    "]");
            }
        }

        public static int CountTotalCells(int[][] firstJaggedArray, int[][] secondJaggedArray, int rows)
        {
            int totalCells = 0;

            for (int currRow = 0; currRow < rows; currRow++)
            {
                totalCells += firstJaggedArray[currRow].Length + secondJaggedArray[currRow].Length;
            }

            return totalCells;
        }

        public static bool CheckArraysIfMatch(int[][] firstJaggedArray, int[][] secondJaggedArray, int rows)
        {
            int firstRowTotalCols = firstJaggedArray[0].Length + secondJaggedArray[0].Length;
            bool hasMatch = true;

            for (int currRow = 1; currRow < rows; currRow++)
            {
                int currentTotalCols = firstJaggedArray[currRow].Length + secondJaggedArray[currRow].Length;

                if (firstRowTotalCols != currentTotalCols)
                {
                    hasMatch = false;
                    break;
                }
            }

            return hasMatch;
        }

        public static void ReverseJaggedArray(int[][] secondJaggedArray, int rows)
        {
            for (int currRow = 0; currRow < rows; currRow++)
            {
                Stack<int> stack = new Stack<int>(secondJaggedArray[currRow]);

                for (int currCol = 0; currCol < secondJaggedArray[currRow].Length; currCol++)
                {
                    secondJaggedArray[currRow][currCol] = stack.Pop();
                }
            }
        }

        public static void FillJaggedArrays(int[][] firstJaggedArray, int[][] secondJaggedArray, int rows)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int currRow = 0; currRow < rows; currRow++)
                {
                    if (i == 0)
                    {
                        firstJaggedArray[currRow] = Console.ReadLine()
                                                .Trim()
                                                .Split(new char[] { ' ' },
                                                StringSplitOptions.RemoveEmptyEntries)
                                                .Select(int.Parse)
                                                .ToArray();
                    }
                    else
                    {
                        secondJaggedArray[currRow] = Console.ReadLine()
                                              .Trim()
                                              .Split(new char[] { ' ' },
                                              StringSplitOptions.RemoveEmptyEntries)
                                              .Select(int.Parse)
                                              .ToArray();
                    }
                }
            }
        }
    }
}
