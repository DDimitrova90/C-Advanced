namespace _09_Students_Enrolled_In_2014_Or_2015_1
{
    using System;     
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsEnrolledIn2014Or20151
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
                .Where(arr => arr[0].EndsWith("14") || arr[0].EndsWith("15"))
                .Select(arr => arr.Skip(1))
                .ToList()
                .ForEach(arr => Console.WriteLine(string.Join(" ", arr)));
        }
    }
}
