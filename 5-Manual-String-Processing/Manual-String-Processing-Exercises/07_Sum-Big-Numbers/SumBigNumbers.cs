namespace _07_Sum_Big_Numbers
{
    using System;       
    using System.Collections.Generic;
    using System.Linq;

    public class SumBigNumbers
    {
        public static void Main()
        {
            string firstNumber = Console.ReadLine();
            string secondNumber = Console.ReadLine();

            firstNumber = new string(firstNumber.Reverse().ToArray());
            secondNumber = new string(secondNumber.Reverse().ToArray());
            Stack<int> sumDigits = new Stack<int>();

            if (firstNumber.Length <= secondNumber.Length)
            {
                sumDigits = SumNumbers(firstNumber, secondNumber);
            }
            else
            {
                sumDigits = SumNumbers(secondNumber, firstNumber);
            }

            PrintResult(sumDigits);
        }

        private static void PrintResult(Stack<int> sumDigits)
        {
            List<string> result = new List<string>();

            while (sumDigits.Count > 0)
            {
                result.Add(sumDigits.Pop().ToString());
            }

            Console.WriteLine(string.Join("", result.SkipWhile(d => d == "0")));
        }

        private static Stack<int> SumNumbers(string firstNumber, string secondNumber)
        {
            Stack<int> sumDigits = new Stack<int>();
            int currSum = 0;

            for (int i = 0; i < firstNumber.Length; i++)
            {
                int digitFirstNum = int.Parse(firstNumber[i].ToString());
                int digitSecondNum = int.Parse(secondNumber[i].ToString());
                currSum += digitFirstNum + digitSecondNum;

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
            }

            for (int i = firstNumber.Length; i < secondNumber.Length; i++)
            {
                int digitSecondNum = int.Parse(secondNumber[i].ToString());
                currSum += digitSecondNum;

                if (currSum < 10)
                {
                    sumDigits.Push(currSum);
                    currSum = 0;
                }
                else
                {
                    sumDigits.Push(currSum % 10);
                    currSum = currSum / 10;

                    if (i == secondNumber.Length - 1 && currSum != 0)
                    {
                        sumDigits.Push(currSum);
                    }
                }
            }

            return sumDigits;
        }
    }
}
