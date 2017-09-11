namespace _01_Jedi_Meditation
{
    using System;
    using System.Collections.Generic;

    public class JediMeditation
    {
        public static void Main()
        {
            int linesCount = int.Parse(Console.ReadLine());

            Queue<string> masters = new Queue<string>();
            Queue<string> knights = new Queue<string>();
            Queue<string> padawans = new Queue<string>();
            Queue<string> others = new Queue<string>();
            Queue<string> yodas = new Queue<string>();

            for (int i = 0; i < linesCount; i++)
            {
                string[] jedis = Console.ReadLine()
                    .Split(new char[] { ' ' }, 
                    StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < jedis.Length; j++)
                {
                    if (jedis[j].StartsWith("m"))
                    {
                        masters.Enqueue(jedis[j]);
                    }
                    else if (jedis[j].StartsWith("k"))
                    {
                        knights.Enqueue(jedis[j]);
                    }
                    else if (jedis[j].StartsWith("p"))
                    {
                        padawans.Enqueue(jedis[j]);
                    }
                    else if (jedis[j].StartsWith("s") || jedis[j].StartsWith("t"))
                    {
                        others.Enqueue(jedis[j]);
                    }
                    else if (jedis[j].StartsWith("y"))
                    {
                        yodas.Enqueue(jedis[j]);
                    }
                }
            }

            if (yodas.Count == 0)
            {
                Console.WriteLine(string.Join(" ", others) + " " + string.Join(" ", masters) + " " + string.Join(" ", knights) + " " + string.Join(" ", padawans));
            }
            else
            {
                Console.WriteLine(string.Join(" ", masters) + " " + string.Join(" ", knights) + " " + string.Join(" ", others) + " " + string.Join(" ", padawans));
            }
        }
    }
}
