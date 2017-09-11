namespace _03_Maximum_Element
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MaximumElement
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            int maxElement = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                int[] args = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                if (args.Length == 2)
                {
                    int numberToPush = args[1];
                    stack.Push(numberToPush);

                    if (numberToPush > maxElement)
                    {
                        maxElement = numberToPush;
                    }
                }
                else if (args[0] == 2)
                {
                    int elementToPop = 0;

                    if (stack.Count > 0)
                    {
                        elementToPop = stack.Pop();
                    }  

                    if (stack.Count > 0 && elementToPop == maxElement)
                    {
                        maxElement = stack.Max();
                    }
                    else if (stack.Count == 0)
                    {
                        maxElement = 0;
                    }
                }
                else
                {
                    Console.WriteLine(maxElement);
                }
            }
        }
    }
}
