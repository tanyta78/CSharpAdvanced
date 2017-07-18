using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncProgLab
{
    public class StartUp
    {
        public static void Main()
        {
            var lines = int.Parse(Console.ReadLine());
            var people = new Dictionary<string, int>();

            for (int i = 0; i < lines; i++)
            {
                var info = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                people.Add(info[0], int.Parse(info[1]));
            }

            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();

            Func<int, bool> tester = CreateTester(condition, age);
            Action<KeyValuePair<string, int>> printer = CreatePrinter(format);

            InvokePrinter(people, tester, printer);
        }

        private static void InvokePrinter(
            Dictionary<string, int> people,
            Func<int, bool> tester,
            Action<KeyValuePair<string, int>> printer)
        {
            foreach (var person in people)
            {
                if (tester(person.Value))
                {
                    printer(person);
                }
            }
        }

        private static Func<int, bool> CreateTester(string condition, int age)
        {
            switch (condition)
            {
                case "younger":
                    return p => p < age;

                case "older":
                    return p => p > age;

                default: return null;
            }
        }

        private static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return p => Console.WriteLine(p.Key);

                case "age":
                    return p => Console.WriteLine(p.Value);

                case "name age":
                    return p => Console.WriteLine($"{p.Key} - {p.Value}");
            }
            return null;
        }

        public static void CountUppercaseWords()
        {
            var words = Console.ReadLine().Split(new String[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            Func<string, bool> checker = w => w[0] == w.ToUpper()[0];

            words.Where(checker).ToList().ForEach(w => Console.WriteLine(w));
        }

        public static void AddVAt()
        {
            Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(n => n * 1.2)
                .ToList()
                .ForEach(n => Console.WriteLine($"{n:f2}"));
        }

        public static void SumAndCountNumbers()
        {
            var numbers = Console.ReadLine();
            Console.WriteLine(numbers
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToList()
                .Count);
            Console.WriteLine(numbers
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToList()
                .Sum());
        }

        public static void PrintEvenNumbersAscending()
        {
            Console.WriteLine(string.Join(", ", Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .Where(n => n % 2 == 0)
                .OrderBy(n => n)
                .ToList()));
        }
    }
}