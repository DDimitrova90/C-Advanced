namespace _08_Hands_Of_Cards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HandsOfCards
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            Dictionary<string, List<string>> hands = 
                new Dictionary<string, List<string>>();

            while (input != "JOKER")
            {
                string[] inputArgs = input
                    .Trim()
                    .Split(new char[] { ':' }, 
                    StringSplitOptions.RemoveEmptyEntries);
                string name = inputArgs[0];
                List<string> cards = inputArgs[1]
                    .Trim()
                    .Split(new char[] { ',', ' ' }, 
                    StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (!hands.ContainsKey(name))
                {
                    hands.Add(name, new List<string>());
                }

                for (int i = 0; i < cards.Count; i++)
                {
                    hands[name].Add(cards[i]);
                }

                input = Console.ReadLine();
            }

            foreach (var player in hands)
            {
                List<string> cards = player.Value.Distinct().ToList();
                int totalValue = 0;

                foreach (var card in cards)
                {
                    string power = card.Substring(0, card.Length - 1);
                    string type = card.Substring(card.Length - 1);                                       

                    totalValue += GetPowerValue(power) * GetTypeValue(type);                
                }

                Console.WriteLine($"{player.Key}: {totalValue}");
            }
        }

        public static int GetTypeValue(string type)
        {
            switch (type)
            {
                case "S":
                    return 4;
                case "H":
                    return 3;
                case "D":
                    return 2;
                case "C":
                    return 1;
                default:
                    return 1;
            }
        }

        public static int GetPowerValue(string power)
        {
            switch (power)
            {
                case "J":
                    return 11;
                case "Q":
                    return 12;
                case "K":
                    return 13;
                case "A":
                    return 14;
                default:
                    return int.Parse(power);
            }
        }
    }
}
