using System;

namespace HaiganDance
{
    public class HaiganSpell
    {
        private const int Size = 15;
        private const int CloudDamage = 3500;
        private const int EruptionDamage = 6000;
        private const double PlayerHealth = 18500;
        private const double HaiganHealth = 3000000;

        public static void Main()
        {
            var playerPos = new int[] { Size / 2, Size / 2 };
            var heihanPoints = HaiganHealth;
            var playerPoint = PlayerHealth;
            var isHeiganDead = false;
            var isPlayerDead = false;
            var hasCloud = false;
            var deathCouse = String.Empty;
            var damageToHaigan = double.Parse(Console.ReadLine());

            while (true)
            {
                var spellTokens = Console.ReadLine().Split();

                var spell = spellTokens[0];
                var spellRow = int.Parse(spellTokens[1]);
                var spellCol = int.Parse(spellTokens[2]);

                heihanPoints -= damageToHaigan;
                isHeiganDead = heihanPoints <= 0;
                isPlayerDead = playerPoint <= 0;

                if (hasCloud)
                {
                    playerPoint -= CloudDamage;
                    hasCloud = false;
                    isPlayerDead = playerPoint <= 0;
                }

                if (isHeiganDead || isPlayerDead)
                {
                    break;
                }

                if (IsPlayerInDamageZone(playerPos, spellRow, spellCol))
                {
                    if (!PlayerTryEscape(playerPos, spellRow, spellCol))
                    {
                        switch (spell)
                        {
                            case "Cloud":
                                playerPoint -= CloudDamage;
                                hasCloud = true;
                                deathCouse = "Plague Cloud";
                                break;

                            case "Eruption":
                                playerPoint -= EruptionDamage;
                                deathCouse = spell;
                                break;
                        }
                    }
                }

                isPlayerDead = playerPoint <= 0;
                if (isPlayerDead)
                {
                    break;
                }
            }

            PrintResult(playerPos, heihanPoints, playerPoint, deathCouse);
        }

        private static void PrintResult(int[] playerPos, double heihanPoints, double playerPoint, string deathCouse)
        {
            if (heihanPoints <= 0)
            {
                Console.WriteLine("Heigan: Defeated!");
            }
            else
            {
                Console.WriteLine($"Heigan: {heihanPoints:f2}");
            }

            if (playerPoint <= 0)
            {
                Console.WriteLine($"Player: Killed by {deathCouse}");
            }
            else
            {
                Console.WriteLine($"Player: {playerPoint}");
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
            else if (playerPos[1] + 1 < Size && playerPos[1] + 1 > spellCol + 1)
            {
                playerPos[1]++;
                return true;
            }
            else if (playerPos[0] + 1 < Size && playerPos[0] + 1 > spellRow + 1)
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

        private static bool IsPlayerInDamageZone(int[] playerPos, int spellRow, int spellCol)
        {
            return (playerPos[0] >= spellRow - 1 && playerPos[0] <= spellRow + 1) &&
                   (playerPos[1] >= spellCol - 1 && playerPos[1] <= spellCol + 1);
        }
    }
}