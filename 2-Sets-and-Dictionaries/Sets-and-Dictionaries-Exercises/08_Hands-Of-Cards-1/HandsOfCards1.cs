namespace _08_Hands_Of_Cards_1
{
    using System;                       
    using System.Collections.Generic;
    using System.Linq;

    public class HandsOfCards1
    {
        public static void Main()
        {
            Dictionary<string, HashSet<string>> players =
                new Dictionary<string, HashSet<string>>();
            string handout = Console.ReadLine();

            while (handout != "JOKER")
            {
                string[] handoutTokens = handout.Split(':');
                string playerName = handoutTokens[0];
                string[] cards = handoutTokens[1]
                    .Split(',')
                    .Select(a => a.Trim())
                    .ToArray();

                if (players.ContainsKey(playerName))
                {
                    players[playerName].UnionWith(cards);
                }
                else
                {
                    players[playerName] = new HashSet<string>(cards);
                }

                handout = Console.ReadLine();
            }

            PrintPlayersAndScores(players);
        }

        public static void PrintPlayersAndScores(Dictionary<string, HashSet<string>> players)
        {
            foreach (var player in players)
            {
                int score = CalculateScore(player.Value);

                Console.WriteLine($"{player.Key}: {score}");
            }
        }

        public static int CalculateScore(HashSet<string> cards)
        {
            int totalScore = 0;

            foreach (var card in cards)
            {
                string type = card.Last().ToString();
                string power = card.Substring(0, card.Length - 1);

                int score;
                bool isDigit = int.TryParse(power, out score);

                if (!isDigit)
                {
                    switch (power)
                    {
                        case "J":
                            score = 11;
                            break;
                        case "Q":
                            score = 12;
                            break;
                        case "K":
                            score = 13;
                            break;
                        case "A":
                            score = 14;
                            break;
                    }
                }

                switch (type)
                {
                    case "S":
                        score *= 4;
                        break;
                    case "H":
                        score *= 3;
                        break;
                    case "D":
                        score *= 2;
                        break;
                    case "C":
                        score *= 1;
                        break;
                }

                totalScore += score;
            }

            return totalScore;
        }
    }
}
