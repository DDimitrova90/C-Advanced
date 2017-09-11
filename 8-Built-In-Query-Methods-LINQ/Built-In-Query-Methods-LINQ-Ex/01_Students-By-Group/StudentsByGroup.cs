namespace _01_Students_By_Group
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsByGroup
    {
        public static void Main()
        {
            string line = Console.ReadLine();
            List<string> students = new List<string>();

            while (line != "END")
            {
                students.Add(line);

                line = Console.ReadLine();
            }

            students
                .Where(s => int.Parse(s.Split(' ')[2]) == 2)
                .OrderBy(s => s.Split(' ')[0])
                .ToList()
                .ForEach(s => Console.WriteLine(s.Split(' ')[0] + " " + s.Split(' ')[1]));
        }
    }
}
