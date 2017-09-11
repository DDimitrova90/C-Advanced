namespace _10_Simple_Text_Editor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SimpleTextEditor
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Stack<string> lastStrings = new Stack<string>();
            string currentString = string.Empty;
            lastStrings.Push(currentString);

            for (int i = 0; i < n; i++)
            {
                string[] commandArgs = Console.ReadLine()
                    .Trim()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (commandArgs[0])
                {
                    case "1":
                        currentString += commandArgs[1];
                        lastStrings.Push(currentString);
                        break;
                    case "2":
                        int charsCount = int.Parse(commandArgs[1]);
                        currentString = currentString
                            .Substring(0, currentString.Length - charsCount);
                        lastStrings.Push(currentString);
                        break;
                    case "3":
                        int index = int.Parse(commandArgs[1]);
                        Console.WriteLine(currentString.ElementAt(index - 1));
                        break;
                    case "4":
                        lastStrings.Pop();
                        currentString = lastStrings.Peek();
                        break;
                }
            }
        }
    }
}
