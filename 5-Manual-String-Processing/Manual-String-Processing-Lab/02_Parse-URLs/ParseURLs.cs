namespace _02_Parse_URLs
{
    using System;

    public class ParseURLs
    {
        public static void Main()
        {
            string urlAddress = Console.ReadLine();
            string[] urlProtocolTokens = urlAddress.Trim()
                .Split(new string[] { "://" },
                StringSplitOptions.RemoveEmptyEntries);

            if (urlProtocolTokens.Length != 2)
            {
                Console.WriteLine("Invalid URL");
                return;
            }
            else
            {
                string protocol = urlProtocolTokens[0];

                int dashIndex = urlProtocolTokens[1].IndexOf("/");

                if (dashIndex == -1)
                {
                    Console.WriteLine("Invalid URL");
                    return;
                }

                string server = urlProtocolTokens[1]
                    .Substring(0, dashIndex);
                string resources = urlProtocolTokens[1]
                    .Substring(dashIndex + 1);

                Console.WriteLine($"Protocol = {protocol}");
                Console.WriteLine($"Server = {server}");
                Console.WriteLine($"Resources = {resources}");
            }
        }
    }
}
