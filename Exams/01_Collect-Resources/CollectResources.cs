namespace _01_Collect_Resources
{
    using System;
    using System.Linq;

    public class CollectResources
    {
        public static void Main()
        {
            string[] resources = Console.ReadLine()
                .Trim()
                .Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);
            int pathsNumber = int.Parse(Console.ReadLine());
            long maxCount = long.MinValue;

            for (int currPath = 0; currPath < pathsNumber; currPath++)
            {
                string[] currResources = new string[resources.Length];  // with currResources = resources elements
                Array.Copy(resources, currResources, resources.Length); // in both arrays changed
                long resourcesCount = 0;

                int[] args = Console.ReadLine()
                    .Trim()
                    .Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int start = args[0];
                int step = args[1];

                while (true)
                { 
                    while (start >= currResources.Length)
                    {
                        start = start - currResources.Length;
                    }

                    string currResource = currResources[start];

                    if (currResource == "0")
                    {
                        break;
                    }

                    if (currResource.Contains("_"))
                    {
                        string[] resourceTokens = currResource.Split('_');
                        bool isResourceValid = IsResourceValid(resourceTokens[0]);

                        if (isResourceValid)
                        {
                            resourcesCount += int.Parse(resourceTokens[1]);
                            currResources[start] = "0";
                        }
                    }
                    else
                    {
                        bool isResourceValid = IsResourceValid(currResource);

                        if (isResourceValid)
                        {
                            resourcesCount += 1;
                            currResources[start] = "0";
                        }
                    }

                    start += step;                 
                }

                if (resourcesCount > maxCount)
                {
                    maxCount = resourcesCount;
                }
            }

            Console.WriteLine(maxCount);
        }

        private static bool IsResourceValid(string resource)
        {
            if (resource == "stone" || resource == "gold" ||
                resource == "wood" || resource == "food")
            {
                return true;
            }

            return false;
        }
    }
}
