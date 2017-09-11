namespace _01_Reverse_Numbers_with_a_Stack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReverseNumbersWithAStack
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> stack = new Stack<int>(numbers);

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop() + " ");
            }

            Console.WriteLine();
        }
    }
}
