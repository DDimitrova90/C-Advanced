namespace _12_Little_John
{
    using System;       
    using System.Linq;
    using System.Text.RegularExpressions;

    public class LittleJohn
    {
        public static void Main()
        {
            int smallArrowsCount = 0;
            int mediumArrowsCount = 0;
            int largeArrowsCount = 0;

            for (int i = 0; i < 4; i++)
            {
                string[] inputArgs = Regex
                    .Split(Console.ReadLine(), @"[^->]+")
                    .Where(a => a != string.Empty && a.Where(c => c == '-').Count() == 5)
                    .ToArray();

                foreach (var arrow in inputArgs)
                {
                    if (arrow.StartsWith(">>>") && arrow.EndsWith(">>") && arrow.Length == 10)
                    {
                        largeArrowsCount++;
                    }
                    else if (arrow.StartsWith(">>") && arrow.EndsWith(">") && arrow.Length == 8)
                    {
                        mediumArrowsCount++;
                    }
                    else if (arrow.StartsWith(">") && arrow.EndsWith(">") && arrow.Length == 7)
                    {
                        smallArrowsCount++;
                    }
                }
            }

            string number = "" + smallArrowsCount + mediumArrowsCount + largeArrowsCount;
            int numberToEncrypt = int.Parse(number);

            string binaryNumber = Convert.ToString(numberToEncrypt, 2);
            char[] binaryArray = binaryNumber.ToCharArray();
            Array.Reverse(binaryArray);
            binaryNumber = binaryNumber + new string(binaryArray);

            int result = Convert.ToInt32(binaryNumber, 2);

            Console.WriteLine(result);
        }
    }
}
