namespace _11_Students_Joined_To_Specialties_1
{
    using System;    
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsJoinedToSpecialties1
    {
        public static void Main()
        {
            List<Student> students = new List<Student>();
            List<StudentSpecialty> specialties = new List<StudentSpecialty>();

            string input = Console.ReadLine();

            while (input != "Students:")
            {
                string[] tokens = input.Split(' ');
                string specName = tokens[0] + " " + tokens[1];
                int facultyNumber = int.Parse(tokens[2]);

                specialties.Add(new StudentSpecialty(specName, facultyNumber));

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "END")
            {
                string[] tokens = input.Split(' ');
                string studentName = tokens[1] + " " + tokens[2];
                int facultyNumber = int.Parse(tokens[0]);

                students.Add(new Student(studentName, facultyNumber));

                input = Console.ReadLine();
            }

            specialties.Join(students,
                sp => sp.FacultyNumber,
                st => st.FacultyNumber,
                (sp, st) => new
                {
                    Name = st.StudentName,
                    FacNumber = st.FacultyNumber,
                    Specialty = sp.SpecName
                })
                .OrderBy(s => s.Name)
                .ToList()
                .ForEach(s => Console.WriteLine($"{s.Name} {s.FacNumber} {s.Specialty}"));
        }
    }

    public class StudentSpecialty
    {
        public StudentSpecialty(string specName, int facultyNumber)
        {
            this.SpecName = specName;
            this.FacultyNumber = facultyNumber;
        }

        public string SpecName { get; set; }

        public int FacultyNumber { get; set; }
    }

    public class Student
    {
        public Student(string studentName, int facultyNumber)
        {
            this.StudentName = studentName;
            this.FacultyNumber = facultyNumber;
        }

        public string StudentName { get; set; }

        public int FacultyNumber { get; set; }
    }
}
