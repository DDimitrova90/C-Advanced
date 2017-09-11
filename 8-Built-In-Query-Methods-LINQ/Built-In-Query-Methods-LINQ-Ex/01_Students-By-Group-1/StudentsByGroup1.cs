namespace _01_Students_By_Group_1
{
    using System;      
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsByGroup1
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
                .Where(arr => arr[2] == "2")
                .OrderBy(arr => arr[0])
                .ToList()
                .ForEach(arr => Console.WriteLine($"{arr[0]} {arr[1]}"));
        }
    }
}
