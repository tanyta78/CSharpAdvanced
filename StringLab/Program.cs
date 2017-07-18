using System.Diagnostics;

namespace StringLab
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            StringBuilder resultText = new StringBuilder();

            for (int i = 0; i < rows; i++)
            {
                string currentText = Console.ReadLine();
                resultText.Append(currentText);
                resultText.Append(" ");
            }
            Console.WriteLine(resultText.ToString());
        }

        public static void ConcatenateStirngList()
        {
            var watch = Stopwatch.StartNew();
            int rows = int.Parse(Console.ReadLine());

            var resultText = new List<string>();

            for (int i = 0; i < rows; i++)
            {
                string currentText = Console.ReadLine();
                resultText.Add(currentText);
            }
            Console.WriteLine(string.Join(" ", resultText));
            watch.Stop();
            Console.WriteLine($"List add {watch.ElapsedTicks}");
        }

        public static void ConcatenateStringSB()
        {
            var watch = Stopwatch.StartNew();
            int rows = int.Parse(Console.ReadLine());

            StringBuilder resultText = new StringBuilder();

            for (int i = 0; i < rows; i++)
            {
                string currentText = Console.ReadLine();
                resultText.Append(currentText);
                resultText.Append(" ");
            }
            Console.WriteLine(resultText.ToString());
            watch.Stop();
            Console.WriteLine($"StringBuilder add {watch.ElapsedTicks}");
        }

        public static void SpecialWords()
        {
            string input = Console.ReadLine();
            var result = new Dictionary<string, int>();
            var specialWords = new List<string>();
            if (!string.IsNullOrEmpty(input))
            {
                specialWords = input.Split(new[] { '(', ')', '[', ']', ',', '<', '>', '-', '!', '?', ' ', '\t' },
                    StringSplitOptions.RemoveEmptyEntries).ToList();
                foreach (var specialWord in specialWords)
                {
                    result.Add(specialWord, 0);
                }
            }
            input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                string[] textStrings = input.Split(
                    new[] { '(', ')', '[', ']', ',', '<', '>', '-', '!', '?', ' ', '\t' },
                    StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in textStrings)
                {
                    if (specialWords.Contains(word))
                    {
                        result[word]++;
                    }
                }
            }

            foreach (var pair in result)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }
        }

        public static void ParseTag()
        {
            string input = Console.ReadLine();
            StringBuilder result = new StringBuilder();
            while (!string.IsNullOrEmpty(input))
            {
                int startIndex = input.IndexOf("<upcase>");
                int endIndex = input.IndexOf("</upcase>");
                if (startIndex == -1 || endIndex == -1)
                {
                    result.Append(input);
                    break;
                }
                string partToUpper = input.Substring(startIndex + 8, endIndex - startIndex - 8).ToUpper();
                string before = input.Substring(0, startIndex);
                if (!string.IsNullOrEmpty(before))
                {
                    result.Append(before);
                }
                result.Append(partToUpper);
                input = input.Substring(endIndex + 9);
            }
            if (!string.IsNullOrEmpty(result.ToString()))
            {
                Console.WriteLine(result.ToString());
            }
        }

        public static void StudentGrades()
        {
            int studentsNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(String.Format("{0,-10}|{1,7}|{2,7}|{3,7}|{4,7}|", "Name", "CAdv", "COOP", "AdvOOP", "Average"));

            for (int i = 0; i < studentsNumber; i++)
            {
                //read input {name} - {firstResult}, {secondResult}, {thirdResult}
                string[] input = Console.ReadLine().Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string studentName = input[0];
                double[] results = input[1].Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse).ToArray();
                double average = results.Average();
                //print result
                Console.WriteLine(String.Format("{0,-10}|{1,7:f2}|{2,7:f2}|{3,7:f2}|{4,7:f4}|", studentName, results[0],
                    results[1], results[2], average));
            }
        }

        public static void ParseUrl()
        {
            string input = Console.ReadLine();
            if (input.IndexOf("://") != input.LastIndexOf("://") || input.IndexOf("://") == -1 ||
                input.IndexOf("/") == -1)
            {
                Console.WriteLine("Invalid URL");
            }
            else
            {
                //https://softuni.bg/courses/csharp-advanced
                //Protocol = https
                //Server = softuni.bg
                //Resources = courses / csharp - advance

                string protocol = input.Split(':')[0];
                Console.WriteLine("Protocol = {0}", protocol);
                string server = input.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries)[1];
                Console.WriteLine("Server = {0}", server);
                int indexOfResourcesDelimiter = protocol.Length + server.Length + 4;
                string resources = input.Substring(indexOfResourcesDelimiter);
                Console.WriteLine("Resources = {0}", resources);
            }
        }

        public static void ParseUrl1()
        {
            var url = Console.ReadLine();
            var elements = url.
                Split(new[] { "://" },
                    StringSplitOptions.RemoveEmptyEntries);

            if (!url.Contains("://") || elements.Length > 2)
            {
                Console.WriteLine("Invalid URL");
            }
            else
            {
                var protocol = elements[0];
                var dashIndex = elements[1].IndexOf("/");
                if (dashIndex == -1)
                {
                    Console.WriteLine("Invalid URL");
                    return;
                }
                var server = elements[1].Substring(0, dashIndex);
                var resources = elements[1].Substring(dashIndex + 1);

                Console.WriteLine($"Protocol = {protocol}");
                Console.WriteLine($"Server = {server}");
                Console.WriteLine($"Resources = {resources}");
            }
        }
    }
}