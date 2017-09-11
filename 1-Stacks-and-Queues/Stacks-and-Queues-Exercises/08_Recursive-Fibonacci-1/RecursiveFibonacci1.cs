namespace _08_Recursive_Fibonacci_1
{
    using System;    

    public class RecursiveFibonacci1
    {
        private static long[] fibNumbers;

        public static void Main()
        {
            int nthNumber = int.Parse(Console.ReadLine());
            fibNumbers = new long[nthNumber];

            long result = GetFibonacci(nthNumber);
            Console.WriteLine(result);
        }

        public static long GetFibonacci(int nthNumber)
        {
            // Set bottom
            if (nthNumber <= 2)
            {
                return 1;
            }

            // This is for the Memoization
            if (fibNumbers[nthNumber - 1] != 0)
            {
                return fibNumbers[nthNumber - 1];
            }

            return fibNumbers[nthNumber - 1] = GetFibonacci(nthNumber - 1) + GetFibonacci(nthNumber - 2);
        }
    }
}
