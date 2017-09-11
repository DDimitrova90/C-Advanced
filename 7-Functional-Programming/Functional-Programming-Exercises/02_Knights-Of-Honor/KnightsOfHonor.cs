namespace _02_Knights_Of_Honor
{
    using System;

    public class KnightsOfHonor
    {
        public static void Main()
        {
            string[] names = Console.ReadLine()
                .Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            Action<string> appendAndPrint = n => Console.WriteLine("Sir " + n);

            foreach (var name in names)
            {
                appendAndPrint(name);
            }
        }
    }
}
