namespace _04_Matching_Brackets
{
    using System;
    using System.Collections.Generic;

    public class MatchingBrackets
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }

                if (input[i] == ')')
                {
                    int startIndex = stack.Pop();
                    string subExpression = input.Substring(startIndex, i - startIndex + 1);
                    Console.WriteLine(subExpression);
                }
            }
        }
    }
}
