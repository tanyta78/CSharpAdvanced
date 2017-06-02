namespace TargetPractise
{
    using System;
    using System.Linq;

    public static class TargetPractise
    {
        public static void Main()
        {

            string[] dimensions = Console.ReadLine().Split().ToArray();
            int totalRows = int.Parse(dimensions[0]);
            int totalCols = int.Parse(dimensions[1]);

            string snake = Console.ReadLine();
            string[] input = Console.ReadLine().Split().ToArray();
            int impactRow = int.Parse(input[0]);
            int impactCol = int.Parse(input[1]);
            int raduis = int.Parse(input[2]);

            char[,] matrix = new char[totalRows, totalCols];
            int index = 0;
            string direction = "left";
            for (int row = totalRows - 1; row >= 0; row--)
            {
                if (direction == "left")
                {
                    int col = totalCols - 1;
                    while (col >= 0)
                    {
                        if (index == snake.Length)
                        {
                            index = 0;
                        }
                        matrix[row, col] = snake[index];
                        index++;
                        col--;
                    }
                    direction = "right";
                }
                else if (direction == "right")
                {
                    int col = 0;
                    while (col < totalCols)
                    {
                        if (index == snake.Length)
                        {
                            index = 0;
                        }
                        matrix[row, col] = snake[index];
                        index++;
                        col++;
                    }
                    direction = "left";
                }
            }

            for (int row = impactRow - raduis; row <= impactRow + raduis; row++)
            {
                if (row >= 0 && row < totalRows)
                {
                    for (int col = impactCol - raduis; col <= impactCol + raduis; col++)
                    {
                        if (col >= 0 && col < totalCols)
                        {
                            if (IsCellWithinRadius(row, col, impactRow, impactCol, raduis))
                            {
                                matrix[row, col] = ' ';
                            }
                        }
                    }
                }
            }

            for (int col = 0; col < totalCols; col++)
            {
                DropChar(matrix, col);
            }

            for (int i = 0; i < totalRows; i++)
            {
                for (int j = 0; j < totalCols; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        static bool IsCellWithinRadius(int currRow, int currCol, int centerRow, int centerCol, int radius)
        {
            bool isInRange = false;
            isInRange = ((currRow - centerRow) * (currRow - centerRow)) + ((currCol - centerCol) * (currCol - centerCol)) <= radius * radius;

            return isInRange;
        }

        static void DropChar(char[,] matrix, int col)
        {
            while (true)
            {
                bool hasFallen = false;
                for (int row = 1; row < matrix.GetLength(0); row++)
                {
                    char topChar = matrix[row - 1, col];
                    char currentChar = matrix[row, col];
                    if (currentChar == ' ' && topChar != ' ')
                    {
                        matrix[row, col] = topChar;
                        matrix[row - 1, col] = ' ';
                        hasFallen = true;
                    }
                }

                if (!hasFallen)
                {
                    break;
                }
            }
        }
    }
}
