namespace _01_Action_Print
{
    using System;

    public class ActionPrint
    {
        public static void Main()
        {
            string[] names = Console.ReadLine()
                .Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            Action<string> print = n => Console.WriteLine(n);

            foreach (var name in names)
            {
                print(name);
            }
        }
    }
}
