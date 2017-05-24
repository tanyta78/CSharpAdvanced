namespace StackAndQueue
{
    using System;
    using System.Collections;
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
            //SimpleTextEditor
            int numberOfPlants = int.Parse(Console.ReadLine());
            var plantsInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var plants = new Stack<Plant>();

            var maxDaysAlive = 0;

            foreach (var pesticideOfPlant in plantsInfo)
            {
                var daysAlive = 0;
                while (plants.Count > 0 && pesticideOfPlant <= plants.Peek().Poison)
                {
                    daysAlive = Math.Max(daysAlive, plants.Pop().DaysAlive);
                }

                daysAlive = plants.Count == 0 ? 0 : daysAlive + 1;
                maxDaysAlive = Math.Max(maxDaysAlive, daysAlive);

                var plant = new Plant(pesticideOfPlant, daysAlive);
                plants.Push(plant);
            }

            Console.WriteLine(maxDaysAlive);

        }

        public static void PoisonousPlantsWithoutStack()
        {
           
                        int n = int.Parse(Console.ReadLine());
                        int[] plants = Console.ReadLine().Split().Select(int.Parse).ToArray();
                        int[] days = new int[n];
                        int[] minElement = new int[n];

                        int min = int.MaxValue;
                        for (int i = 0; i < n; i++)
                        {
                            if (plants[i] < min)
                            {
                                min = plants[i];
                            }
                            minElement[i] = min;
                        }

                        int max = 0;
                        int maxIndex = 0;

                        for (int i = 1; i < n; i++)
                        {
                            if (plants[i] > plants[i - 1])
                            {
                                days[i] = 1;
                                if (days[i] >= max)
                                {
                                    maxIndex = i;
                                    max = days[i];
                                }
                                continue;
                            }

                            if (plants[i] > minElement[i])
                            {
                                if (plants[i] > plants[maxIndex])
                                {
                                    days[i] = days[i - 1] + 1;
                                }
                                else
                                {
                                    days[i] = days[maxIndex] + 1;
                                }
                            }
                            if (plants[i] == minElement[i])
                            {
                                max = 0;
                            }

                            if (days[i] >= max)
                            {
                                maxIndex = i;
                                max = days[i];
                            }
                        }

                        Console.WriteLine(days.Max());
                    }
                

        public static void SimpleTextEditor()
        {
            int numberOfOperations = int.Parse(Console.ReadLine());
            Stack<string> result = new Stack<string>();
            for (int i = 0; i < numberOfOperations; i++)
            {

                string[] commandLine = Console.ReadLine().Split();
                string command = commandLine[0];

                switch (command)
                {
                    case "1":
                        var editedText = result.Count > 0
                            ? new StringBuilder(result.Peek())
                            : new StringBuilder();
                        editedText.Append(commandLine[1]);
                        result.Push(editedText.ToString());
                        break;
                    case "2":
                        var currentText = result.Peek();
                        var newText = new StringBuilder(currentText);
                        int startIndex = currentText.Length - int.Parse(commandLine[1]);
                        newText.Remove(startIndex, currentText.Length - startIndex);
                        result.Push(newText.ToString());
                        break;
                    case "3":
                        var curentText = result.Peek();

                        int currentIndex = int.Parse(commandLine[1]) - 1;
                        Console.WriteLine(curentText[currentIndex]);
                        break;
                    case "4":
                        result.Pop();
                        break;
                    default:
                        throw new InvalidOperationException();
                }

            }
        }

        public static void StackFibonacci()
        {
            int n = int.Parse(Console.ReadLine());

            var fibNumbers = new Stack<ulong>();
            fibNumbers.Push(1);
            fibNumbers.Push(1);

            for (int i = 1; i < n; i++)
            {
                ulong first = fibNumbers.Pop();
                ulong second = fibNumbers.Pop();

                fibNumbers.Push(first);
                fibNumbers.Push(first + second);
            }

            fibNumbers.Pop();
            Console.WriteLine(fibNumbers.Peek());
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

            Console.WriteLine(recursiveFibonacciWithMemoization(n-1));
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

    public class Plant
    {
        public int Poison { get; }
        public int DaysAlive { get; }

        public Plant(int poison, int daysalive)
        {
            this.Poison = poison;
            this.DaysAlive = daysalive;
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