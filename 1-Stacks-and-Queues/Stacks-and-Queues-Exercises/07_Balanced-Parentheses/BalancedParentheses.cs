namespace _07_Balanced_Parentheses
{
    using System;                 
    using System.Collections.Generic;

    public class BalancedParentheses
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();
            bool isBalanced = true;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '{' || input[i] == '(' || input[i] == '[')
                {
                    stack.Push(input[i]);
                }
                else
                {
                    if (input[i] == '}')
                    {
                        if (stack.Count > 0 && stack.Pop() == '{')
                        {
                            continue;
                        }
                        else
                        {
                            isBalanced = false;
                            break;
                        }
                    }
                    else if (input[i] == ']')
                    {
                        if (stack.Count > 0 && stack.Pop() == '[')
                        {
                            continue;
                        }
                        else
                        {
                            isBalanced = false;
                            break;
                        }
                    }
                    else if (input[i] == ')')
                    {
                        if (stack.Count > 0 && stack.Pop() == '(')
                        {
                            continue;
                        }
                        else
                        {
                            isBalanced = false;
                            break;
                        }
                    }
                }
            }

            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
