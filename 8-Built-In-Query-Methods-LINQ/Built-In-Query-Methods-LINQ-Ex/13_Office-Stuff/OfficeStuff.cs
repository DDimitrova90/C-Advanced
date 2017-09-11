namespace _13_Office_Stuff
{
    using System;
    using System.Collections.Generic;

    public class OfficeStuff
    {
        public static void Main()
        {
            int ordersCount = int.Parse(Console.ReadLine());

            SortedDictionary<string, Dictionary<string, int>> companies = 
                new SortedDictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < ordersCount; i++)
            {
                string[] lineToneks = Console.ReadLine()
                    .Split(new char[] { ' ', '-', '|' }, 
                    StringSplitOptions.RemoveEmptyEntries);
                string company = lineToneks[0];
                int amount = int.Parse(lineToneks[1]);
                string product = lineToneks[2];

                if (!companies.ContainsKey(company))
                {
                    companies.Add(company, new Dictionary<string, int>());
                }

                if (!companies[company].ContainsKey(product))
                {
                    companies[company].Add(product, 0);
                }

                companies[company][product] += amount;
            }     

            foreach (var company in companies)
            {
                List<string> products = new List<string>();

                foreach (var product in company.Value)
                {
                    products.Add(product.Key + "-" + product.Value);
                }

                Console.WriteLine($"{company.Key}: {string.Join(", ", products)}");
            }
        }
    }
}
