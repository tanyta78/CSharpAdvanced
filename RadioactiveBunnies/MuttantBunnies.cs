namespace RadioactiveBunnies
{
    using System;
    using System.Linq;

    public class MuttantBunnies
    {
        public static void Main()
        {
            int[] input = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];

            char[][] lairMatrix = new char[rows][];

            int playerRow = 0;
            int playerCol = 0;
            //read matrix
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                lairMatrix[rowIndex] = Console.ReadLine().ToCharArray();
                if (lairMatrix[rowIndex].Contains('P'))
                {
                    playerCol = Array.IndexOf(lairMatrix[rowIndex], 'P');
                    playerRow = rowIndex;
                }
            }
            //read player comands
            char[] comands = Console.ReadLine().ToCharArray();
            bool isDead = false;
            bool isWin = false;
            for (int i = 0; i < comands.Length; i++)
            {
                //switch current comand
                PlayCurrentCommand(rows, cols, lairMatrix, ref playerRow, ref playerCol, comands, ref isDead, ref isWin, i);

                //bunies moves in temp matrix
                MoveBunnies(rows, cols, ref lairMatrix, ref isDead);

                if (isWin)
                {
                    isDead = false;
                    break;
                }

                if (isDead)
                {
                    break;
                }
            }
            //print result

            for (int rIndex = 0; rIndex < rows; rIndex++)
            {
                for (int cIndex = 0; cIndex < cols; cIndex++)
                {
                    Console.Write(lairMatrix[rIndex][cIndex]);
                }
                Console.WriteLine();
            }

            if (isWin)
            {
                Console.WriteLine($"won: {playerRow} {playerCol} ");
            }
            else
            {
                Console.WriteLine($"dead: {playerRow} {playerCol} ");

            }


        }

        private static void MoveBunnies(int rows, int cols, ref char[][] lairMatrix, ref bool isDead)
        {
            char[][] tempMatrix = new char[rows][];
            for (int rIndex = 0; rIndex < rows; rIndex++)
            {
                tempMatrix[rIndex] = new char[cols];
                for (int cIndex = 0; cIndex < cols; cIndex++)
                {
                    tempMatrix[rIndex][cIndex] = lairMatrix[rIndex][cIndex];
                }


            }


            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    if (lairMatrix[rowIndex][colIndex] == 'B')
                    {
                        if (rowIndex > 0)
                        {
                            if (lairMatrix[rowIndex - 1][colIndex] == 'P')
                            {
                                isDead = true;

                            }
                            tempMatrix[rowIndex - 1][colIndex] = 'B';
                        }
                        if (rowIndex < rows - 1)
                        {
                            if (lairMatrix[rowIndex + 1][colIndex] == 'P')
                            {
                                isDead = true;

                            }
                            tempMatrix[rowIndex + 1][colIndex] = 'B';
                        }
                        if (colIndex > 0)
                        {
                            if (lairMatrix[rowIndex][colIndex - 1] == 'P')
                            {
                                isDead = true;
                            }
                            tempMatrix[rowIndex][colIndex - 1] = 'B';
                        }
                        if (colIndex < cols - 1)
                        {
                            if (lairMatrix[rowIndex][colIndex + 1] == 'P')
                            {
                                isDead = true;
                            }
                            tempMatrix[rowIndex][colIndex + 1] = 'B';
                        }
                    }

                }
            }

            lairMatrix = tempMatrix;
        }

        private static void PlayCurrentCommand(int rows, int cols, char[][] lairMatrix, ref int playerRow, ref int playerCol, char[] comands, ref bool isDead, ref bool isWin, int i)
        {
            switch (comands[i])
            {
                case 'U':
                    if (playerRow == 0)
                    {
                        isWin = true;
                        lairMatrix[playerRow][playerCol] = '.';
                    }
                    else
                    {
                        if (lairMatrix[playerRow - 1][playerCol] == 'B')
                        {
                            isDead = true;
                        }
                        else
                        {
                            lairMatrix[playerRow - 1][playerCol] = 'P';
                            lairMatrix[playerRow][playerCol] = '.';
                        }
                        playerRow--;
                    }
                    break;
                case 'D':
                    if (playerRow == rows - 1)
                    {
                        isWin = true;
                        lairMatrix[playerRow][playerCol] = '.';
                    }
                    else
                    {
                        if (lairMatrix[playerRow + 1][playerCol] == 'B')
                        {
                            isDead = true;
                        }
                        else
                        {

                            lairMatrix[playerRow + 1][playerCol] = 'P';
                            lairMatrix[playerRow][playerCol] = '.';
                        }
                        playerRow++;
                    }
                    break;
                case 'L':
                    if (playerCol == 0)
                    {
                        isWin = true;
                        lairMatrix[playerRow][playerCol] = '.';
                    }
                    else
                    {
                        if (lairMatrix[playerRow][playerCol - 1] == 'B')
                        {
                            isDead = true;
                        }
                        else
                        {
                            lairMatrix[playerRow][playerCol - 1] = 'P';
                            lairMatrix[playerRow][playerCol] = '.';

                        }
                        playerCol--;
                    }
                    break;
                case 'R':
                    if (playerCol == cols - 1)
                    {
                        isWin = true;
                        lairMatrix[playerRow][playerCol] = '.';
                    }
                    else
                    {
                        if (lairMatrix[playerRow][playerCol + 1] == 'B')
                        {
                            isDead = true;
                        }
                        else
                        {
                            lairMatrix[playerRow][playerCol + 1] = 'P';
                            lairMatrix[playerRow][playerCol] = '.';

                        }
                        playerCol++;
                    }
                    break;

            }
        }
    }
}
