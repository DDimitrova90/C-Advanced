namespace _04_Academy_Graduation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AcademyGraduation
    {
        public static void Main()
        {
            int studentsNumber = int.Parse(Console.ReadLine());

            SortedDictionary<string, double[]> studentTracking = 
                new SortedDictionary<string, double[]>();

            for (int i = 0; i < studentsNumber; i++)
            {
                string studentName = Console.ReadLine();
                double[] scores = Console.ReadLine()
                    .Trim()
                    .Split(new char[] { ' ' }, 
                    StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                if (!studentTracking.ContainsKey(studentName))
                {
                    studentTracking[studentName] = new double[scores.Length];
                }

                studentTracking[studentName] = scores;
            }

            foreach (var track in studentTracking)
            {
                double scoresSum = 0;

                for (int i = 0; i < track.Value.Length; i++)
                {
                    scoresSum += track.Value[i];
                }

                double averageScore = scoresSum / track.Value.Count();

                Console.WriteLine($"{track.Key} is graduated with {averageScore}");
            }
        }
    }
}
