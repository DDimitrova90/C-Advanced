namespace _02_Cubics_Rube
{
    using System;
    using System.Linq;

    public class CubicsRube
    {
        public static void Main()
        {
            int dimension = int.Parse(Console.ReadLine());

            string line = Console.ReadLine();
            long bombardedCells = 0L;
            long sum = 0L;

            while (line != "Analyze")
            {
                long[] tokens = line
                    .Split(new char[] { ' ', '\n', '\r', '\t' }, 
                    StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();

                long pointU = tokens[0];
                long pointV = tokens[1];
                long pointW = tokens[2];
                long particles = tokens[3];

                if (IsPointInCube(dimension, pointU, pointV, pointW) && particles != 0)
                {
                    bombardedCells++;
                    sum += particles;
                }

                line = Console.ReadLine();
            }

            long notAffectedCells = (dimension * dimension * dimension) - bombardedCells;

            Console.WriteLine(sum);
            Console.WriteLine(notAffectedCells);
        }

        private static bool IsPointInCube(int dimension, long pointU, long pointV, long pointW)
        {
            if ((pointU >= 0 && pointU <= dimension - 1) && 
                (pointV >= 0 && pointV <= dimension - 1) && 
                (pointW >= 0 && pointW <= dimension - 1))
            {
                return true;
            }

            return false;
        }
    }
}
