namespace _10_Group_By_Group
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GroupByGroup
    {
        public static void Main()
        {
            string line = Console.ReadLine();

            List<Person> students = new List<Person>();

            while (line != "END")
            {
                string[] lineTokens = line.Split(' ');
                string name = lineTokens[0] + " " + lineTokens[1];
                int group = int.Parse(lineTokens[2]);

                Person student = new Person(name, group);
                students.Add(student);

                line = Console.ReadLine();
            }

            var studentsGroups = students
                .OrderBy(s => s.Group)
                .Select(s => s.Group)
                .Distinct();

            foreach (var group in studentsGroups)
            {
                Console.WriteLine($"{group} - {string.Join(", ", students.Where(s => s.Group == group).Select(s => s.Name))}");
            }
        }
    }

    public class Person
    {
        public Person(string name, int group)
        {
            this.Name = name;
            this.Group = group;
        }

        public string Name { get; set; }

        public int Group { get; set; }
    }
}
