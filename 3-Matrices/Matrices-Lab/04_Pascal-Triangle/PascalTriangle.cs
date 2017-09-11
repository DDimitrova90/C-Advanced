namespace _04_Pascal_Triangle
{
    using System;

    public class PascalTriangle
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            long[][] matrix = new long[rows][];
            int cols = 1;

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new long[cols]; 

                for (int col = 0; col < cols; col++)
                {
                    if (col == 0)
                    {
                        matrix[row][col] = 1;
                    }
                    else if (row > 0 && col < cols - 1)
                    {
                        matrix[row][col] = matrix[row - 1][col - 1] + matrix[row - 1][col];
                    }
                    else if (col == cols - 1)
                    {
                        matrix[row][col] = 1;
                    }
                }

                cols++;
            }

            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row]));
            }
        }
    }
}
