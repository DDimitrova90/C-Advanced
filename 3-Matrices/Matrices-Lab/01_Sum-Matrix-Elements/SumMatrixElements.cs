namespace _01_Sum_Matrix_Elements
{
    using System;
    using System.Linq;

    public class SumMatrixElements
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Trim()
                .Split(new char[] { ' ', ',' }, 
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            int sum = 0;

            for (int i = 0; i < rows; i++)
            {
                int[] elements = Console.ReadLine()
                    .Trim()
                    .Split(new char[] { ',', ' ' }, 
                    StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                foreach (var element in elements)
                {
                    sum += element;
                }
            }

            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);
        }
    }
}
