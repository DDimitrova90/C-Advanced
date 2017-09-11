namespace _03_Group_Numbers_2
{
    using System;     
    using System.Linq;

    public class GroupNumbers2
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
               .Trim()
               .Split(new char[] { ' ', ',' },
               StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
            int[] sizes = new int[3];

            foreach (var number in numbers)
            {
                int remainder = Math.Abs(number % 3);
                sizes[remainder]++;
            }

            int[][] matrix = new int[3][]
            {
                new int[sizes[0]],
                new int[sizes[1]],
                new int[sizes[2]]
            };

            int[] offsets = new int[3];

            foreach (var number in numbers)
            {
                int remainder = Math.Abs(number % 3);
                int index = offsets[remainder];
                offsets[remainder]++;
                matrix[remainder][index] = number;
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
