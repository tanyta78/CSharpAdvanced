namespace MatrixLab
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MatrixLAb
    {
        public static void Main()
        {
        }

        public static void PascalTriangle()
        {
            int rows = int.Parse(Console.ReadLine());
            long[][] pascalTriangle = new long[rows][];

            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                pascalTriangle[rowIndex] = new long[rowIndex + 1];
                pascalTriangle[rowIndex][0] = 1;
                pascalTriangle[rowIndex][pascalTriangle[rowIndex].Length - 1] = 1;

                //input inside elements

                for (int coIndex = 1; coIndex < pascalTriangle[rowIndex].Length - 1; coIndex++)
                {
                    pascalTriangle[rowIndex][coIndex] =
                        pascalTriangle[rowIndex - 1][coIndex - 1] + pascalTriangle[rowIndex - 1][coIndex];
                }
            }
            foreach (var row in pascalTriangle)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        public static void GroupNumbersByDivideToThree()
        {
            int[] numbers = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            // int numbersCount = numbers.Length;
            int[][] dividingMatrix = new int[3][];
            var firstRow = new List<int>();
            var secondRow = new List<int>();
            var thirdRow = new List<int>();
            foreach (var num in numbers)
            {
                var absNum = Math.Abs(num);
                if (absNum % 3 == 0)
                {
                    firstRow.Add(num);
                }
                else if (absNum % 3 == 1)
                {
                    secondRow.Add(num);
                }
                else if (absNum % 3 == 2)
                {
                    thirdRow.Add(num);
                }
            }
            //think this is redundant
            dividingMatrix[0] = firstRow.ToArray();
            dividingMatrix[1] = secondRow.ToArray();
            dividingMatrix[2] = thirdRow.ToArray();

            //print result
            foreach (var row in dividingMatrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        public static void MaxSumSubMatrix()
        {
            int[] matrixInfo = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int row = matrixInfo[0];
            int col = matrixInfo[1];
            int maxSumSquare = int.MinValue;
            var indexCells = new List<int>();
            //read the matrix
            int[,] myMatrix = new int[row, col];
            for (int rowIndex = 0; rowIndex < row; rowIndex++)
            {
                int[] rowInfo = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int colIndex = 0; colIndex < col; colIndex++)
                {
                    myMatrix[rowIndex, colIndex] = rowInfo[colIndex];
                }
            }
            var firstCell = 0;
            var secondCell = 0;
            var thirdCell = 0;
            var fourthCell = 0;

            //find the maxSum

            for (int rowIndex = 0; rowIndex < myMatrix.GetLength(0) - 1; rowIndex++)
            {
                for (int colIndex = 0; colIndex < myMatrix.GetLength(1) - 1; colIndex++)
                {
                    firstCell = myMatrix[rowIndex, colIndex];
                    secondCell = myMatrix[rowIndex, colIndex + 1];
                    thirdCell = myMatrix[rowIndex + 1, colIndex];
                    fourthCell = myMatrix[rowIndex + 1, colIndex + 1];
                    var currentSum = firstCell + secondCell + thirdCell + fourthCell;

                    if (currentSum > maxSumSquare)
                    {
                        maxSumSquare = currentSum;
                        indexCells = new List<int>();
                        indexCells.Add(firstCell);
                        indexCells.Add(secondCell);
                        indexCells.Add(thirdCell);
                        indexCells.Add(fourthCell);
                    }
                }
            }

            //print result
            Console.WriteLine($"{indexCells[0]} {indexCells[1]}");
            Console.WriteLine($"{indexCells[2]} {indexCells[3]}");
            Console.WriteLine($"{maxSumSquare}");
        }

        public static void SumOfAllElementsInMatrix()
        {
            int[] matrixInfo = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int row = matrixInfo[0];
            int col = matrixInfo[1];
            int sum = 0;
            int[,] myMatrix = new int[row, col];
            for (int rowIndex = 0; rowIndex < row; rowIndex++)
            {
                int[] rowInfo = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int colIndex = 0; colIndex < col; colIndex++)
                {
                    myMatrix[rowIndex, colIndex] = rowInfo[colIndex];
                    sum += rowInfo[colIndex];
                }
            }
            Console.WriteLine(row);
            Console.WriteLine(col);
            Console.WriteLine(sum);
        }
    }
}