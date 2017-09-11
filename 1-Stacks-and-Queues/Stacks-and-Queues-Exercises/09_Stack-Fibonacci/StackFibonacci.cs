namespace _09_Stack_Fibonacci
{
    using System;
    using System.Collections.Generic;

    public class StackFibonacci
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Stack<long> stack = new Stack<long>();
            stack.Push(0);
            stack.Push(1);

            for (int i = 1; i < n; i++)
            {
                long firstNumber = stack.Pop();
                long secondNumber = stack.Peek();
                long currentNumber = firstNumber + secondNumber;

                stack.Push(firstNumber);
                stack.Push(currentNumber);
            }

            Console.WriteLine(stack.Peek());
        }
    }
}
