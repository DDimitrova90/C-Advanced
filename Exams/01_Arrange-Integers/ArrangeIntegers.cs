namespace _01_Arrange_Integers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ArrangeIntegers
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Trim()
                .Split(new char[] { ' ', ',' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<string> strNumbers = new List<string>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] / 10 == 0)
                {
                    string strDigit = ConvertDigit(numbers[i]);
                    strNumbers.Add(strDigit);
                }
                else
                {
                    string number = numbers[i].ToString();
                    string strNumber = string.Empty;

                    for (int j = 0; j < number.Length; j++)
                    {
                        int currDigit = int.Parse(number[j].ToString());
                        string strDigit = ConvertDigit(currDigit);

                        if (j < number.Length - 1)
                        {
                            strNumber += strDigit + "-";
                        }
                        else
                        {
                            strNumber += strDigit;
                        }
                    }

                    strNumbers.Add(strNumber);
                }
            }

            List<string> orderedStrNumbers = strNumbers
                .OrderBy(n => n)
                .ThenBy(n => n.Length)
                .ToList();
            List<int> result = new List<int>();

            for (int i = 0; i < orderedStrNumbers.Count; i++)
            {
                string currNum = orderedStrNumbers[i];

                if (!currNum.Contains("-"))
                {
                    int num = int.Parse(ConvertString(currNum));
                    result.Add(num);
                }
                else
                {
                    string[] strNums = orderedStrNumbers[i].Split('-');
                    string num = string.Empty;

                    for (int j = 0; j < strNums.Length; j++)
                    {
                        num += ConvertString(strNums[j]);
                    }

                    result.Add(int.Parse(num));
                }
            }

            Console.WriteLine(string.Join(", ", result));
        }

        private static string ConvertString(string currNum)
        {
            switch (currNum)
            {
                case "one":
                    return "1";
                case "two":
                    return "2";
                case "three":
                    return "3";
                case "four":
                    return "4";
                case "five":
                    return "5";
                case "six":
                    return "6";
                case "seven":
                    return "7";
                case "eight":
                    return "8";
                case "nine":
                    return "9";
                default:
                    return "0";
            }
        }

        private static string ConvertDigit(int digit)
        {
            switch (digit)
            {
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    return "zero";
            }
        }
    }
}
