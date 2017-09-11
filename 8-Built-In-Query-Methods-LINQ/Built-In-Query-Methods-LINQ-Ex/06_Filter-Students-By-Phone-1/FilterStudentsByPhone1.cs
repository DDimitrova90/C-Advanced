namespace _06_Filter_Students_By_Phone_1
{
    using System;     
    using System.Collections.Generic;
    using System.Linq;

    public class FilterStudentsByPhone1
    {
        public static void Main()
        {
            string inputLine = Console.ReadLine();

            List<string[]> group = new List<string[]>();

            while (inputLine != "END")
            {
                group.Add(inputLine.Split(' '));

                inputLine = Console.ReadLine();
            }

            group
                .Where(arr => arr[2].StartsWith("02") || arr[2].StartsWith("+3592"))
                .Select(arr => $"{arr[0]} {arr[1]}")
                .ToList()
                .ForEach(arr => Console.WriteLine(arr));
        }
    }
}
