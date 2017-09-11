namespace _05_Convert_From_Base_N_To_Base_10
{
    using System;
    using System.Numerics;

    public class ConvertFromBaseNToBase10
    {
        public static void Main()
        {
            string[] inputArgs = Console.ReadLine()
                .Trim()
                .Split(new char[] { ' ' }, 
                StringSplitOptions.RemoveEmptyEntries);

            int originalBase = int.Parse(inputArgs[0]);
            string numberToConvert = inputArgs[1];

            BigInteger result = ConvertNumberToBase10(numberToConvert, originalBase);

            Console.WriteLine(result);
        }

        private static BigInteger ConvertNumberToBase10(string numberToConvert, int originalBase)
        {
            BigInteger result = 0;
            int power = 0;

            for (int i = numberToConvert.Length - 1; i >= 0; i--)
            {
                BigInteger baseValue = 1;

                for (int j = 0; j < power; j++)
                {
                    baseValue *= originalBase;
                }

                result += int.Parse(numberToConvert[i].ToString()) * baseValue;
                power++;
            }

            return result;
        }
    }
}
