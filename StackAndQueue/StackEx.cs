namespace StackAndQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class StackEx
    {

        public static void Main()
        {
            //    ReverseNumberswithaStack();
            // BasicStackOperations();
            //MaximumElement();
            //BasicQueueOperations();
            //SequenceWithQueue();
            //TruckTour();
            //BalancedParentheses
            //RecursiveFibonacci DONT 


        }

        private static long recursiveFibonacciWithMemoization(int n)
        {
            long[] memo = new long[n + 1];
            if (n <= 1)
            {
                return 1;
            }

            if (memo[n] != 0)
            {
                return memo[n];
            }

            memo[n] =
                recursiveFibonacciWithMemoization(n - 1) +
                recursiveFibonacciWithMemoization(n - 2);
            return memo[n];
        }




        public static void RecursiveFibonacci()
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(recursiveFibonacciWithMemoization(n));
        }

        public static void BalancedParentheses()
        {
            // "{, [, (, ), ], }
            var input = Console.ReadLine();
            var stack = new Stack<char>();

            var flag = true;

            foreach (char para in input)
            {
                switch (para)
                {
                    case '[':
                    case '(':
                    case '{':
                        stack.Push(para);
                        break;

                    case '}':
                        if (!stack.Any())
                            flag = false;

                        else if (stack.Pop() != '{')
                            flag = false;
                        break;

                    case ')':
                        if (!stack.Any())
                            flag = false;

                        else if (stack.Pop() != '(')
                            flag = false;
                        break;

                    case ']':
                        if (!stack.Any())
                            flag = false;

                        else if (stack.Pop() != '[')
                            flag = false;
                        break;
                }

                if (!flag)
                    break;
            }

            // is balanced?
            Console.WriteLine(flag ? "YES" : "NO");
        }

        public static void TruckTour()
        {
            int numberOfPumps = int.Parse(Console.ReadLine());
            Queue<GasPump> pumps = new Queue<GasPump>();
            for (int i = 0; i < numberOfPumps; i++)
            {
                string[] pumpInfo = Console.ReadLine().Split();
                int amountOfGas = int.Parse(pumpInfo[0]);
                int distanceToNext = int.Parse(pumpInfo[1]);
                GasPump pump = new GasPump(distanceToNext, amountOfGas, i);
                pumps.Enqueue(pump);
            }
            //start circle
            GasPump startGasPump = null;
            bool completeJorney = false;
            while (pumps.Count > 0)
            {
                GasPump curreGasPump = pumps.Dequeue();
                startGasPump = curreGasPump;
                pumps.Enqueue(curreGasPump);
                int gasInTank = curreGasPump.AmountOfGas;

                while (gasInTank >= curreGasPump.DistanceToNext)
                {
                    gasInTank -= curreGasPump.DistanceToNext;
                    curreGasPump = pumps.Dequeue();
                    pumps.Enqueue(curreGasPump);
                    if (curreGasPump == startGasPump)
                    {
                        completeJorney = true;
                        break;
                    }
                    gasInTank += curreGasPump.AmountOfGas;
                }

                if (completeJorney)
                {
                    Console.WriteLine(startGasPump.IndexOfPump);
                    break;
                }
            }
        }

        public static void SequenceWithQueue()
        {
            long startNumber = long.Parse(Console.ReadLine());
            Queue<long> mySequanceQueue = new Queue<long>();
            List<long> mySeqToPrint = new List<long>();
            mySeqToPrint.Add(startNumber);
            mySequanceQueue.Enqueue(startNumber);
            while (mySeqToPrint.Count < 50)
            {
                long currentNumber = mySequanceQueue.Dequeue();
                mySequanceQueue.Enqueue(currentNumber + 1);
                mySeqToPrint.Add(currentNumber + 1);
                mySequanceQueue.Enqueue(2 * currentNumber + 1);
                mySeqToPrint.Add(2 * currentNumber + 1);
                mySequanceQueue.Enqueue(currentNumber + 2);
                mySeqToPrint.Add(currentNumber + 2);

            }
            for (int i = 0; i < 50; i++)
            {
                Console.Write(mySeqToPrint[i] + " ");
            }
            Console.WriteLine();
        }

        public static void BasicQUeueOperations()
        {
            string[] infoInput = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray(); ;
            int elementsToEnqueue = int.Parse(infoInput[0]);
            int elementsToDequeue = int.Parse(infoInput[1]);
            int numberToCheck = int.Parse(infoInput[2]);

            string inputToCheck = Console.ReadLine();
            List<int> numbers = new List<int>();
            if (inputToCheck != null && inputToCheck.Contains(" "))
            {
                numbers = inputToCheck.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToList();
            }
            else
            {
                if (inputToCheck != null) numbers.Add(int.Parse(inputToCheck));
            }

            Queue<int> numbersQueue = new Queue<int>();

            if (elementsToEnqueue == 0 || elementsToDequeue >= elementsToEnqueue || inputToCheck == String.Empty)
            {
                Console.WriteLine('0');
            }
            else
            {
                //what to do if elementstopush is greater than numbers.count 

                for (int i = 0; i < elementsToEnqueue; i++)
                {
                    int currentNumber = numbers[i];
                    numbersQueue.Enqueue(currentNumber);
                }

                for (int j = 0; j < elementsToDequeue; j++)
                {
                    numbersQueue.Dequeue();
                }

                if (numbersQueue.Contains(numberToCheck))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(numbersQueue.Min());
                }
            }
        }

        public static void MaximumElement()
        {
            Stack<ulong> numbers = new Stack<ulong>();
            Stack<ulong> maxNumbers = new Stack<ulong>();
            ulong maxNum = ulong.MinValue;

            int numberOfLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfLines; i++)
            {
                string[] commandLine = Console.ReadLine().Split();
                string command = commandLine[0];
                switch (command)
                {
                    case "1":
                        var numberToPush = ulong.Parse(commandLine[1]);
                        numbers.Push(numberToPush);
                        if (numberToPush >= maxNum)
                        {
                            maxNum = numberToPush;
                            maxNumbers.Push(maxNum);
                        }
                        break;
                    case "2":
                        ulong numToPop = numbers.Pop();
                        if (numToPop == maxNumbers.Peek())
                        {
                            maxNumbers.Pop();
                            if (maxNumbers.Count > 0)
                            {
                                maxNum = maxNumbers.Peek();
                            }
                            else
                            {
                                maxNum = ulong.MinValue;
                            }
                        }

                        break;
                    case "3":
                        Console.WriteLine(maxNumbers.Peek());
                        break;
                }
            }
        }

        public static void BasicStackOperations()
        {
            string[] infoInput = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray(); ;
            int elementsToPush = int.Parse(infoInput[0]);
            int elementsToPop = int.Parse(infoInput[1]);
            int numberToCheck = int.Parse(infoInput[2]);

            string inputToCheck = Console.ReadLine();
            List<int> numbers = new List<int>();
            if (inputToCheck != null && inputToCheck.Contains(" "))
            {
                numbers = inputToCheck.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToList();
            }
            else
            {
                if (inputToCheck != null) numbers.Add(int.Parse(inputToCheck));
            }

            Stack<int> numbersStack = new Stack<int>();

            if (elementsToPush == 0 || elementsToPop >= elementsToPush || inputToCheck == String.Empty)
            {
                Console.WriteLine('0');
            }
            else
            {
                //what to do if elementstopush is greater than numbers.count 

                for (int i = 0; i < elementsToPush; i++)
                {
                    int currentNumber = numbers[i];
                    numbersStack.Push(currentNumber);
                }

                for (int j = 0; j < elementsToPop; j++)
                {
                    numbersStack.Pop();
                }

                if (numbersStack.Contains(numberToCheck))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(numbersStack.Min());
                }
            }
        }

        public static void ReverseNumberswithaStack()
        {
            string input = Console.ReadLine();
            if (input != null && input.Contains(" "))
            {
                string[] numbers = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                Stack<int> numbersStack = new Stack<int>();
                for (int i = 0; i < numbers.Length; i++)
                {
                    int currentNumber = int.Parse(numbers[i]);
                    numbersStack.Push(currentNumber);

                }
                for (int i = 0; i < numbers.Length; i++)
                {
                    Console.Write($"{numbersStack.Pop()} ");
                }
            }
            else
            {
                Console.WriteLine(input);
            }

        }
    }

    public class GasPump
    {

        public int DistanceToNext;
        public int AmountOfGas;
        public int IndexOfPump;

        public GasPump(int distanceToNext, int amountOfGas, int indexOfPump)
        {
            this.AmountOfGas = amountOfGas;
            this.DistanceToNext = distanceToNext;
            this.IndexOfPump = indexOfPump;
        }
    }
}