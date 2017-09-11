namespace _09_Students_Enrolled_In_2014_Or_2015
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsEnrolledIn2014Or2015
    {
        public static void Main()
        {
            string line = Console.ReadLine();

            Dictionary<string, List<int>> students =
                new Dictionary<string, List<int>>();

            while (line != "END")
            {
                string[] lineTokens = line.Split();
                string facultyNumber = lineTokens[0];

                if (!students.ContainsKey(facultyNumber))
                {
                    students.Add(facultyNumber, new List<int>());
                }

                for (int i = 1; i < lineTokens.Length; i++)
                {
                    students[facultyNumber].Add(int.Parse(lineTokens[i]));
                }

                line = Console.ReadLine();
            }

            var enrolledStudents = students.Where(s => s.Key.EndsWith("14") || s.Key.EndsWith("15"));

            foreach (var student in enrolledStudents)
            {
                Console.WriteLine(string.Join(" ", student.Value));
            }
        }
    }
}
