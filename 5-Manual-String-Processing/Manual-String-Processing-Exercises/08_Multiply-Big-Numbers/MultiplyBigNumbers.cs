namespace _08_Multiply_Big_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MultiplyBigNumbers
    {
        public static void Main()
        {
            string firstNumber = Console.ReadLine();
            int secondNumber = int.Parse(Console.ReadLine());

            if (secondNumber == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                firstNumber = new string(firstNumber.Reverse().ToArray());

                Stack<int> sumDigits = MultiplyNumbers(firstNumber, secondNumber);

                PrintResult(sumDigits);
            }
        }

        private static void PrintResult(Stack<int> sumDigits)
        {
            List<string> result = new List<string>();

            while (sumDigits.Count > 0)
            {
                result.Add(sumDigits.Pop().ToString());
            }

            Console.WriteLine(string.Join("", result.SkipWhile(d => d.Equals("0"))));
        }

        private static Stack<int> MultiplyNumbers(string firstNumber, int secondNumber)
        {
            Stack<int> sumDigits = new Stack<int>();
            int currSum = 0;

            for (int i = 0; i < firstNumber.Length; i++)
            {
                int currDigit = int.Parse(firstNumber[i].ToString());
                currSum += currDigit * secondNumber;

                if (currSum < 10)
                {
                    sumDigits.Push(currSum);
                    currSum = 0;
                }
                else
                {
                    sumDigits.Push(currSum % 10);
                    currSum = currSum / 10;
                }

                if (i == firstNumber.Length - 1)
                {
                    sumDigits.Push(currSum);
                }
            }

            return sumDigits;
        }
    }
}
