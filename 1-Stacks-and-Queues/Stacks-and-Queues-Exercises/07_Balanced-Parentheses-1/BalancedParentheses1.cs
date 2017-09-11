namespace _07_Balanced_Parentheses_1
{
    using System;               
    using System.Collections.Generic;
    using System.Linq;

    public class BalancedParentheses1
    {
        public static void Main()
        {
            string paranthesisLine = Console.ReadLine();

            Stack<char> openedParanthesis = new Stack<char>();
            char[] openingCases = new char[] { '{', '[', '(' };

            for (int i = 0; i < paranthesisLine.Length; i++)
            {
                if (openingCases.Contains(paranthesisLine[i]))
                {
                    openedParanthesis.Push(paranthesisLine[i]);
                }
                else
                {
                    if (openedParanthesis.Count == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }

                    switch (paranthesisLine[i])
                    {
                        case '}':
                            if (openedParanthesis.Pop() != '{')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;
                        case ')':
                            if (openedParanthesis.Pop() != '(')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;
                        case ']':
                            if (openedParanthesis.Pop() != '[')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;
                    }
                }
            }

            Console.WriteLine("YES");
        }
    }
}
