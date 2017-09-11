namespace _04_Sort_Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SortStudents
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
                .OrderBy(s => s.Split(' ')[1])
                .ThenByDescending(s => s.Split(' ')[0])
                .ToList()
                .ForEach(s => Console.WriteLine(s.Split(' ')[0] + " " + s.Split(' ')[1]));
        }
    }
}
