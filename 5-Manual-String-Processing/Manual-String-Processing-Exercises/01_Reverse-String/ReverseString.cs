namespace _01_Reverse_String
{
    using System;
    using System.Text;

    public class ReverseString
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            StringBuilder strBuilder = new StringBuilder();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                strBuilder.Append(input[i]);
            }

            Console.WriteLine(strBuilder);
        }
    }
}
