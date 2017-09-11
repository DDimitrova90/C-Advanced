namespace _01_Odd_Lines
{
    using System;
    using System.IO;

    public class OddLines
    {
        public static void Main()
        {
            using (StreamReader reader = new StreamReader("../../someText.txt"))
            {
                int lineNumber = 1;
                string line = reader.ReadLine();

                while (line != null)
                {
                    if (lineNumber % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }

                    lineNumber++;

                    line = reader.ReadLine();
                }
            }
        }
    }
}
