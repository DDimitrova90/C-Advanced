namespace _15_Melrah_Shake
{
    using System;

    public class MelrahShake
    {
        public static void Main()
        {
            string inputStr = Console.ReadLine();
            string pattern = Console.ReadLine();

            while (true)
            {
                int startIndex = inputStr.IndexOf(pattern);
                int endIndex = inputStr.LastIndexOf(pattern);

                if (startIndex != endIndex && startIndex != -1)
                {
                    inputStr = ShakeString(inputStr, pattern, startIndex, endIndex);
                    pattern = ShakePattern(pattern);
                    Console.WriteLine("Shaked it.");

                    if (pattern == string.Empty)
                    {
                        Console.WriteLine("No shake.");
                        Console.WriteLine(inputStr);
                        return;
                    }
                }
                else if (startIndex == endIndex)
                {
                    Console.WriteLine("No shake.");
                    Console.WriteLine(inputStr);
                    return;
                }
            }
        }

        private static string ShakePattern(string pattern)
        {
            int index = pattern.Length / 2;
            return pattern = pattern.Remove(index, 1);
        }

        private static string ShakeString(string inputStr, string pattern, int startIndex, int endIndex)
        {
            inputStr = inputStr.Remove(endIndex, pattern.Length).Remove(startIndex, pattern.Length);

            return inputStr;
        }
    }
}
