namespace _04_Convert_From_Base_10_To_Base_N
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Text;

    public class ConvertFromBase10ToBaseN
    {
        public static void Main()
        {
            string[] inputArgs = Console.ReadLine()
                .Trim()
                .Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            int baseN = int.Parse(inputArgs[0]);
            BigInteger numberToConvert = BigInteger.Parse(inputArgs[1]);

            string result = ConvertNumberToBase(numberToConvert, baseN);

            Console.WriteLine(result);
        }

        private static string ConvertNumberToBase(BigInteger numberToConvert, int baseN)
        {
            Stack<BigInteger> remainders = new Stack<BigInteger>();

            while (numberToConvert != 0)
            {
                remainders.Push(numberToConvert % baseN);
                numberToConvert /= baseN; 
            }

            StringBuilder result = new StringBuilder();

            while (remainders.Count > 0)
            {
                result.Append(remainders.Pop());
            }

            return result.ToString();
        }
    }
}
