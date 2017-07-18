using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqLab
{
    public class StartUp
    {
        public static void Main()
        {
            //Map Diistricts
            var input = Console.ReadLine().Split(' ');
            var citiesInfo = new Dictionary<string, List<long>>();

            foreach (var element in input)
            {
                var townInfo = element.Split(':');
                var town = townInfo[0];
                var population = long.Parse(townInfo[1]);
                if (!citiesInfo.ContainsKey(town))
                {
                    citiesInfo.Add(town, new List<long>());
                }
                citiesInfo[town].Add(population);
            }

            var minPopulation = long.Parse(Console.ReadLine());

            var result = citiesInfo.Where(t => t.Value.Sum() > minPopulation)
                 .OrderByDescending(t => t.Value.Sum())
                 .ToDictionary(x => x.Key, x => x.Value);

            foreach (var town in result)
            {
                Console.WriteLine(string.Format($"{town.Key}: {string.Join(" ", town.Value.OrderByDescending(p => p).Take(5))}"));
            }
        }

        public static void BoundedNums()
        {
            var bounds = Console.ReadLine().Split().Select(int.Parse).ToList();
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            var lowerBound = bounds.Min();
            var upperBound = bounds.Max();
            numbers = numbers.Where(n => n >= lowerBound && n <= upperBound).ToList();
            if (numbers.Count != 0)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }

        public static void FindAndSumInt()
        {
            var numbers = Console.ReadLine().Split()
                .Select(n =>
                {
                    long value;
                    bool success = long.TryParse(n, out value);
                    return new { value, success };
                }).Where(b => b.success)
                .Select(n => n.value)
                .ToList();
            if (numbers.Count != 0)
            {
                Console.WriteLine(numbers.Sum());
            }
            else
            {
                Console.WriteLine("No match");
            }
        }

        public static void MinEvenNumbers()
        {
            var numbers = Console.ReadLine().Split().Select(double.Parse).ToList();
            var evenNums = new List<double>();
            evenNums = numbers.Where(n => n % 2 == 0).ToList();
            if (evenNums.Count != 0)
            {
                Console.WriteLine($"{evenNums.Min():f2}");
            }
            else
            {
                Console.WriteLine("No match");
            }
        }

        public static void AverageOfDouble()
        {
            var numbers = Console.ReadLine().Split().Select(double.Parse).ToList();
            Console.WriteLine($"{numbers.Average():f2}");
        }

        public static void FirstName()
        {
            var names = Console.ReadLine().Split().ToList();
            var letters = Console.ReadLine().Split().ToList().Select(w => w.ToLower()).OrderBy(ch => ch).ToList();
            var name = string.Empty;
            foreach (var letter in letters)
            {
                name = names.Where(n => n.ToLower().StartsWith(letter)).FirstOrDefault();
                if (name != null)
                {
                    Console.WriteLine(name);
                    break;
                }
            }

            if (name == null)
            {
                Console.WriteLine("No match");
            }
        }

        public static void UpperString()
        {
            Console.ReadLine().Split().ToList().Select(w => w.ToUpper()).ToList().ForEach(w => Console.Write(w + " "));
        }

        public static void TakeTwo()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            numbers.Where(n => n >= 10 && n <= 20).Distinct().Take(2).ToList().ForEach(n => Console.Write(n + " "));
        }
    }
}