using System;
using System.Text.RegularExpressions;
using System.Xml;

namespace RegexLab
{
    public class RegexLab
    {
        public static void Main()
        {

            string pattern = "(\"|')(.*?)\\1";

            Regex newRegex = new Regex(pattern);

            string text = Console.ReadLine();
            MatchCollection matches = Regex.Matches(text, pattern);

            foreach (Match match in matches)
            {
               Console.WriteLine(match.Groups[2].Value);
            }

        }

        public static void ExtractQuatiations()
        {
            
        }

        public static void ValidTime()
        {
            string pattern = @"^([01][0-9]):([0-5][0-9]):([0-5][0-9]) [AP]M$";

            Regex newRegex = new Regex(pattern);

            string text = Console.ReadLine();

            while (text != null && !text.Equals("END"))
            {
                Console.WriteLine(newRegex.IsMatch(text) ? "valid" : "invalid");
                text = Console.ReadLine();
            }
        }

        public static void ValidNames()
        {

            string pattern = @"^[\w\d-]{3,16}$";

            Regex newRegex = new Regex(pattern);

            string text = Console.ReadLine();

            while (text != null && !text.Equals("END"))
            {
                Console.WriteLine(newRegex.IsMatch(text) ? "valid" : "invalid");
                text = Console.ReadLine();
            }
        }

        public static void ExtractTags()
        {
            string pattern = @"<[^>]*>";

            Regex newRegex = new Regex(pattern);

            string text = Console.ReadLine();

            while (text != null && !text.Equals("END"))
            {
                while (newRegex.IsMatch(text))
                {
                    var result = newRegex.Match(text);
                    Console.WriteLine(result.Value);
                    text = text.Substring(result.Index + result.Value.Length);
                }
                text = Console.ReadLine();
            }
        }

        public static void ExtractIntegerNumbers()
        {
            string pattern = @"\d+";

            Regex newRegex = new Regex(pattern);

            string text = Console.ReadLine();

            if (text != null)
            {
                while (newRegex.IsMatch(text))
                {
                    var result = newRegex.Match(text);
                    Console.WriteLine(result.Value);
                    text = text.Substring(result.Index + result.Value.Length);
                }
            }
        }

        public static void NonDigitCount()
        {
            string pattern = "[\\D]";

            Regex newRegex = new Regex(pattern);

            string text = Console.ReadLine();

            if (text != null)
            {
                int result = newRegex.Matches(text).Count;

                Console.WriteLine($"Non-digits: {result}");
            }
        }

        public static void VowelCount()
        {
            string pattern = "[aAeEiIuUyYoO]";

            Regex newRegex = new Regex(pattern);

            string text = Console.ReadLine();

            if (text != null)
            {
                int result = newRegex.Matches(text).Count;

                Console.WriteLine($"Vowels: {result}");
            }
        }

        public static void MatchCount()
        {
            string pattern = Console.ReadLine();

            Regex newRegex = new Regex(pattern);

            string text = Console.ReadLine();

            if (text != null)
            {
                int result = newRegex.Matches(text).Count;

                Console.WriteLine(result);
            }
        }
    }
}
