using System;
using System.Collections.Generic;
using System.Linq;

namespace Inferno3
{
    public class StartUp
    {
        public static void Main()
        {
        }

        public static void PartyReservationFilterModule()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            var input = Console.ReadLine();

            var criteriaString = new List<string>();

            while (!input.Equals("Forge"))
            {
                var commands = input.Split(';').ToList();
                var mainCommand = commands[0];
                var criteria = commands[1];
                var filterParameter = commands[2];

                switch (mainCommand)
                {
                    case "Exclude":
                        criteriaString.Add($"{criteria}\\{filterParameter}");
                        break;

                    case "Reverse":
                        criteriaString.Remove($"{criteria}\\{filterParameter}");
                        break;
                }

                input = Console.ReadLine();
            }
            var predicatesList = new List<Predicate<string>>();
            foreach (var item in criteriaString)
            {
                var comands = item.Split('\\').ToList();
                var filter = MarkNumbers(comands[0], comands[1], numbers);
                predicatesList.Add(filter);
            }

            foreach (var predicate in predicatesList)
            {
            }

            Console.WriteLine(people.Count == 0 ? "" : string.Join(" ", people));
        }

        /*
        public static Func<>MarkNumbers(string criteria, string filterParameter, List<int> numbers)
        {
            switch (criteria)
            {
                case "Sum Left":
                    return n => n.FilterSumLeft(numbers, filterParameter);

                case "Sum Right":
                    return n => n.FilterSumRight(numbers, filterParameter);

                case "Sum Left Right":
                    return FilterLeftRight(int.Parse(filterParameter),numbers);
            }
            return null;
        }
        */

        private static void FilterLeftRight(int value, List<int> gems)
        {
            for (int i = 0; i < gems.Count; i++)
            {
                var leftGemPower = (i == 0) ? 0 : gems[i - 1];
                var rightGemPower = (i == gems.Count - 1) ? 0 : gems[i + 1];

                if (leftGemPower + gems[i] + rightGemPower == value)
                {
                    gems.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}