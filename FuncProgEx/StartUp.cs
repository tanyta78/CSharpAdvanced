using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncProgEx
{
    public class StartUp
    {
        public static void Main()
        {
        }

        public static void TriFunction()
        {
            int wantedSum = int.Parse(Console.ReadLine());
            var words = Console.ReadLine().Split();
            Func<string, int> wordToSum = word => word.ToCharArray().Select(w => (int)w).Sum();

            foreach (var word in words)
            {
                Predicate<string> sumsToCheck = w => wordToSum(w) >= wantedSum;
                if (sumsToCheck(word))
                {
                    Console.WriteLine(word);
                    break;
                }
            }
        }

        public static void PartyReservationFilterModule()
        {
            var people = Console.ReadLine().Split().ToList();

            var input = Console.ReadLine();

            var criteriaString = new List<string>();
            while (!input.Equals("Print"))
            {
                var commands = input.Split(';').ToList();
                var mainCommand = commands[0];
                var criteria = commands[1];
                var filterString = commands[2];

                switch (mainCommand)
                {
                    case "Add filter":
                        criteriaString.Add($"{criteria}\\{filterString}");
                        break;

                    case "Remove filter":
                        criteriaString.Remove($"{criteria}\\{filterString}");
                        break;
                }

                input = Console.ReadLine();
            }

            foreach (var item in criteriaString)
            {
                var comands = item.Split('\\').ToList();
                Predicate<string> filter = ReservationFilterPeople(comands[0], comands[1]);
                people.RemoveAll(filter);
            }

            Console.WriteLine(people.Count == 0 ? "" : string.Join(" ", people));
        }

        public static Predicate<string> ReservationFilterPeople(string criteria, string filterString)
        {
            switch (criteria)
            {
                case "Starts with":
                    return n => n.StartsWith(filterString);

                case "Ends with":
                    return n => n.EndsWith(filterString);

                case "Length":
                    return n => n.Length == int.Parse(filterString);

                case "Contains":
                    return n => n.Contains(filterString);
            }
            return null;
        }

        public static void PredicateParty()
        {
            var people = Console.ReadLine().Split().ToList();

            var input = Console.ReadLine();

            while (!input.Equals("Party!"))
            {
                var commands = input.Split().ToList();
                var mainCommand = commands[0];
                var criteria = commands[1];
                var filterString = commands[2];

                Predicate<string> filter = FilterPeople(criteria, filterString);
                people = DoCommandWithPeopleToFilter(people, filter, mainCommand);

                input = Console.ReadLine();
            }

            if (people.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.Write(string.Join(", ", people));
                Console.WriteLine(" are going to the party!");
            }
        }

        private static List<string> DoCommandWithPeopleToFilter(List<string> people, Predicate<string> filter, string mainCommand)
        {
            var result = new List<string>();

            switch (mainCommand)
            {
                case "Remove":

                    people.RemoveAll(filter);
                    return people;

                case "Double":
                    result = people.FindAll(filter);
                    foreach (var name in result)
                    {
                        people.Insert(people.IndexOf(name), name);
                    }
                    return people;

                default:
                    return null;
            }
        }

        public static Predicate<string> FilterPeople(string criteria, string filterString)
        {
            switch (criteria)
            {
                case "StartsWith":
                    return n => n.StartsWith(filterString);

                case "EndsWith":
                    return n => n.EndsWith(filterString);

                case "Length":
                    return n => n.Length == int.Parse(filterString);
            }
            return null;
        }

        public static object FilterNamesStartsWith { get; set; }

        public static void RealCustomComparator()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Array.Sort(numbers, new MyCompare());
            //Array.Sort(numbers,Comparison);
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static int Comparison(int a, int b)
        {
            var first = Math.Abs(a) % 2;
            var second = Math.Abs(b) % 2;
            if (first != second)
            {
                return first.CompareTo(second);
            }

            return a.CompareTo(b);
        }

        public static void ListOfPredicates()
        {
            int range = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split(' ').Select(int.Parse).Distinct().ToArray();

            Func<int, bool>[] predicates = dividers.Select(div => (Func<int, bool>)(n => n % div == 0)).ToArray();

            for (int j = 1; j <= range; j++)
            {
                bool isDivisable = true;

                foreach (var predicate in predicates)
                {
                    if (!predicate(j))
                    {
                        isDivisable = false;
                        break;
                    }
                }

                if (isDivisable)
                {
                    Console.Write("{0} ", j);
                }
            }
        }

        private static long gcdEuclidRemainder(long a, long b)
        {
            return b == 0 ? a : gcdEuclidRemainder(b, a % b);
        }

        public static void CustomComparator()
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
            Func<long, bool> isEven = num => num % 2 == 0;
            Func<long, bool> isOdd = num => num % 2 == 1 || num % 2 == -1;
            var evenNums = new List<long>();
            evenNums = FilterList(numbers, isEven);
            evenNums.Sort();
            Console.Write(string.Join(" ", evenNums));
            var oddNums = new List<long>();
            oddNums = FilterList(numbers, isOdd);
            oddNums.Sort();
            Console.Write(" ");
            Console.WriteLine(string.Join(" ", oddNums));
        }

        private static List<long> FilterList(List<long> nums, Func<long, bool> isDivisible)
        {
            var result = new List<long>();
            for (int i = 0; i < nums.Count; i++)
            {
                if (isDivisible(nums[i]))
                {
                    result.Add(nums[i]);
                }
            }
            result.Reverse();
            return result;
        }

        public static void PredicatesForNames()
        {
            var nameLength = int.Parse(Console.ReadLine());
            var names = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            Func<string, bool> isCorrectLenth = w => w.Length <= nameLength;
            names = FilterNames(names, isCorrectLenth);
            Action<List<string>> printer = namesList => namesList.ForEach(Console.WriteLine);
            printer(names);
        }

        private static List<string> FilterNames(List<string> names, Func<string, bool> isCorrectLenth)
        {
            var result = new List<string>();
            foreach (var name in names)
            {
                if (isCorrectLenth(name))
                {
                    result.Add(name);
                }
            }
            return result;
        }

        public static void ReverseAndExclude()
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();

            var divider = long.Parse(Console.ReadLine());
            Func<long, bool> isDivToDivider = num => num % divider != 0;
            numbers = FilterList(numbers, isDivToDivider);
            Console.WriteLine(string.Join(" ", numbers));
        }

        public static void Aritmetics()
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var input = Console.ReadLine();
            Action<List<int>> printer = ints => Console.WriteLine(string.Join(" ", ints));

            while (!input.Equals("end"))
            {
                switch (input)
                {
                    case "add":
                        Func<List<int>, List<int>> addOne = n => n.Select(i => i + 1).ToList();
                        numbers = addOne(numbers);
                        break;

                    case "multiply":
                        Func<List<int>, List<int>> multiplyTwo = n => n.Select(i => i * 2).ToList();
                        numbers = multiplyTwo(numbers);
                        break;

                    case "subtract":
                        Func<List<int>, List<int>> subtractOne = n => n.Select(i => i - 1).ToList();
                        numbers = subtractOne(numbers);
                        break;

                    case "print":
                        printer(numbers);
                        break;
                }
                input = Console.ReadLine();
            }
        }

        public static void FindEvenOrOdd()
        {
            var nums = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();
            var startNum = nums[0];
            var endNum = nums[1];

            var command = Console.ReadLine();
            switch (command)
            {
                case "odd":
                    Console.WriteLine(string.Join(" ", Filter(startNum, endNum, n => n % 2 == 1 || n % 2 == -1)));
                    break;

                case "even":
                    Console.WriteLine(string.Join(" ", Filter(startNum, endNum, n => n % 2 == 0)));
                    break;
            }
        }

        private static List<long> Filter(long startNum, long endNum, Func<long, bool> p2)
        {
            var result = new List<long>();
            for (long i = startNum; i <= endNum; i++)
            {
                if (p2(i))
                {
                    result.Add(i);
                }
            }
            return result;
        }

        public static void SmallestNum()
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            Func<List<int>, int> smallestNumber = numList => numList.Min();
            Console.WriteLine(smallestNumber(numbers));
        }

        public static void PrintSirNames()
        {
            var names = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(n => "Sir " + n + " ").ToList();

            Action<List<string>> printNamesWithSir = n => n.ForEach(Console.WriteLine);
            printNamesWithSir(names);
        }

        public static void PrintLineNames()
        {
            var names = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            Action<List<string>> printNames = n => n.ForEach(Console.WriteLine);
            printNames(names);
        }
    }

    public class MyCompare : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if ((x % 2 == 0) && (y % 2 != 0))
            {
                return -1;
            }
            else if ((x % 2 != 0) && (y % 2 == 0))
            {
                return 1;
            }
            else
            {
                if (x > y)
                {
                    return 1;
                }
                else if (x < y)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}