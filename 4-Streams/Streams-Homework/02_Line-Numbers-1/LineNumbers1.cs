namespace _02_Line_Numbers_1
{
    using System;     
    using System.IO;

    public class LineNumbers1
    {
        public static void Main()
        {
            Console.Write("Choose a file path: ");
            string filePath = Console.ReadLine();

            using (StreamReader reader = new StreamReader(filePath))
            {
                using (StreamWriter writer = new StreamWriter("../../result.txt"))
                {
                    string readLine = "";
                    int counter = 1;

                    while ((readLine = reader.ReadLine()) != null)
                    {
                        writer.WriteLine($"{counter} {readLine}");
                        counter++; 
                    }
                }
            }
        }
    }
}
