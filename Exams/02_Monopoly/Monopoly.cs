namespace _02_Monopoly
{
    using System;
    using System.Linq;

    public class Monopoly
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            char[][] matrix = new char[rows][];

            for (int currRow = 0; currRow < rows; currRow++)
            {
                matrix[currRow] = Console.ReadLine().ToCharArray();
            }

            long money = 50L;
            long turnsCount = 0L;
            char currElement;
            int hotelsCount = 0;

            for (int currRow = 0; currRow < rows; currRow++)
            {
                int col = cols - 1;
                int colForShop = 0;

                for (int currCol = 0; currCol < cols; currCol++)
                {
                    if (currRow % 2 == 0)
                    {
                        currElement = matrix[currRow][currCol];
                    }
                    else
                    {
                        currElement = matrix[currRow][col];
                        colForShop = col;
                        col--;
                    }

                    if (currElement == 'H')
                    {
                        Console.Write($"Bought a hotel for {money}. ");
                        money = 0;
                        hotelsCount++;
                        money += hotelsCount * 10;
                        turnsCount++;
                        Console.WriteLine($"Total hotels: {hotelsCount}.");
                    }
                    else if (currElement == 'J')
                    {
                        Console.WriteLine($"Gone to jail at turn {turnsCount}.");
                        turnsCount += 3;
                        money += 3 * (hotelsCount * 10);
                    }
                    else if (currElement == 'F')
                    {
                        turnsCount++;
                        money += hotelsCount * 10;
                    }
                    else if (currElement == 'S')
                    {
                        turnsCount++;
                        money += hotelsCount * 10;
                        long spentInShop = 0;

                        if (currRow % 2 == 0)
                        {
                            spentInShop = (currRow + 1) * (currCol + 1);                            
                        }
                        else
                        {
                            spentInShop = (currRow + 1) * (colForShop + 1);
                        }

                        if (spentInShop >= money)
                        {
                            Console.WriteLine($"Spent {money} money at the shop.");
                            money = 0;
                        }
                        else
                        {
                            money -= spentInShop;
                            Console.WriteLine($"Spent {spentInShop} money at the shop.");
                        }                       
                    }
                }
            }

            Console.WriteLine($"Turns {turnsCount}");
            Console.WriteLine($"Money {money}");
        }
    }
}
