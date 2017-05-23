
namespace StackAndQueueLab
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class StackQueueLab
    {
        public static void Main()
        {
            string[] childNames = Console.ReadLine().Split().ToArray();
            int number = int.Parse(Console.ReadLine());
            int cycle = 1;
            Queue<string> hotPotatoGame = new Queue<string>(childNames);
            while (hotPotatoGame.Count != 1)
            {
                for (int i = 1; i < number; i++)
                {
                    hotPotatoGame.Enqueue(hotPotatoGame.Dequeue());
                }
                Console.WriteLine(IsPrime(cycle)
                    ? $"Prime {hotPotatoGame.Peek()}"
                    : $"Removed {hotPotatoGame.Dequeue()}");
                cycle++;
            }

            Console.WriteLine($"Last is {hotPotatoGame.Dequeue()}");
        }

        private static bool IsPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 2; i <= boundary; ++i)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

        public static void MathPotato()
        {
            
        }

        public static void HotPotato()
        {
            string[] childNames = Console.ReadLine().Split().ToArray();
            int number = int.Parse(Console.ReadLine());
            Queue<string> hotPotatoGame = new Queue<string>(childNames);
            while (hotPotatoGame.Count != 1)
            {
                for (int i = 1; i < number; i++)
                {
                    hotPotatoGame.Enqueue(hotPotatoGame.Dequeue());
                }

                Console.WriteLine($"Removed {hotPotatoGame.Dequeue()}");

            }

            Console.WriteLine($"Last is {hotPotatoGame.Dequeue()}");
        }

        public static void MatchingBrackets()
        {
            string input = Console.ReadLine();
            Stack<int> indexes = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Equals('('))
                {
                    indexes.Push(i);
                }
                else if (input[i].Equals(')'))
                {
                    int startIndex = indexes.Pop();
                    Console.WriteLine(input.Substring(startIndex, i - startIndex + 1));
                }
            }
        }

        public static void DecimalToBinaryConverter()
        {
            int input = int.Parse(Console.ReadLine());
            Stack<string> result = new Stack<string>();
            if (input == 0)
            {
                Console.WriteLine("0");
            }

            while (input > 0)
            {
                result.Push((input % 2).ToString());
                input = input / 2;
            }

            while (result.Count > 0)
            {
                Console.Write(result.Pop());
            }
            Console.WriteLine();
        }

        public static void SimpleCalculator()
        {
            var input = Console.ReadLine().Split().ToArray();

            Stack<string> result = new Stack<string>(input.Reverse());

            while (result.Count > 1)
            {
                int firstNum = int.Parse(result.Pop());
                string operand = result.Pop();
                int secondNum = int.Parse(result.Pop());

                switch (operand)
                {
                    case "+": result.Push((firstNum + secondNum).ToString()); break;
                    case "-": result.Push((firstNum - secondNum).ToString()); break;
                }

            }

            Console.WriteLine(result.Pop());
        }

        public static void ReverceStrings()
        {
            var input = Console.ReadLine().ToCharArray();
            Stack<char> result = new Stack<char>();
            foreach (var ch in input)
            {
                result.Push(ch);
            }
            while (result.Count != 0)
            {
                Console.Write(result.Pop());
            }
            Console.WriteLine();
        }
    }
}
