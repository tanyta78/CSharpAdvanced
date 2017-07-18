using System;
using System.Text;
using System.Text.RegularExpressions;

namespace RegexEx
{
    public class RegEx
    {
        private static void Main()
        {
            FullName();
        }

        public static void SemanticHtml()
        {
            Regex openingTagRegex = new Regex(@"<div(.*?\b)((id|class)\s*=\s*""(.*?)"")(.*?)>");
            Regex closingTagRegex = new Regex(@"<\/div>\s*<!--\s*(.*?)\s*-->");
            string text = Console.ReadLine();

            while (text != null && !text.Equals("END"))
            {
                var openingTagMatch = openingTagRegex.Match(text);
                var closingTagMatch = closingTagRegex.Match(text);
                if (openingTagMatch.Success)
                {
                    text = $"{openingTagMatch.Groups[4].Value} {openingTagMatch.Groups[1].Value} ";
                    StringBuilder sb = new StringBuilder();
                    sb.Append(text);
                    for (int i = 5; i <= openingTagMatch.Groups.Count; i++)
                    {
                        var currentInfo = openingTagMatch.Groups[i].Value + " ";
                        sb.Append(currentInfo);
                    }
                    text = sb.ToString().Trim();
                    text = "<" + Regex.Replace(text, @"\s+", " ") + ">";
                }

                if (closingTagMatch.Success)
                {
                    text = $"</{closingTagMatch.Groups[1].Value}>";
                }

                Console.WriteLine(text);
                text = Console.ReadLine();
            }
        }

        public static void ExtractHiperlinks()
        {
            string pattern = @"<a[\s\S]*?\s+href\s*={0,1}\s*([""'])?([\s\S]*?)(?:>|class|\1)[\s\S]*?<\/a>";

            Regex newRegex = new Regex(pattern);
            string text = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            while (text != null && !text.Equals("END"))
            {
                sb.Append(text);
                text = Console.ReadLine();
            }

            string allText = sb.ToString();

            if (newRegex.IsMatch(allText))
            {
                var matches = newRegex.Matches(allText);
                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Groups[2].Value);
                }
            }
        }

        public static void ValidUserNames()
        {
            string pattern = "(?<=[\\s\\/\\\\(\\)]|^)([A-Za-z]\\w{2,24})(?=[\\s\\/\\\\(\\)]|$)";

            Regex newRegex = new Regex(pattern);

            string text = Console.ReadLine();
            var userNamesMaxLength = int.MinValue;
            var bestIndex = -1;
            if (newRegex.IsMatch(text))
            {
                var matches = newRegex.Matches(text);

                var prevMatch = matches[0].Value.Length;
                for (int i = 1; i < matches.Count; i++)
                {
                    var currentMatch = matches[i].Value.Length;
                    if (currentMatch + prevMatch > userNamesMaxLength)
                    {
                        userNamesMaxLength = currentMatch + prevMatch;
                        bestIndex = i;
                    }
                    prevMatch = currentMatch;
                }

                Console.WriteLine(matches[bestIndex - 1].Value);
                Console.WriteLine(matches[bestIndex].Value);
            }
        }

        public static void SentenceExtractor()
        {
            string pattern = "([^.!?]+(?=[.!?])[.!?])";

            Regex isSentenceRegex = new Regex(pattern);

            string searchString = " " + Console.ReadLine() + " ";
            string text = Console.ReadLine();

            Regex isContained = new Regex(searchString);

            if (isSentenceRegex.IsMatch(text))
            {
                var matches = isSentenceRegex.Matches(text);
                foreach (Match match in matches)
                {
                    var isTrue = isContained.IsMatch(match.Value);
                    if (isTrue)
                    {
                        Console.WriteLine(match.Value);
                    }
                }
            }
        }

        public static void ExtractEmails()
        {
            string pattern = "((?<=\\s)[a-zA-Z0-9]+([-.]\\w*)*@[a-zA-Z]+?([.-][a-zA-Z]*)*(\\.[a-z]{2,}))";

            Regex newRegex = new Regex(pattern);

            string text = Console.ReadLine();

            if (newRegex.IsMatch(text))
            {
                var matches = newRegex.Matches(text);
                foreach (Match match in matches)
                {
                    Console.WriteLine(match);
                }
            }
        }

        public static void ReplaceTags()
        {
            string pattern = "(<a)(.*)(>+)(.*)(<\\/a>)";

            Regex newRegex = new Regex(pattern);

            string text = Console.ReadLine();

            while (text != null && !text.Equals("end"))
            {
                if (newRegex.IsMatch(text))
                {
                    var matches = newRegex.Matches(text);
                    Console.WriteLine(Regex.Replace(text, pattern,
                        "[URL" + matches[0].Groups[2] + "]" + matches[0].Groups[4] + "[/URL]"));
                }
                else
                {
                    Console.WriteLine(text);
                }
                text = Console.ReadLine();
            }
        }

        public static void SeriesOfLetter()
        {
            string pattern = "([a-z,A-Z])\\1+";

            Regex newRegex = new Regex(pattern);

            string text = Console.ReadLine();

            Console.WriteLine(Regex.Replace(text, pattern, "$1"));
        }

        public static void PhoneNumber()
        {
            string pattern = "\\+359( |-)([0-9])\\1([0-9]{3})\\1([0-9]{4})\\b";

            Regex newRegex = new Regex(pattern);

            string text = Console.ReadLine();

            while (text != null && !text.Equals("end"))
            {
                if (newRegex.IsMatch(text))
                {
                    Console.WriteLine(text);
                }
                text = Console.ReadLine();
            }
        }

        public static void FullName()
        {
            string pattern = "\\b([A-Z][a-z]+) ([A-Z][a-z]+)\\b";

            Regex newRegex = new Regex(pattern);

            string text = Console.ReadLine();

            while (text != null && !text.Equals("end"))
            {
                if (newRegex.IsMatch(text))
                {
                    Console.WriteLine(text);
                }
                text = Console.ReadLine();
            }
        }
    }
}