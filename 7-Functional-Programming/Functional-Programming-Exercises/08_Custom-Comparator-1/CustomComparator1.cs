namespace _08_Custom_Comparator_1
{
    using System;     
    using System.Linq;

    public class CustomComparator1
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            // OR:
            //Array.Sort(numbers, (x, y) =>
            //{
            //    int a = (x % 2).CompareTo(y % 2);

            //    if (a == 0)
            //    {
            //        return x.CompareTo(y);
            //    }

            //    return a;
            //});

            Array.Sort(numbers, (x, y) =>
            {
                if (x % 2 == 0 && y % 2 != 0)
                {
                    return -1;
                }
                if (x % 2 != 0 && y % 2 == 0)
                {
                    return 1;
                }
                if (x > y)
                {
                    return 1;
                }
                if (x < y)
                {
                    return -1;
                }

                return 0;
            });

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
