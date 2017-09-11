namespace _08_Weak_Students_1
{
    using System;     
    using System.Collections.Generic;
    using System.Linq;

    public class WeakStudents1
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
                .Where(arr => arr.Skip(2).Count(mark => int.Parse(mark) <= 3) >= 2)
                .ToList()
                .ForEach(arr => Console.WriteLine($"{arr[0]} {arr[1]}"));
        }
    }
}
