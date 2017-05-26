namespace SetAndDictionaryLab
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Text.RegularExpressions;

    class SetAndDictLab
    {
        static void Main()
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            var studentsInfo= new SortedDictionary<string,List<double>>();

            for (int i = 0; i < numberOfStudents; i++)
            {
                string name = Console.ReadLine();
                var scores = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToList();
                if (!studentsInfo.ContainsKey(name))
                {
                    studentsInfo.Add(name, scores);
                }
                else
                {
                    var previousList = studentsInfo[name];
                    foreach (var score in scores)
                    {
                        previousList.Add(score);
                    }
                    studentsInfo[name] = scores;
                }
            }

            if (studentsInfo.Count != 0)
            {
                foreach (var pair in studentsInfo)
                {
                   Console.WriteLine($"{pair.Key} is graduated with {pair.Value.Average()}");
                }
            }
            
        }
        public static void CountValuesAppear()
        {
            var valuesCount = new SortedDictionary<double, long>();

            var numbers = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            if (numbers.Length != 0)
            {
                foreach (var number in numbers)
                {
                    if (!valuesCount.ContainsKey(number))
                    {
                        valuesCount.Add(number, 1);
                    }
                    else
                    {
                        valuesCount[number] += 1;

                    }
                }
            }
            if (valuesCount.Count != 0)
            {
                foreach (var pair in valuesCount)
                {
                    Console.WriteLine($"{pair.Key} - {pair.Value} times");
                }
            }
        }

        public static void SoftUniParty()
        {
            string input = Console.ReadLine();

            SortedSet<string> allguests = new SortedSet<string>();

            while (!input.Equals("PARTY"))
            {
                allguests.Add(input);
                input = Console.ReadLine();
            }
            int allguestsnumber = allguests.Count;

            input = Console.ReadLine();


            while (!input.Equals("END"))
            {
                if (allguests.Contains(input))
                {
                    allguests.Remove(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(allguests.Count);
            if (allguests.Count != 0)
            {
                foreach (var guest in allguests)
                {
                    Console.WriteLine(guest);
                }
            }
        }

        public static void ParkingLot()
        {
            string carNumber = String.Empty;
            SortedSet<string> parcingLot = new SortedSet<string>();

            string commandLine = Console.ReadLine();
            while (!commandLine.Equals("END"))
            {
                // string[]commandInfo = commandLine.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string[] commandInfo = Regex.Split(commandLine, ", ", RegexOptions.IgnorePatternWhitespace);

                string command = commandInfo[0];
                carNumber = commandInfo[1];

                switch (command)
                {
                    case "IN": parcingLot.Add(carNumber); break;
                    case "OUT":
                        if (parcingLot.Contains(carNumber))
                        {
                            parcingLot.Remove(carNumber);
                        }
                        break;
                }

                commandLine = Console.ReadLine();

            }

            if (parcingLot.Count != 0)
            {
                foreach (var car in parcingLot)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
