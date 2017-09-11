namespace _08_Recursive_Fibonacci
{
    using System;    

    public class RecursiveFibonacci
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            long[] fibonacci = new long[n];

            fibonacci[0] = 1;
            
            if (n > 1)
            {
                fibonacci[1] = 1;
            }

            Console.WriteLine(GetFibonacci(n - 1, fibonacci));
        }

        public static long GetFibonacci(int n, long[] fibonacci)
        {
            if (fibonacci[n] == 0)
            {
                fibonacci[n] = GetFibonacci(n - 1, fibonacci) + GetFibonacci(n - 2, fibonacci);
            }

            return fibonacci[n];
        }
    }
}
