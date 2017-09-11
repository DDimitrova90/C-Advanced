namespace _08_Weak_Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class WeakStudents
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

            var weakStudents = students.Where(s => s.Value.Where(g => g <= 3).Count() >= 2);

            foreach (var student in weakStudents)
            {
                Console.WriteLine(student.Key);
            }
        }
    }
}
