namespace LegoBlocks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LegoBlocks
    {
        public static void Main()
        {
            int numberRows = int.Parse(Console.ReadLine());

            int[][] firstJaggedArr = new int[numberRows][];
            int[][] secondJaggedArr = new int[numberRows][];

            for (int i = 0; i < numberRows; i++)
            {
                firstJaggedArr[i] = Console.ReadLine().Split(new[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            }
            for (int i = 0; i < numberRows; i++)
            {
                secondJaggedArr[i] = Console.ReadLine().Split(new[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            }

            Queue<int> isFit = new Queue<int>();

            for (int i = 0; i < numberRows; i++)
            {
                int rowLength = firstJaggedArr[i].Length + secondJaggedArr[i].Length;

                isFit.Enqueue(rowLength);
            }

            if (isFit.Where(x => x == isFit.Peek()).ToArray().Length == isFit.Count)
            {
                PrintMatchedArray(firstJaggedArr, secondJaggedArr, numberRows);
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {isFit.Sum()}");
            }
        }

        private static void PrintMatchedArray(int[][] firstJaggedArr, int[][] secondJaggedArr, int numberRows)
        {
            for (int rowIndex = 0; rowIndex < numberRows; rowIndex++)
            {
                Console.Write($"[{string.Join(", ", firstJaggedArr[rowIndex])}, {string.Join(", ", secondJaggedArr[rowIndex].Reverse())}]");
                Console.WriteLine();
            }
        }
    }
}