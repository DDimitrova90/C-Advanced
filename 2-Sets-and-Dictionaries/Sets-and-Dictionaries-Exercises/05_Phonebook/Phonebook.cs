namespace _05_Phonebook
{
    using System;
    using System.Collections.Generic;

    public class Phonebook
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            Dictionary<string, string> phonebook = 
                new Dictionary<string, string>();

            while (input != "search")
            {
                string[] args = input.Split('-');
                string name = args[0];
                string phonenumber = args[1];

                if (!phonebook.ContainsKey(name))
                {
                    phonebook.Add(name, phonenumber);
                }

                phonebook[name] = phonenumber;

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "stop")
            {
                string name = input;

                if (phonebook.ContainsKey(name))
                {
                    Console.WriteLine($"{name} -> {phonebook[name]}");
                }
                else
                {
                    Console.WriteLine($"Contact {name} does not exist.");
                }

                input = Console.ReadLine();
            }
        }
    }
}
