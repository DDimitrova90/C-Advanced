namespace _01_Matrix_Of_Palindromes
{
    using System;
    using System.Linq;

    public class MatrixOfPalindromes
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

            string[][] matrix = new string[rows][];

            for (int currRow = 0; currRow < rows; currRow++)
            {
                matrix[currRow] = new string[cols];

                for (int currCol = 0; currCol < cols; currCol++)
                {
                    string currString = 
                        "" + (char)(currRow + 97) + 
                        (char)(currRow + currCol + 97) + 
                        (char)(currRow + 97);

                    matrix[currRow][currCol] = currString;
                }
            }

            for (int currRow = 0; currRow < rows; currRow++)
            {
                Console.WriteLine(string.Join(" ", matrix[currRow]));
            }
        }
    }
}
