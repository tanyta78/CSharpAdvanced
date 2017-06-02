using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubikMatrix
{
   public class RubikMatrix
    {
        public static void Main()
        {
            int[] matrixInfo = Console.ReadLine().Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rowsNum = matrixInfo[0];
            int colsNum = matrixInfo[1];
            int numberOfCommands = int.Parse(Console.ReadLine());
            var rubikMatrix = new int[rowsNum, colsNum];

            int count = 1;
            for (int rowIndex = 0; rowIndex < rowsNum; rowIndex++)
            {
                for (int colIndex = 0; colIndex < colsNum; colIndex++)
                {
                    rubikMatrix[rowIndex, colIndex] = count;
                    count++;
                }
            }
            
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] comands = Console.ReadLine().Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string mainComand = comands[1];

                switch (mainComand)
                {
                    case "down":
                        MoveMatrixColDown(comands, rubikMatrix);
                        break;
                    case "up":
                        MoveMatrixColUp(comands, rubikMatrix);
                        break;
                    case "left":
                        MoveMatrixRowLeft(comands, rubikMatrix);
                        break;
                    case "right":
                        MoveMatrixRowRight(comands, rubikMatrix);
                        break;

                }

            }

            //swaps

            Console.Write(GetRearangementSwaps(rubikMatrix));
        }

        private static string GetRearangementSwaps(int[,] matrix)
        {
            var sb = new StringBuilder();
            var expectedValue = 1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != expectedValue)
                    {
                        sb.Append(Swap(matrix, i, j, expectedValue));
                    }
                    else
                    {
                        sb.Append($"No swap required{Environment.NewLine}");
                    }

                    expectedValue++;
                }
            }

            return sb.ToString();
        }

        private static string Swap(int[,] matrix, int row, int col, int expectedValue)
        {
            for (int i = row; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == expectedValue)
                    {
                        var temp = matrix[i, j];
                        matrix[i, j] = matrix[row, col];
                        matrix[row, col] = temp;

                        return $"Swap ({row}, {col}) with ({i}, {j}){Environment.NewLine}";
                    }
                }
            }

            return string.Empty;
        }

        private static void MoveMatrixColDown(string[] comands, int[,] rubikMatrix)
        {
            int startCol = int.Parse(comands[0]); //2
            int moves = int.Parse(comands[2]); //1

            int loops = moves % rubikMatrix.GetLength(0);

            var colList = new Queue<int>();

            for (int rowIndex = 0; rowIndex < rubikMatrix.GetLength(0); rowIndex++)
            {
                colList.Enqueue(rubikMatrix[rubikMatrix.GetLength(0) - 1 - rowIndex, startCol]);
            }


            for (int index = 0; index < loops; index++)
            {

                colList.Enqueue(colList.Dequeue());
            }

            for (int rowIndex = 0; rowIndex < rubikMatrix.GetLength(0); rowIndex++)
            {
                rubikMatrix[rubikMatrix.GetLength(0) - 1 - rowIndex, startCol] = colList.Dequeue();
            }

        }

        private static void MoveMatrixColUp(string[] comands, int[,] rubikMatrix)
        {
            int startCol = int.Parse(comands[0]); //2
            int moves = int.Parse(comands[2]); //1

            int loops = moves % rubikMatrix.GetLength(0);

            var colList = new Queue<int>();

            for (int rowIndex = 0; rowIndex < rubikMatrix.GetLength(0); rowIndex++)
            {
                colList.Enqueue(rubikMatrix[rowIndex, startCol]);
            }


            for (int index = 0; index < loops; index++)
            {

                colList.Enqueue(colList.Dequeue());
            }

            for (int rowIndex = 0; rowIndex < rubikMatrix.GetLength(0); rowIndex++)
            {
                rubikMatrix[rowIndex, startCol] = colList.Dequeue();
            }





        }

        private static void MoveMatrixRowLeft(string[] comands, int[,] rubikMatrix)
        {
            int startRow = int.Parse(comands[0]);
            int moves = int.Parse(comands[2]);

            int loops = moves % rubikMatrix.GetLength(1);

            var rowList = new Queue<int>();
            for (int colIndex = 0; colIndex < rubikMatrix.GetLength(1); colIndex++)
            {
                rowList.Enqueue(rubikMatrix[startRow, colIndex]);
            }


            for (int index = 0; index < loops; index++)
            {

                rowList.Enqueue(rowList.Dequeue());
            }

            for (int colIndex = 0; colIndex < rubikMatrix.GetLength(1); colIndex++)
            {
                rubikMatrix[startRow, colIndex] = rowList.Dequeue();
            }
        }

        private static void MoveMatrixRowRight(string[] comands, int[,] rubikMatrix)
        {
            int startRow = int.Parse(comands[0]);
            int moves = int.Parse(comands[2]);

            int loops = moves % rubikMatrix.GetLength(1);

            var rowList = new Queue<int>();
            for (int colIndex = 0; colIndex < rubikMatrix.GetLength(1); colIndex++)
            {
                rowList.Enqueue(rubikMatrix[startRow, rubikMatrix.GetLength(1) - 1 - colIndex]);
            }


            for (int index = 0; index < loops; index++)
            {

                rowList.Enqueue(rowList.Dequeue());
            }

            for (int colIndex = 0; colIndex < rubikMatrix.GetLength(1); colIndex++)
            {
                rubikMatrix[startRow, rubikMatrix.GetLength(1) - 1 - colIndex] = rowList.Dequeue();
            }
        }
    }
}

