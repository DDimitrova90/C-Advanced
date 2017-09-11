namespace _02_Simple_Calculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SimpleCalculator
    {
        public static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(' ')
                .Reverse()
                .ToArray();
            Stack<string> stack = new Stack<string>(input);

            while (stack.Count > 1)
            {
                int firstNumber = int.Parse(stack.Pop());
                string oper = stack.Pop();
                int secondNumber = int.Parse(stack.Pop());
                int result = 0;

                if (oper == "+")
                {
                    result = firstNumber + secondNumber;                  
                }
                else
                {
                    result = firstNumber - secondNumber;
                }

                stack.Push(result.ToString());
            }

            Console.WriteLine(stack.Peek());
        }
    }
}
