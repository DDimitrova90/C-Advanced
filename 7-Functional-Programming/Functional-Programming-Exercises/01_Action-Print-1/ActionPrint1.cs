namespace _01_Action_Print_1
{
    using System;    

    public class ActionPrint1
    {
        public static void Main()
        {
            string[] names = Console.ReadLine()
                .Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            Action<string> print = str => Console.WriteLine(str);
            PrintAllNames(names, print);

            // For problem 2
            //Action<string> addPrefixAndPrint = str => Console.WriteLine("Sir " + str);
            //PrintAllNames(names, addPrefixAndPrint);
        }

        private static void PrintAllNames(string[] names, Action<string> print)
        {
            foreach (var name in names)
            {
                print(name);
            }
        }
    }
}
