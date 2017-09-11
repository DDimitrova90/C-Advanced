namespace _05_Filter_Students_By_Email_Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FilterStudentsByEmailDomain
    {
        public static void Main()
        {
            string line = Console.ReadLine();

            string domain = "@gmail.com";
            List<string> students = new List<string>();

            while (line != "END")
            {
                students.Add(line);

                line = Console.ReadLine();
            }

            students
                .Where(s => s.Split(' ')[2].EndsWith(domain))
                .ToList()
                .ForEach(s => Console.WriteLine(s.Split(' ')[0] + " " + s.Split(' ')[1]));
        }
    }
}
