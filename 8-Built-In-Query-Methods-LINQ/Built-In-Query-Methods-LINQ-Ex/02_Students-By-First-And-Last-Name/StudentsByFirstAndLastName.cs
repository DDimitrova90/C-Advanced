namespace _02_Students_By_First_And_Last_Name
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsByFirstAndLastName
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
                .Where(s => s.Split(' ')[0].CompareTo(s.Split(' ')[1]) == -1)
                .ToList()
                .ForEach(s => Console.WriteLine(s.Split(' ')[0] + " " + s.Split(' ')[1]));
        }
    }
}
