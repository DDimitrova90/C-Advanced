namespace _03_Decimal_to_Binary_Converter
{
    using System;
    using System.Collections.Generic;

    public class DecimaltoBinaryConverter
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            if (number == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                while (number > 0)
                {
                    stack.Push(number % 2);
                    number /= 2;
                }
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }

            Console.WriteLine();
        }
    }
}
