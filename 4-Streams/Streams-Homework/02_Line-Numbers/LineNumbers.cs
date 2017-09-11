namespace _02_Line_Numbers
{
    using System.IO;

    public class LineNumbers
    {
        public static void Main()
        {
            using (StreamReader reader = new StreamReader("../../someText.txt"))
            {
                using (StreamWriter writer = new StreamWriter("../../newText.txt"))
                {
                    int lineNumber = 1;
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        writer.WriteLine($"{lineNumber}. {line}");
                        lineNumber++;

                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
