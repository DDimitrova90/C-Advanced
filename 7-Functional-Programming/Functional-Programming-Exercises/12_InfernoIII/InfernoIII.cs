namespace _12_InfernoIII
{
    using System;      
    using System.Collections.Generic;
    using System.Linq;

    public class InfernoIII
    {
        public static void Main()
        {
            List<int> gems = Console.ReadLine()
                .Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            List<int> positionsToRemove = new List<int>();

            string currCommand = Console.ReadLine();

            while (currCommand != "Forge")
            {
                string[] commandTokens = currCommand
                    .Split(new char[] { ';' },
                    StringSplitOptions.RemoveEmptyEntries);
                string command = commandTokens[0];
                string filterType = commandTokens[1];
                int filterParameter = int.Parse(commandTokens[2]);

                if (command == "Exclude")
                {
                    if (filterType == "Sum Left")
                    {
                        if (gems[0] == filterParameter)
                        {
                            positionsToRemove.Add(0);
                        }

                        for (int i = 1; i < gems.Count; i++)
                        {
                            if (gems[i] + gems[i - 1] == filterParameter)
                            {
                                positionsToRemove.Add(i);
                            }
                        }
                    }
                    else if (filterType == "Sum Right")
                    {
                        if (gems[gems.Count - 1] == filterParameter)
                        {
                            positionsToRemove.Add(gems.Count - 1);
                        }

                        for (int i = 0; i < gems.Count - 1; i++)
                        {
                            if (gems[i] + gems[i + 1] == filterParameter)
                            {
                                positionsToRemove.Add(i);
                            }
                        }
                    }
                    else if (filterType == "Sum Left Right")
                    {
                        if (gems[0] + gems[1] == filterParameter)
                        {
                            positionsToRemove.Add(0);
                        }

                        if (gems[gems.Count - 1] + gems[gems.Count - 2] == filterParameter)
                        {
                            positionsToRemove.Add(gems.Count - 1);
                        }

                        for (int i = 1; i < gems.Count - 1; i++)
                        {
                            if (gems[i] + gems[i - 1] + gems[i + 1] == filterParameter)
                            {
                                positionsToRemove.Add(i);
                            }
                        }
                    }
                }
                else if (command == "Reverse")
                {
                    if (filterType == "Sum Left")
                    {
                        if (gems[0] == filterParameter)
                        {
                            positionsToRemove.Remove(0);
                        }

                        for (int i = 1; i < gems.Count; i++)
                        {
                            if (gems[i] + gems[i - 1] == filterParameter)
                            {
                                positionsToRemove.Remove(i);
                            }
                        }
                    }
                    else if (filterType == "Sum Right")
                    {
                        if (gems[gems.Count - 1] == filterParameter)
                        {
                            positionsToRemove.Remove(gems.Count - 1);
                        }

                        for (int i = 0; i < gems.Count - 1; i++)
                        {
                            if (gems[i] + gems[i + 1] == filterParameter)
                            {
                                positionsToRemove.Remove(i);
                            }
                        }
                    }
                    else if (filterType == "Sum Left Right")
                    {
                        if (gems[0] + gems[1] == filterParameter)
                        {
                            positionsToRemove.Remove(0);
                        }

                        if (gems[gems.Count - 1] + gems[gems.Count - 2] == filterParameter)
                        {
                            positionsToRemove.Remove(gems.Count - 1);
                        }

                        for (int i = 1; i < gems.Count - 1; i++)
                        {
                            if (gems[i] + gems[i - 1] + gems[i + 1] == filterParameter)
                            {
                                positionsToRemove.Remove(i);
                            }
                        }
                    }
                }

                currCommand = Console.ReadLine();
            }

            foreach (var pos in positionsToRemove.Distinct().OrderByDescending(p => p))
            {
                gems.RemoveAt(pos);
            }

            Console.WriteLine(string.Join(" ", gems));
        }
    }
}
