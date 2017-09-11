namespace _04_Champions_League
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ChampionsLeague
    {
        public static void Main()
        {
            string line = Console.ReadLine();

            Dictionary<string, SortedDictionary<string, int>> teams = 
                new Dictionary<string, SortedDictionary<string, int>>();

            while (line != "stop")
            {
                string[] tokens = line
                    .Split(new char[] { '|' },
                    StringSplitOptions.RemoveEmptyEntries);
                string firstTeam = tokens[0].Trim();
                string secondTeam = tokens[1].Trim();
                int scoresFirstTeam = 0;
                int scoresSecondTeam = 0;
                int[] firstScores = tokens[2]
                    .Trim()
                    .Split(':')
                    .Select(int.Parse)
                    .ToArray();
                scoresFirstTeam += firstScores[0];
                scoresSecondTeam += firstScores[1];
                int[] secondScores = tokens[3]
                    .Trim()
                    .Split(':')
                    .Select(int.Parse)
                    .ToArray();
                scoresFirstTeam += secondScores[1];
                scoresSecondTeam += secondScores[0];

                if (!teams.ContainsKey(firstTeam))
                {
                    teams.Add(firstTeam, new SortedDictionary<string, int>());
                }

                if (!teams[firstTeam].ContainsKey(secondTeam))
                {
                    teams[firstTeam].Add(secondTeam, 0);
                }

                if (!teams.ContainsKey(secondTeam))
                {
                    teams.Add(secondTeam, new SortedDictionary<string, int>());
                }

                if (!teams[secondTeam].ContainsKey(firstTeam))
                {
                    teams[secondTeam].Add(firstTeam, 0);
                }

                string winner = string.Empty;
                string looser = string.Empty;

                if (scoresFirstTeam == scoresSecondTeam)
                {
                    winner = firstScores[1] < secondScores[1] ? firstTeam : secondTeam;
                    looser = firstScores[1] >= secondScores[1] ? firstTeam : secondTeam;
                }
                else
                {
                    winner = scoresFirstTeam > scoresSecondTeam ? firstTeam : secondTeam;
                    looser = scoresFirstTeam <= scoresSecondTeam ? firstTeam : secondTeam;
                }

                teams[winner][looser]++;

                line = Console.ReadLine();
            }

            var orderedTeams = teams
                .OrderByDescending(t => t.Value.Sum(w => w.Value))
                .ThenBy(t => t.Key);

            foreach (var team in orderedTeams)
            {
                Console.WriteLine(team.Key);
                Console.WriteLine($"- Wins: {team.Value.Sum(w => w.Value)}");
                Console.WriteLine($"- Opponents: " + string.Join(", ", team.Value.Keys));
            }
        }
    }
}
