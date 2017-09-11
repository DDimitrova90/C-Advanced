namespace _10_The_Heigan_Dance_1
{
    using System;      

    public class TheHeiganDance1
    {
        private const int ChamberSize = 15;
        private const int CloudDamage = 3500;
        private const int EruptionDamage = 6000;
        private const double PlayerHealth = 18500;
        private const double HeiganHealth = 3000000;

        public static void Main()
        {
            int[] playerPos = new int[] { ChamberSize / 2, ChamberSize / 2 };
            double heiganPoints = HeiganHealth;
            double playerPoints = PlayerHealth;
            bool isHeiganDead = false;
            bool isPlayerDead = false;
            bool hasCloud = false;
            string deathCause = "";

            double damageToHeigan = double.Parse(Console.ReadLine());

            while (true)
            {
                string[] spellTokens = Console.ReadLine().Split();
                string spell = spellTokens[0];
                int spellRow = int.Parse(spellTokens[1]);
                int spellCol = int.Parse(spellTokens[2]);

                heiganPoints -= damageToHeigan;
                isHeiganDead = heiganPoints <= 0;

                if (hasCloud)
                {
                    playerPoints -= CloudDamage;
                    hasCloud = false;
                    isPlayerDead = playerPoints <= 0;
                }

                if (isHeiganDead || isPlayerDead)
                {
                    break;
                }

                if (IsPlayerInDamagedZone(playerPos, spellRow, spellCol))
                {
                    if (!PlayerTryEscape(playerPos, spellRow, spellCol))
                    {
                        switch (spell)
                        {
                            case "Cloud":
                                playerPoints -= CloudDamage;
                                hasCloud = true;
                                deathCause = "Plague Cloud";
                                break;
                            case "Eruption":
                                playerPoints -= EruptionDamage;
                                deathCause = spell;
                                break;
                        }
                    }
                }

                isPlayerDead = playerPoints <= 0;

                if (isPlayerDead)
                {
                    break;
                }
            }

            PrintResult(playerPos, playerPoints, heiganPoints, deathCause);
        }

        private static void PrintResult(int[] playerPos, double playerPoints, double heiganPoints, string deathCause)
        {
            if (heiganPoints <= 0)
            {
                Console.WriteLine("Heigan: Defeated!");
            }
            else
            {
                Console.WriteLine($"Heigan: {heiganPoints:F2}");
            }

            if (playerPoints <= 0)
            {
                Console.WriteLine($"Player: Killed by {deathCause}");
            }
            else
            {
                Console.WriteLine($"Player: {playerPoints}");
            }

            Console.WriteLine($"Final position: {playerPos[0]}, {playerPos[1]}");
        }

        private static bool PlayerTryEscape(int[] playerPos, int spellRow, int spellCol)
        {
            if (playerPos[0] - 1 >= 0 && playerPos[0] - 1 < spellRow - 1)
            {
                playerPos[0]--;
                return true;
            }
            else if (playerPos[1] + 1 < ChamberSize && playerPos[1] + 1 > spellCol + 1)
            {
                playerPos[1]++;
                return true;
            }
            else if (playerPos[0] + 1 < ChamberSize && playerPos[0] + 1 > spellRow + 1)
            {
                playerPos[0]++;
                return true;
            }
            else if (playerPos[1] - 1 >= 0 && playerPos[1] - 1 < spellCol - 1)
            {
                playerPos[1]--;
                return true;
            }

            return false;
        }

        private static bool IsPlayerInDamagedZone(int[] playerPos, int spellRow, int spellCol)
        {
            bool isHitRow = playerPos[0] >= spellRow - 1 && playerPos[0] <= spellRow + 1;
            bool isHitCol = playerPos[1] >= spellCol - 1 && playerPos[1] <= spellCol + 1;

            return isHitCol && isHitRow;
        }
    }
}
