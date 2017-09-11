namespace _05_Rubiks_Matrix_3
{
    using System;     
    using System.Linq;

    public class RubiksMatrix3
    {
        public static void Main()
        {
            var size = Console.ReadLine().Trim().Split(' ').ToArray();
            int rows = int.Parse(size[0]);
            int cols = int.Parse(size[1]);
            int[,] matrix = new int[rows, cols];
            int n = int.Parse(Console.ReadLine().Trim());

            int counter = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    counter++;
                    matrix[i, j] = counter;
                }
            }

            for (int command = 0; command < n; command++)
            {
                var tokens = Console.ReadLine().Trim().Split();
                int rcn = int.Parse(tokens[0]);
                string direction = tokens[1].Trim();
                long moves = int.Parse(tokens[2]);

                if (direction == "left" || direction == "right")
                {
                    moves %= cols;
                    if (direction == "right") moves = cols - moves;
                    for (int m = 0; m < moves % cols; m++)
                    {
                        for (int i = 0; i < cols - 1; i++)
                        {
                            int temp = matrix[rcn, i];
                            matrix[rcn, i] = matrix[rcn, i + 1];
                            matrix[rcn, i + 1] = temp;
                        }
                    }
                }
                else
                {
                    moves %= rows;
                    if (direction == "down") moves = rows - moves;
                    for (int m = 0; m < moves % rows; m++)
                    {
                        for (int i = 0; i < rows - 1; i++)
                        {
                            int temp = matrix[i, rcn];
                            matrix[i, rcn] = matrix[i + 1, rcn];
                            matrix[i + 1, rcn] = temp;
                        }
                    }
                }
            }

            int[] swaps = new int[rows * cols];
            counter = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    swaps[counter] = matrix[i, j];
                    counter++;
                }
            }

            for (int i = 0; i < rows * cols; i++)
            {
                if (swaps[i] == i + 1)
                {
                    Console.WriteLine("No swap required");
                }
                else
                {
                    int index = Array.IndexOf(swaps, i + 1);
                    int r1 = i / cols;
                    int c1 = i % cols;
                    int r2 = index / cols;
                    int c2 = index % cols;

                    int temp = swaps[i];
                    swaps[i] = swaps[index];
                    swaps[index] = temp;

                    Console.WriteLine($"Swap ({r1}, {c1}) with ({r2}, {c2})");
                }
            }
        }
    }
}
