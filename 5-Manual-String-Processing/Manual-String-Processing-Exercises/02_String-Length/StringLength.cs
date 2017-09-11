namespace _02_String_Length
{
    using System;

    public class StringLength
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            string result = input.Substring(0, Math.Min(20, input.Length)).PadRight(20, '*');

            Console.WriteLine(result);
        }
    }
}
