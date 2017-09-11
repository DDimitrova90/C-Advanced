namespace _10_Group_By_Group_1
{
    using System;   
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class GroupByGroup1
    {
        public static void Main()
        {
            string inputLine = Console.ReadLine();

            List<Person> students = new List<Person>();

            while (inputLine != "END")
            {
                string[] tokens = inputLine.Split(' ');
                string name = tokens[0] + " " + tokens[1];
                int group = int.Parse(tokens[2]);

                students.Add(new Person(name, group));

                inputLine = Console.ReadLine();
            }

            var grouped = students
                .GroupBy(s => s.Group)
                .OrderBy(g => g.Key);

            foreach (var group in grouped)
            {
                Console.Write($"{group.Key} - ");

                StringBuilder sb = new StringBuilder();

                foreach (var person in group)
                {
                    sb.Append(person.Name).Append(", ");
                }

                sb.Length -= 2;
                Console.WriteLine(sb);
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
