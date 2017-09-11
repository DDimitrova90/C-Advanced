namespace _03_Students_By_Age
{
    using System;

    public class StudentsByAge
    {
        public static void Main()
        {
            string line = Console.ReadLine();

            while (line != "END")
            {
                string[] lineTokens = line.Split(' ');
                int age = int.Parse(lineTokens[2]);

                if (age >= 18 && age <= 24)
                {
                    Console.WriteLine(line);
                }

                line = Console.ReadLine();
            }
        }
    }
}
