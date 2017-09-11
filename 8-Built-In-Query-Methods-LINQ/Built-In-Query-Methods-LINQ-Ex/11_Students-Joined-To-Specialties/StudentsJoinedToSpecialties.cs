namespace _11_Students_Joined_To_Specialties
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsJoinedToSpecialties
    {
        public static void Main()
        {
            string line = Console.ReadLine();

            List<StudentSpecialty> specialties = new List<StudentSpecialty>();
            List<Student> students = new List<Student>();

            while (line != "Students:")
            {
                string[] lineTokens = line.Split(' ');
                string specialtyName = lineTokens[0] + " " + lineTokens[1];
                string facultyNumber = lineTokens[2];
                StudentSpecialty specialty = new StudentSpecialty(specialtyName, facultyNumber);
                specialties.Add(specialty);

                line = Console.ReadLine();
            }

            line = Console.ReadLine();

            while (line != "END")
            {
                string[] lineTokens = line.Split(' ');
                string facultyNumber = lineTokens[0];
                string name = lineTokens[1] + " " + lineTokens[2];

                Student student = new Student(name, facultyNumber);
                students.Add(student);

                line = Console.ReadLine();
            }

            var result = students.Join(specialties,
                s => s.FacultyNumber,
                sp => sp.FacultyNumber,
                (s, sp) => new
                {
                    StudentName = s.Name,
                    FacultyNumber = s.FacultyNumber,
                    SpecialtyName = sp.Name
                })
                .OrderBy(s => s.StudentName);

            foreach (var student in result)
            {
                Console.WriteLine($"{student.StudentName} {student.FacultyNumber} {student.SpecialtyName}");
            }
        }
    }

    public class StudentSpecialty
    {
        public StudentSpecialty(string name, string facultyNumber)
        {
            this.Name = name;
            this.FacultyNumber = facultyNumber;
        }

        public string Name { get; set; }

        public string FacultyNumber { get; set; }
    }

    public class Student
    {
        public Student(string name, string facultyNumber)
        {
            this.Name = name;
            this.FacultyNumber = facultyNumber;
        }

        public string Name { get; set; }

        public string FacultyNumber { get; set; }
    }
}
