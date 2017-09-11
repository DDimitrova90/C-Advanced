namespace _03_Group_Numbers
{
    using System;     
    using System.Collections.Generic;
    using System.Linq;

    public class GroupNumbers
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Trim()
                .Split(new char[] { ' ', ',' }, 
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> zeroRemainder = new List<int>();
            List<int> oneRemainder = new List<int>();
            List<int> twoRemainder = new List<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (Math.Abs(numbers[i]) % 3 == 0)
                {
                    zeroRemainder.Add(numbers[i]);
                }
                else if (Math.Abs(numbers[i]) % 3 == 1)
                {
                    oneRemainder.Add(numbers[i]);
                }
                else if (Math.Abs(numbers[i]) % 3 == 2)
                {
                    twoRemainder.Add(numbers[i]);
                }
            }

            Console.WriteLine(string.Join(" ", zeroRemainder));
            Console.WriteLine(string.Join(" ", oneRemainder));
            Console.WriteLine(string.Join(" ", twoRemainder));
        }
    }
}
