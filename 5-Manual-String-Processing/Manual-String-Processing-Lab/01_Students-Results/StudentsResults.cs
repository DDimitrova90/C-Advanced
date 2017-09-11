namespace _01_Students_Results
{
    using System;
    using System.Text;

    public class StudentsResults
    {
        public static void Main()
        {
            int studentsNumber = int.Parse(Console.ReadLine());

            StringBuilder strBuilder = new StringBuilder();
            strBuilder.AppendFormat("{0,-10}|{1,7}|{2,7}|{3,7}|{4,7}|\n", 
                "Name", "CAdv", "COOP", "AdvOOP", "Average");
            
            for (int currStudent = 0; currStudent < studentsNumber; currStudent++)
            {
                string[] studentData = Console.ReadLine()
                    .Split(new char[] { ' ', '-', ',' }, 
                    StringSplitOptions.RemoveEmptyEntries);

                string studentName = studentData[0];
                double firstResult = double.Parse(studentData[1]);
                double secondResult = double.Parse(studentData[2]);
                double thirdResult = double.Parse(studentData[3]);
                double averageResult = (firstResult + secondResult + thirdResult) / 3;

                strBuilder.AppendFormat("{0,-10}|{1,7:F2}|{2,7:F2}|{3,7:F2}|{4,7:F4}|\n", 
                    studentName, firstResult, secondResult, thirdResult, averageResult);
            }

            Console.WriteLine(strBuilder.ToString().Trim());
        }
    }
}
