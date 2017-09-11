namespace _03_Jedi_Code_X
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class JediCodeX
    {
        public static void Main()
        {
            int linesCount = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();

            for (int currLine = 0; currLine < linesCount; currLine++)
            {
                sb.Append(Console.ReadLine().Trim());
            }

            string namePattern = Console.ReadLine();
            string messagePattern = Console.ReadLine();

            string nameRgxPattern = namePattern +  @"([A-Za-z]{" + namePattern.Length + "})(?![a-zA-Z])";
            string messageRgxPattern = messagePattern +  @"([A-Za-z0-9]{" + messagePattern.Length + @"})(?![a-zA-Z0-9])";

            List<string> names = new List<string>();
            List<string> messages = new List<string>();

            Regex rgxNames = new Regex(nameRgxPattern);
            Regex rgxMessages = new Regex(messageRgxPattern);
            MatchCollection namesMatches = rgxNames.Matches(sb.ToString());
            MatchCollection messagesMatches = rgxMessages.Matches(sb.ToString());

            foreach (Match name in namesMatches)
            {
                names.Add(name.Groups[1].Value);
            }

            foreach (Match message in messagesMatches)
            {
                messages.Add(message.Groups[1].Value);
            }

            int[] messageIndexes = Console.ReadLine()
                .Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int currNameIndex = 0;
            List<string> result = new List<string>();

            for (int i = 0; i < messageIndexes.Length; i++)
            {
                if (messageIndexes[i] - 1 < messages.Count)
                {
                    result.Add($"{names[currNameIndex]} - {messages[messageIndexes[i] - 1]}");
                    currNameIndex++;
                }

                if (currNameIndex >= names.Count) break;
            }

            Console.WriteLine(string.Join("\n", result));
        }
    }
}
