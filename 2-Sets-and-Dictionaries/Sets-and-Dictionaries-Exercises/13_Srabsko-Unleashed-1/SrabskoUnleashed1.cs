namespace _13_Srabsko_Unleashed_1
{
    using System;     
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SrabskoUnleashed1
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, int>> venues =
                new Dictionary<string, Dictionary<string, int>>();
            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] venueTokens = line
                    .Split(new string[] { " @" },
                    StringSplitOptions.RemoveEmptyEntries);

                if (venueTokens.Length <= 1)
                {
                    line = Console.ReadLine();
                    continue;
                }

                string singer = venueTokens[0];

                string[] venueAndTickets = venueTokens[1].Split(' ');

                int ticketPrice = 0;
                int ticketCount = 0;

                try
                {
                    ticketPrice = int.Parse(venueAndTickets[venueAndTickets.Length - 2]);
                    ticketCount = int.Parse(venueAndTickets[venueAndTickets.Length - 1]);
                }
                catch (Exception)
                {
                    line = Console.ReadLine();
                    continue;
                }

                StringBuilder venue = new StringBuilder();

                for (int i = 0; i < venueAndTickets.Length - 2; i++)
                {
                    venue.Append(venueAndTickets[i]);
                    venue.Append(" ");
                }

                if (venues.ContainsKey(venue.ToString()))
                {
                    if (venues[venue.ToString()].ContainsKey(singer))
                    {
                        venues[venue.ToString()][singer] += ticketPrice * ticketCount;
                    }
                    else
                    {
                        venues[venue.ToString()].Add(singer, ticketPrice * ticketCount);
                    }
                }
                else
                {
                    venues[venue.ToString()] =
                    new Dictionary<string, int>() { { singer, ticketPrice * ticketCount } };
                }

                line = Console.ReadLine();
            }

            foreach (var venue in venues)
            {
                Console.WriteLine(venue.Key);

                foreach (var singer in venue.Value.OrderByDescending(s => s.Value))
                {
                    Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
                }
            }
        }
    }
}
