namespace _07_Excellent_Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ExcellentStudents
    {
        public static void Main()
        {
            string line = Console.ReadLine();

            Dictionary<string, List<int>> students = 
                new Dictionary<string, List<int>>();

            while (line != "END")
            {
                string[] lineTokens = line.Split();
                string fullName = lineTokens[0] + " " + lineTokens[1];

                if (!students.ContainsKey(fullName))
                {
                    students.Add(fullName, new List<int>());
                }

                for (int i = 2; i < lineTokens.Length; i++)
                {
                    students[fullName].Add(int.Parse(lineTokens[i]));
                }

                line = Console.ReadLine();
            }

            var excellentStudents = students.Where(s => s.Value.Contains(6));

            foreach (var student in excellentStudents)
            {
                Console.WriteLine(student.Key);
            }
        }
    }
}
