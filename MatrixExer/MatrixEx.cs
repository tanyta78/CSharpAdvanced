namespace MatrixExer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MatrixEx
    {
        public static void Main()
        {
            int[] input = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int dimensionOne = input[0];
            int dimensionTwo = input[1];

            string targetString = Console.ReadLine();
            input = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            //parameters (impact row, impact column and radius
            int impactRow = input[0];
            int impactColumn = input[1];
            int radius = input[2];

            for (int rowIndex = dimensionOne - 1; rowIndex > 0; rowIndex--)
            {
                if (rowIndex
                for (int colIndex = 0; colIndex < dimensionTwo; colIndex++)
                    {
                    }
            }
        }

        public static void TargetPractise()
        {
        }

        public static void MaxSumSquare()
        {
            int[] matrixInfo = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
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
            var fifthCell = 0;
            var sixCell = 0;
            var sevenCell = 0;
            var eightCell = 0;
            var nineCell = 0;

            //find the maxSum

            for (int rowIndex = 0; rowIndex < myMatrix.GetLength(0) - 2; rowIndex++)
            {
                for (int colIndex = 0; colIndex < myMatrix.GetLength(1) - 2; colIndex++)
                {
                    firstCell = myMatrix[rowIndex, colIndex];
                    secondCell = myMatrix[rowIndex, colIndex + 1];
                    thirdCell = myMatrix[rowIndex, colIndex + 2];
                    fourthCell = myMatrix[rowIndex + 1, colIndex];
                    fifthCell = myMatrix[rowIndex + 1, colIndex + 1];
                    sixCell = myMatrix[rowIndex + 1, colIndex + 2];
                    sevenCell = myMatrix[rowIndex + 2, colIndex];
                    eightCell = myMatrix[rowIndex + 2, colIndex + 1];
                    nineCell = myMatrix[rowIndex + 2, colIndex + 2];

                    var currentSum = firstCell + secondCell + thirdCell + fourthCell + fifthCell + sixCell + sevenCell + eightCell + nineCell;

                    if (currentSum > maxSumSquare)
                    {
                        maxSumSquare = currentSum;
                        indexCells = new List<int>();
                        indexCells.Add(firstCell);
                        indexCells.Add(secondCell);
                        indexCells.Add(thirdCell);
                        indexCells.Add(fourthCell);
                        indexCells.Add(fifthCell);
                        indexCells.Add(sixCell);
                        indexCells.Add(sevenCell);
                        indexCells.Add(eightCell);
                        indexCells.Add(nineCell);
                    }
                }
            }

            //print result
            Console.WriteLine($"Sum = {maxSumSquare}");
            Console.WriteLine($"{indexCells[0]} {indexCells[1]} {indexCells[2]}");
            Console.WriteLine($"{indexCells[3]} {indexCells[4]} {indexCells[5]}");
            Console.WriteLine($"{indexCells[6]} {indexCells[7]} {indexCells[8]}");
        }

        public static void EqualCharsSquares()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var charMatrix = new String[input[0]][];
            var currentRow = new String[input[1]];
            for (int rowIndex = 0; rowIndex < input[0]; rowIndex++)
            {
                currentRow = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                charMatrix[rowIndex] = currentRow;
            }

            var firstCell = string.Empty;
            var secondCell = string.Empty;
            var thirdCell = string.Empty;
            var fourthCell = string.Empty;
            int squareMatrixofEqualEl = 0;

            for (int startRowIndexIndex = 0; startRowIndexIndex < input[0] - 1; startRowIndexIndex++)
            {
                for (int startColIndex = 0; startColIndex < input[1] - 1; startColIndex++)
                {
                    firstCell = charMatrix[startRowIndexIndex][startColIndex];
                    secondCell = charMatrix[startRowIndexIndex][startColIndex + 1];
                    thirdCell = charMatrix[startRowIndexIndex + 1][startColIndex];
                    fourthCell = charMatrix[startRowIndexIndex + 1][startColIndex + 1];

                    if (firstCell.Equals(secondCell) && secondCell.Equals(thirdCell) && thirdCell.Equals(fourthCell))
                    {
                        squareMatrixofEqualEl++;
                    }
                }
            }

            Console.WriteLine(squareMatrixofEqualEl);
        }

        public static void DiagonalDifference()
        {
            int matrixParameter = int.Parse(Console.ReadLine());
            var numberMatrix = new Double[matrixParameter][];
            var currentRow = new Double[matrixParameter];
            for (int rowIndex = 0; rowIndex < matrixParameter; rowIndex++)
            {
                currentRow = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                numberMatrix[rowIndex] = currentRow;
            }

            double primaryDiagonalSum = 0;
            double secondaryDiagonalSum = 0;
            int count = 0;
            foreach (var row in numberMatrix)
            {
                primaryDiagonalSum += row[count];
                secondaryDiagonalSum += row[matrixParameter - 1 - count];
                count++;
            }
            Console.WriteLine(Math.Abs(primaryDiagonalSum - secondaryDiagonalSum));
        }

        public static void PalimdromesMatrixWithOrWithoutStrBuil()
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rowsNumber = input[0];
            int colsNumber = input[1];
            var alphabetMatrix = new String[rowsNumber, colsNumber];

            for (int rowIndex = 0; rowIndex < rowsNumber; rowIndex++)
            {
                for (int colIndex = 0; colIndex < colsNumber; colIndex++)
                {
                    // var alphaPalindrome = new StringBuilder();
                    var curentstring = new char[3];
                    curentstring[0] = alphabet[rowIndex];
                    curentstring[1] = alphabet[colIndex + rowIndex];
                    curentstring[2] = alphabet[rowIndex];
                    string currentString = new string(curentstring);

                    //alphaPalindrome.Append(alphabet[rowIndex]);
                    //alphaPalindrome.Append(alphabet[colIndex+rowIndex]);
                    //alphaPalindrome.Append(alphabet[rowIndex]);
                    //currentString = alphaPalindrome.ToString();
                    alphabetMatrix[rowIndex, colIndex] = currentString;
                }
            }
            for (int rowIndex = 0; rowIndex < rowsNumber; rowIndex++)
            {
                for (int colIndex = 0; colIndex < colsNumber; colIndex++)
                {
                    Console.Write($"{alphabetMatrix[rowIndex, colIndex]} ");
                }
                Console.WriteLine();
            }
        }
    }
}