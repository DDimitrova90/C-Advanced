namespace _03_Softuni_Numerals
{
    using System;
    using System.Numerics;

    public class SoftuniNumerals
    {
        public static void Main()
        {
            string numeralString = Console.ReadLine();

            string numberStr = string.Empty;

            for (int i = 0; i < numeralString.Length - 1; i++)
            {
                if (numeralString[i] == 'a' && numeralString[i + 1] == 'a')
                {
                    numberStr += "0";
                    i++;
                }
                else if (numeralString[i] == 'a' && numeralString[i + 1] == 'b' && numeralString[i + 2] == 'a')
                {
                    numberStr += "1";
                    i += 2;
                }
                else if (numeralString[i] == 'b' && numeralString[i + 1] == 'c' && numeralString[i + 2] == 'c')
                {
                    numberStr += "2";
                    i += 2;
                }
                else if (numeralString[i] == 'c' && numeralString[i + 1] == 'c')
                {
                    numberStr += "3";
                    i++;
                }
                else if (numeralString[i] == 'c' && numeralString[i + 1] == 'd' && numeralString[i + 2] == 'c')
                {
                    numberStr += "4";
                    i += 2;
                }
            }

            int power = 0;
            BigInteger result = 0;

            for (int currDigit = numberStr.Length - 1; currDigit >= 0; currDigit--)
            {
                result += int.Parse(numberStr[currDigit].ToString()) * BigInteger.Pow(5, power);
                power++;
            }
            
            Console.WriteLine(result);
        }
    }
}
