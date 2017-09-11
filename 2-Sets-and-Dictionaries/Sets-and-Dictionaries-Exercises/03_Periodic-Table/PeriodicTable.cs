namespace _03_Periodic_Table
{
    using System;
    using System.Collections.Generic;

    public class PeriodicTable
    {
        public static void Main()
        {
            int chemicalsNumber = int.Parse(Console.ReadLine());

            SortedSet<string> chemicals = new SortedSet<string>();

            for (int i = 0; i < chemicalsNumber; i++)
            {
                string[] components = Console.ReadLine().Split(' ');

                for (int j = 0; j < components.Length; j++)
                {
                    chemicals.Add(components[j]);
                }
            }

            foreach (var chemical in chemicals)
            {
                Console.Write(chemical + " ");
            }

            Console.WriteLine();
        }
    }
}
