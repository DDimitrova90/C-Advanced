namespace _03_NMS
{
    using System;
    using System.Text;

    public class NMS
    {
        public static void Main()
        {
            string line = Console.ReadLine();

            StringBuilder sb = new StringBuilder();
            StringBuilder words = new StringBuilder();

            while (line != "---NMS SEND---")
            {
                sb.Append(line);

                line = Console.ReadLine();
            }

            for (int i = 0; i < sb.Length - 1; i++)
            {
                if (char.ToLower(sb[i + 1]) >= char.ToLower(sb[i]))
                {
                    words.Append(sb[i]);
                }
                else
                {
                    words.Append(sb[i]);
                    words.Append(" ");
                }
            }

            words.Append(sb[sb.Length - 1]);

            string delimiter = Console.ReadLine();
           
            Console.WriteLine(words.Replace(" ", delimiter));
        }
    }
}
