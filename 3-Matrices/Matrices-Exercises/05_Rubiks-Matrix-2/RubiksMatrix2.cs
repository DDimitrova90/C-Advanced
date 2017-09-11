namespace _05_Rubiks_Matrix_2
{
    using System;   
    using System.Linq;

    public class RubiksMatrix2
    {
        public static void Main()
        {
            int[] matrixSize = Console.ReadLine().Split(new[] { ' ', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int commandCount = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize[0], matrixSize[1]];
            fillMatrix(matrixSize, matrix);
            int[,] matrixC = new int[matrixSize[0], matrixSize[1]];
            fillMatrix(matrixSize, matrixC);

            CalculationMatrix(matrixSize, commandCount, matrix);

            for (int i = 0; i < matrixSize[0]; i++)
            {
                for (int j = 0; j < matrixSize[1]; j++)
                {
                    if (matrix[i, j] != matrixC[i, j])
                    {
                        int indexRow = 0;
                        int indexCol = 0;
                        for (int k = 0; k < matrixSize[0]; k++)
                        {
                            for (int y = 0; y < matrixSize[1]; y++)
                            {
                                if (matrix[k, y] == matrixC[i, j])
                                {
                                    indexRow = k;
                                    indexCol = y;
                                    int x = matrix[i, j];
                                    matrix[i, j] = matrixC[i, j];
                                    matrix[k, y] = x;
                                    break;
                                }
                            }
                        }
                        Console.WriteLine("Swap ({0}, {1}) with ({2}, {3})", i, j, indexRow, indexCol);

                    }
                    else
                    {
                        Console.WriteLine("No swap required");
                    }
                }
            }
        }

        private static void CalculationMatrix(int[] matrixSize, int commandCount, int[,] matrix)
        {
            for (int i = 0; i < commandCount; i++)
            {
                string[] line = Console.ReadLine().Split(new[] { ' ', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                int f = int.Parse(line[0]);
                int s = int.Parse(line[2]);
                if (line[1].ToLower() == "left")
                {
                    for (int l = 0; l < s % matrixSize[1]; l++)
                    {
                        int firstNum = matrix[f, 0];
                        for (int k = 0; k < matrixSize[1] - 1; k++)
                        {
                            matrix[f, k] = matrix[f, k + 1];
                        }
                        matrix[f, matrixSize[1] - 1] = firstNum;
                    }
                }
                if (line[1].ToLower() == "right")
                {
                    for (int l = 0; l < s % matrixSize[1]; l++)
                    {
                        int lastNum = matrix[f, matrixSize[1] - 1];
                        for (int k = matrixSize[1] - 1; k > 0; k--)
                        {
                            matrix[f, k] = matrix[f, k - 1];
                        }
                        matrix[f, 0] = lastNum;
                    }
                }
                if (line[1].ToLower() == "down")
                {
                    for (int l = 0; l < s % matrixSize[0]; l++)
                    {
                        int lastNum = matrix[matrixSize[0] - 1, f];
                        for (int k = matrixSize[0] - 1; k > 0; k--)
                        {
                            matrix[k, f] = matrix[k - 1, f];
                        }
                        matrix[0, f] = lastNum;
                    }
                }
                if (line[1].ToLower() == "up")
                {
                    for (int l = 0; l < s % matrixSize[0]; l++)
                    {
                        int firstNum = matrix[0, f];
                        for (int k = 0; k < matrixSize[0] - 1; k++)
                        {
                            matrix[k, f] = matrix[k + 1, f];
                        }
                        matrix[matrixSize[0] - 1, f] = firstNum;
                    }
                }
            }
        }

        private static void fillMatrix(int[] matrixSize, int[,] matrix)
        {
            int curNum = 1;
            for (int i = 0; i < matrixSize[0]; i++)
            {
                for (int j = 0; j < matrixSize[1]; j++)
                {
                    matrix[i, j] = curNum;
                    curNum++;
                }
            }
        }
    }
}
