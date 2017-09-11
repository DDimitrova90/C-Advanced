namespace _01_Second_Nature
{
    using System;   
    using System.Collections.Generic;
    using System.Linq;

    public class SecondNature
    {
        public static void Main()
        {
            Queue<int> flowers = new Queue<int>(Console.ReadLine().Split(new[] { ' ', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> waters = new Stack<int>(Console.ReadLine().Split(new[] { ' ', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            List<int> flow = new List<int>();

            while (waters.Count > 0 && flowers.Count > 0)
            {
                int currentBucket = waters.Pop();
                int currentFlower = flowers.Dequeue();

                if (currentBucket > currentFlower)
                {
                    int water = 0;
                    if (waters.Count >= 1)
                    {
                        water = waters.Pop();
                    }
                    int lastBucket = (currentBucket - currentFlower) + water;
                    waters.Push(lastBucket);
                }
                else if (currentBucket == currentFlower)
                {
                    flow.Add(currentFlower);
                }
                else
                {
                    int[] flows = flowers.ToArray();
                    flowers.Clear();
                    flowers.Enqueue(currentFlower - currentBucket);
                    foreach (var item in flows)
                    {
                        flowers.Enqueue(item);
                    }
                }
            }

            if (waters.Count < flowers.Count)
            {
                Console.WriteLine(string.Join(" ", flowers.ToArray()));
            }
            else
            {
                Console.WriteLine(string.Join(" ", waters.ToArray()));
            }
            if (flow.Count > 0)
            {
                Console.WriteLine(string.Join(" ", flow));
            }
            else
            {
                Console.WriteLine("None");
            }
        }
    }
}
