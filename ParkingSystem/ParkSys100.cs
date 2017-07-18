using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingSystem
{
    internal class ParkSys100
    {
        public static void Logger()
        {
            int[] matrixArgs = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int totalRows = matrixArgs[0];
            int totalCols = matrixArgs[1];

            var parking = new Dictionary<int, HashSet<int>>();

            string inputLine = Console.ReadLine();
            while (inputLine != "stop")
            {
                int[] inputArgs = inputLine
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int entryRow = inputArgs[0];
                int targetRow = inputArgs[1];
                int targetCol = inputArgs[2];

                if (!IsPlaceOccupied(parking, targetRow, targetCol))
                {
                    OccupyPlace(parking, targetRow, targetCol);
                    int distance = Math.Abs(entryRow - targetRow) + 1 + targetCol;
                    Console.WriteLine(distance);
                }
                else
                {
                    targetCol = TryFindFreeSpot(parking[targetRow], totalCols, targetCol);
                    if (targetCol == 0)
                    {
                        Console.WriteLine($"Row {targetRow} full");
                    }
                    else
                    {
                        OccupyPlace(parking, targetRow, targetCol);
                        int distance = Math.Abs(entryRow - targetRow) + 1 + targetCol;
                        Console.WriteLine(distance);
                    }
                }

                inputLine = Console.ReadLine();
            }
        }

        private static int TryFindFreeSpot(HashSet<int> parkingRow, int totalCols, int targetCol)
        {
            int minDistance = int.MaxValue;
            int resultCol = 0;

            if (parkingRow.Count == totalCols - 1)
            {
                return resultCol;
            }

            for (int col = 1; col < totalCols; col++)
            {
                int currentDistance = Math.Abs(targetCol - col);
                if (!parkingRow.Contains(col) && currentDistance < minDistance)
                {
                    resultCol = col;
                    minDistance = currentDistance;
                }
            }

            return resultCol;
        }

        public static bool IsPlaceOccupied(Dictionary<int, HashSet<int>> parking, int targetRow, int targetCol)
        {
            return parking.ContainsKey(targetRow) && parking[targetRow].Contains(targetCol);
        }

        public static void OccupyPlace(Dictionary<int, HashSet<int>> parking, int targetRow, int targetCol)
        {
            if (!parking.ContainsKey(targetRow))
            {
                parking.Add(targetRow, new HashSet<int>());
            }

            parking[targetRow].Add(targetCol);
        }
    }
}
}