namespace _02_Upper_Strings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UpperStrings
    {
        public static void Main()
        {
            List<string> words = Console.ReadLine()
                .Split(' ')
                .ToList();

            words.Select(w => w.ToUpper())
                .ToList()
                .ForEach(w => Console.Write(w + " "));
        }
    }
}
