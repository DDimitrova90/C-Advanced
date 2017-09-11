namespace _07_Sum_Big_Numbers_1
{
    using System;          
    using System.Collections.Generic;
    using System.Text;

    public class SumBigNumbers1
    {
        public static void Main()
        {
            Stack<char> firstNumber = new Stack<char>(Console.ReadLine());
            Stack<char> secondNumber = new Stack<char>(Console.ReadLine());

            StringBuilder result = new StringBuilder();
            int sum = 0;

            while (firstNumber.Count != 0 || secondNumber.Count != 0)
            {
                sum = sum / 10;

                if (firstNumber.Count != 0)
                {
                    sum += int.Parse(firstNumber.Pop().ToString());
                }

                if (secondNumber.Count != 0)
                {
                    sum += (int)char.GetNumericValue(secondNumber.Pop());
                }

                result.Insert(0, sum % 10);
            }

            result.Insert(0, sum / 10);

            Console.WriteLine(result.ToString().TrimStart('0'));
        }
    }
}
