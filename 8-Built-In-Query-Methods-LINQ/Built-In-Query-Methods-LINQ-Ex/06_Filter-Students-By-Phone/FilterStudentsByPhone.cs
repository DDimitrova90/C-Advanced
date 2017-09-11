namespace _06_Filter_Students_By_Phone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FilterStudentsByPhone
    {
        public static void Main()
        {
            string line = Console.ReadLine();

            List<string> students = new List<string>();
            string firstPrefix = "02";
            string secondPrefix = "+3592";

            while (line != "END")
            {
                students.Add(line);

                line = Console.ReadLine();
            }

            students
                .Where(
                s => s.Split(' ')[2].StartsWith(firstPrefix) ||
                s.Split(' ')[2].StartsWith(secondPrefix))
                .ToList()
                .ForEach(s => Console.WriteLine(s.Split(' ')[0] + " " + s.Split(' ')[1]));
        }
    }
}
