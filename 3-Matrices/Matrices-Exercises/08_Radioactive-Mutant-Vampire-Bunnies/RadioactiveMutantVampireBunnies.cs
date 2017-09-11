namespace _08_Radioactive_Mutant_Vampire_Bunnies
{
    using System;     
    using System.Linq;

    public class RadioactiveMutantVampireBunnies
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Trim()
                .Split(new char[] { ' ' }, 
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];
            char[][] lair = new char[rows][];

            FillLair(lair, cols, rows);

            string command = Console.ReadLine();

            bool hasGameEnd = false;

            for (int i = 0; i < command.Length; i++)
            {
                if (!hasGameEnd)
                {
                    hasGameEnd = ExecuteCommand(lair, rows, cols, command[i], hasGameEnd);
                }
            }
        }

        public static bool ExecuteCommand(char[][] lair, int rows, int cols, char command, bool hasGameEnd)
        {
            int playerRow = 0;
            int playerCol = 0;

            for (int currRow = 0; currRow < rows; currRow++)
            {
                if (lair[currRow].Contains('P'))
                {
                    playerRow = currRow;

                    for (int currCol = 0; currCol < cols; currCol++)
                    {
                        if (lair[currRow][currCol] == 'P')
                        {
                            playerCol = currCol;
                            break;
                        }
                    }
                }
            }

            if (command == 'R')
            {
                hasGameEnd = MovePlayerRight(lair, rows, cols, playerRow, playerCol, hasGameEnd);
            }
            else if (command == 'L')
            {
                hasGameEnd = MovePlayerLeft(lair, rows, cols, playerRow, playerCol, hasGameEnd);
            }
            else if (command == 'U')
            {
                hasGameEnd = MovePlayerUp(lair, rows, cols, playerRow, playerCol, hasGameEnd);
            }
            else if (command == 'D')
            {
                hasGameEnd = MovePlayerDown(lair, rows, cols, playerRow, playerCol, hasGameEnd);
            }

            return hasGameEnd;
        }

        public static bool MovePlayerDown(char[][] lair, int rows, int cols, int playerRow, int playerCol, bool hasGameEnd)
        {
            if (playerRow + 1 < rows && lair[playerRow + 1][playerCol] == '.')
            {
                lair[playerRow + 1][playerCol] = 'P';
                lair[playerRow][playerCol] = '.';
                MultipliesBunnies(lair, rows, cols, playerRow, playerCol);
            }
            else if (playerRow + 1 >= rows)
            {
                lair[playerRow][playerCol] = '.';
                MultipliesBunnies(lair, rows, cols, playerRow, playerCol);
                PrintLair(lair, rows, cols);
                Console.WriteLine($"won: {playerRow} {playerCol}");
                hasGameEnd = true;
            }
            else if (lair[playerRow + 1][playerCol] == 'B')
            {
                MultipliesBunnies(lair, rows, cols, playerRow, playerCol);
                PrintLair(lair, rows, cols);
                Console.WriteLine($"dead: {playerRow + 1} {playerCol}");
                hasGameEnd = true;
            }

            return hasGameEnd;
        }

        public static void MultipliesBunnies(char[][] lair, int rows, int cols, int playerRow, int playerCol)
        {
            bool isDead = false;

            for (int currRow = 0; currRow < rows; currRow++)
            {
                for (int currCol = 0; currCol < cols; currCol++)
                {
                    if (lair[currRow][currCol] == 'B')
                    {
                        lair[currRow][currCol] = '*';
                    }
                }
            }

            for (int currRow = 0; currRow < rows; currRow++)
            {
                for (int currCol = 0; currCol < cols; currCol++)
                {
                    char currChar = lair[currRow][currCol];

                    if (currChar == '*')
                    {
                        if (currCol + 1 < cols)
                        {
                            if (lair[currRow][currCol + 1] == '.')
                            {
                                lair[currRow][currCol + 1] = 'B';
                            }
                            else if (lair[currRow][currCol + 1] == 'P')
                            {
                                isDead = true;
                                lair[currRow][currCol + 1] = 'B';
                            }
                        }

                        if (currCol - 1 >= 0)
                        {
                            if (lair[currRow][currCol - 1] == '.')
                            {
                                lair[currRow][currCol - 1] = 'B';
                            }
                            else if (lair[currRow][currCol - 1] == 'P')
                            {
                                isDead = true;
                                lair[currRow][currCol - 1] = 'B';
                            }
                        }

                        if (currRow - 1 >= 0)
                        {
                            if (lair[currRow - 1][currCol] == '.')
                            {
                                lair[currRow - 1][currCol] = 'B';
                            }
                            else if (lair[currRow - 1][currCol] == 'P')
                            {
                                isDead = true;
                                lair[currRow - 1][currCol] = 'B';
                            }
                        }

                        if (currRow + 1 < rows)
                        {
                            if (lair[currRow + 1][currCol] == '.')
                            {
                                lair[currRow + 1][currCol] = 'B';
                            }
                            else if (lair[currRow + 1][currCol] == 'P')
                            {
                                isDead = true;
                                lair[currRow + 1][currCol] = 'B';
                            }
                        }
                    }
                }
            }

            for (int currRow = 0; currRow < rows; currRow++)
            {
                for (int currCol = 0; currCol < cols; currCol++)
                {
                    if (lair[currRow][currCol] == '*')
                    {
                        lair[currRow][currCol] = 'B';
                    }
                }
            }

            if (isDead)
            {
                PrintLair(lair, rows, cols);
                Console.WriteLine($"dead: {playerRow} {playerCol}");
                return;
            }
        }

        public static bool MovePlayerUp(char[][] lair, int rows, int cols, int playerRow, int playerCol, bool hasGameEnd)
        {
            if (playerRow - 1 >= 0 && lair[playerRow - 1][playerCol] == '.')
            {
                lair[playerRow - 1][playerCol] = 'P';
                lair[playerRow][playerCol] = '.';
                MultipliesBunnies(lair, rows, cols, playerRow, playerCol);
            }
            else if (playerRow - 1 < 0)
            {
                MultipliesBunnies(lair, rows, cols, playerRow, playerCol);
                PrintLair(lair, rows, cols);
                Console.WriteLine($"won: {playerRow} {playerCol}");
                hasGameEnd = true;
            }
            else if (lair[playerRow - 1][playerCol] == 'B')
            {
                lair[playerRow][playerCol] = '.';
                MultipliesBunnies(lair, rows, cols, playerRow, playerCol);
                PrintLair(lair, rows, cols);
                Console.WriteLine($"dead: {playerRow - 1} {playerCol}");
                hasGameEnd = true;
            }

            return hasGameEnd;
        }

        public static bool MovePlayerLeft(char[][] lair, int rows, int cols, int playerRow, int playerCol, bool hasGameEnd)
        {
            if (playerCol - 1 >= 0 && lair[playerRow][playerCol - 1] == '.')
            {
                lair[playerRow][playerCol - 1] = 'P';
                lair[playerRow][playerCol] = '.';
                MultipliesBunnies(lair, rows, cols, playerRow, playerCol);
            }
            else if (playerCol - 1 < 0)
            {
                lair[playerRow][playerCol] = '.';
                MultipliesBunnies(lair, rows, cols, playerRow, playerCol);
                PrintLair(lair, rows, cols);
                Console.WriteLine($"won: {playerRow} {playerCol}");
                hasGameEnd = true;
            }
            else if (lair[playerRow][playerCol - 1] == 'B')
            {
                lair[playerRow][playerCol] = '.';
                MultipliesBunnies(lair, rows, cols, playerRow, playerCol);
                PrintLair(lair, rows, cols);
                Console.WriteLine($"dead: {playerRow} {playerCol - 1}");
                hasGameEnd = true;
            }

            return hasGameEnd;
        }

        public static bool MovePlayerRight(char[][] lair, int rows, int cols, int playerRow, int playerCol, bool hasGameEnd)
        {
            if (playerCol + 1 < cols && lair[playerRow][playerCol + 1] == '.')
            {
                lair[playerRow][playerCol + 1] = 'P';
                lair[playerRow][playerCol] = '.';
                MultipliesBunnies(lair, rows, cols, playerRow, playerCol);
            }
            else if (playerCol + 1 >= cols)
            {
                lair[playerRow][playerCol] = '.';
                MultipliesBunnies(lair, rows, cols, playerRow, playerCol);
                PrintLair(lair, rows, cols);
                Console.WriteLine($"won: {playerRow} {playerCol}");
                hasGameEnd = true;
            }
            else if (lair[playerRow][playerCol + 1] == 'B')
            {
                lair[playerRow][playerCol] = '.';
                MultipliesBunnies(lair, rows, cols, playerRow, playerCol);
                PrintLair(lair, rows, cols);
                Console.WriteLine($"dead: {playerRow} {playerCol + 1}");
                hasGameEnd = true;
            }

            return hasGameEnd;
        }

        public static void PrintLair(char[][] lair, int rows, int cols)
        {
            for (int currRow = 0; currRow < rows; currRow++)
            {
                Console.WriteLine(string.Join("", lair[currRow]));
            }
        }

        public static void FillLair(char[][] lair, int cols, int rows)
        {
            for (int currRow = 0; currRow < rows; currRow++)
            {
                lair[currRow] = Console.ReadLine().ToCharArray();
            }
        }
    }
}
