using System;
using System.Linq;

namespace Crossfire
{
    public class Crossfire
    {
        public static void Main()
        {

            int[] dimensions = Console.ReadLine().Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            int count = 1;

            int[][] initialMatrix = new int[rows][];

            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                initialMatrix[rowIndex] = new int[cols];
                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    initialMatrix[rowIndex][colIndex] = count;
                    count++;
                }
            }

            var command = Console.ReadLine().Trim();

            while (command != "Nuke it from orbit")
            {
                var commandInfo = command.Split().Select(int.Parse).ToArray();

                var fireRow = commandInfo[0];
                var fireColumn = commandInfo[1];
                var fireRadius = commandInfo[2];

                initialMatrix = DestructedMatrix(initialMatrix, fireRow, fireColumn, fireRadius);

                command = Console.ReadLine().Trim();
            }

            for (int i = 0; i < initialMatrix.Length; i++)
            {
                Console.WriteLine(string.Join(" ", initialMatrix[i].Where(c => c != -1)));
            }
        }

        private static int[][] DestructedMatrix(int[][] initialMatrix, int hitRow, int hitColumn, int hitRadius)
        {
            // Mark destroyed part of the column
            for (int row = hitRow - hitRadius; row <= hitRow + hitRadius; row++)
            {
                if (IsInMatrix(row, hitColumn, initialMatrix))
                {
                    initialMatrix[row][hitColumn] = -1;
                }
            }

            // Mark destroyed part of the row
            for (int col = hitColumn - hitRadius; col <= hitColumn + hitRadius; col++)
            {
                if (IsInMatrix(hitRow, col, initialMatrix))
                {
                    initialMatrix[hitRow][col] = -1;
                }
            }

            // Remove destroyed cells
            for (int i = 0; i < initialMatrix.Length; i++)
            {
                // Remove destroyed cells if there is ones
                for (int j = 0; j < initialMatrix[i].Length; j++)
                {
                    if (initialMatrix[i][j] < 0)
                    {
                        initialMatrix[i] = initialMatrix[i].Where(n => n > 0).ToArray();
                        break;
                    }
                }

                // Remove empty rows
                if (initialMatrix[i].Count() < 1)
                {
                    initialMatrix = initialMatrix.Take(i).Concat(initialMatrix.Skip(i + 1)).ToArray();
                    i--;
                }
            }

            return initialMatrix;
        }

        private static bool IsInMatrix(int row, int col, int[][] initialMatrix)
        {
            return row >= 0 && col >= 0 && row < initialMatrix.Length && col < initialMatrix[row].Length;
        }
    }
}
