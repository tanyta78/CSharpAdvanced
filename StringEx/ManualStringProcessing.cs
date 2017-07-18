namespace StringEx
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Text.RegularExpressions;

    public class ManualStringProcessing
    {
        private static List<String> _result;

        private static void Main()
        {
            _result = new List<String>();
            String input = GetInput();

            GetResults(input);
            PrintResults();
        }

        private static void PrintResults()
        {
            foreach (var i in _result)
            {
                Console.WriteLine(i);
            }
        }

        private static void GetResults(String input)
        {
            //String pat = @"\u\s;
            String pattern = @"(?:<a)(?:[\s\n_0-9a-zA-Z=""()]*?.*?)(?:href([\s\n]*)?=(?:['""\s\n]*)?)([a-zA-Z:#\/._\-0-9!?=^+]*(\([""'a-zA-Z\s.()0-9]*\))?)(?:[\s\na-zA-Z=""()0-9]*.*?)?(?:\>)";
            Regex rex = new Regex(pattern);
            Match match = rex.Match(input);

            while (match.Success)
            {
                if (!(match.Groups[2].Value == "fake"))
                {
                    _result.Add(match.Groups[2].Value);
                }
                match = match.NextMatch();
            }
        }

        private static String GetInput()
        {
            StringBuilder bld = new StringBuilder();
            while (true)
            {
                String input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                bld.Append(input);
                bld.Append("\n");
            }

            return bld.ToString();
        }

        public static void ExtractHyperlinks()
        {
            var result = new List<string>();
            var input = Console.ReadLine();

            StringBuilder textbuild = new StringBuilder();
            while (input != "END")
            {
                textbuild.Append(input);
                textbuild.Append("\n");

                input = Console.ReadLine();
            }
            input = textbuild.ToString();

            String pattern = @"(?:<a)(?:[\s\n_0-9a-zA-Z=""()]*?.*?)(?:href([\s\n]*)?=(?:['""\s\n]*)?)([a-zA-Z:#\/._\-0-9!?=^+]*(\([""'a-zA-Z\s.()0-9]*\))?)(?:[\s\na-zA-Z=""()0-9]*.*?)?(?:\>)";
            Regex rex = new Regex(pattern);
            Match match = rex.Match(input);

            while (match.Success)
            {
                result.Add(match.Groups[2].Value);

                match = match.NextMatch();
            }

            foreach (var i in result)
            {
                Console.WriteLine(i);
            }
        }

        public static void MelrahShake()
        {
            string test = Console.ReadLine();
            string key = Console.ReadLine();

            while (true)
            {
                //find match
                int lastindex = test.LastIndexOf(key);
                int firstindex = test.IndexOf(key);

                //shake it or not
                if (firstindex != -1 && lastindex != -1 && firstindex != lastindex
                    && key.Length > 0)
                {
                    Console.WriteLine("Shaked it.");
                    test = test.Remove(firstindex, key.Length);
                    lastindex = test.LastIndexOf(key);
                    test = test.Remove(lastindex, key.Length);
                }
                else
                {
                    Console.WriteLine("No shake.");
                    Console.WriteLine(test);
                    break;
                }
                //change key
                int indexToremove = key.Length / 2;
                key = key.Remove(indexToremove, 1);
            }
        }

        public static void LettersChangeNumbers()
        {
            char[] separator = new char[] { ' ', '\n', '\t' };
            string[] input = Console.ReadLine().Trim().Split(separator, StringSplitOptions.RemoveEmptyEntries).ToArray();
            decimal result = 0;
            int numberOfStrings = input.Length;
            for (int i = 0; i < numberOfStrings; i++)
            {
                string currentString = input[i];
                char firstLetter = currentString[0];
                char lastLetter = currentString[currentString.Length - 1];
                currentString = currentString.Remove(0, 1);
                currentString = currentString.Remove(currentString.Length - 1, 1);
                int number = int.Parse(currentString);
                if (firstLetter >= 'a' && firstLetter <= 'z')
                {
                    result += (decimal)number * (firstLetter - 'a' + 1);
                }
                else if (firstLetter >= 'A' && firstLetter <= 'Z')
                {
                    result += (decimal)number / (firstLetter - 'A' + 1);
                }
                if (lastLetter >= 'a' && lastLetter <= 'z')
                {
                    result += lastLetter - 'a' + 1;
                }
                else if (lastLetter >= 'A' && lastLetter <= 'Z')
                {
                    result -= lastLetter - 'A' + 1;
                }
            }
            Console.WriteLine("{0:f2}", result);
        }

        public static void MagicExchangableWords()
        {
            string[] words = Console.ReadLine().Split();
            var exchangeDict = new Dictionary<char, char>();
            bool isExchangable = true;
            int firstWordLength = words[0].Length;
            int secondWordLength = words[1].Length;
            int minLength = Math.Min(firstWordLength, secondWordLength);
            for (int i = 0; i < minLength; i++)
            {
                var firstWordChar = words[0][i];
                var secondwordChar = words[1][i];

                if (!exchangeDict.ContainsKey(firstWordChar))
                {
                    if (!exchangeDict.ContainsValue(secondwordChar))
                    {
                        exchangeDict.Add(firstWordChar, secondwordChar);
                    }
                    else
                    {
                        isExchangable = false;
                        break;
                    }
                }
                else
                {
                    if (exchangeDict[firstWordChar] != secondwordChar)
                    {
                        isExchangable = false;
                        break;
                    }
                }
            }

            if (isExchangable)
            {
                string rest = "";

                rest = firstWordLength > secondWordLength ? words[0].Substring(minLength) : words[1].Substring(minLength);

                foreach (char ch in rest)
                {
                    if (!exchangeDict.ContainsValue(ch) && !exchangeDict.ContainsKey(ch))
                    {
                        isExchangable = false;
                    }
                }
            }

            Console.WriteLine(isExchangable.ToString().ToLower());
        }

        private static decimal CharMultiply(string smallerWord, string biggerWord)
        {
            decimal result = 0;
            int smallerWordLength = smallerWord.Length;
            string biggerWordSubstring = biggerWord.Substring(smallerWordLength);

            for (int i = 0; i < smallerWordLength; i++)
            {
                result += smallerWord[i] * biggerWord[i];
            }

            foreach (var ch in biggerWordSubstring)
            {
                result += ch;
            }

            return result;
        }

        public static void CharacterMultiplier()
        {
            string[] input = Console.ReadLine().Split();
            decimal sum = 0;
            int firstWordLenght = input[0].Length;
            int secondWordLenght = input[1].Length;
            if (firstWordLenght > secondWordLenght)
            {
                sum = CharMultiply(input[1], input[0]);
            }
            else
            {
                sum = CharMultiply(input[0], input[1]);
            }

            Console.WriteLine(sum);
        }

        public static void Palindromes()
        {
            string input = Console.ReadLine();
            char[] separators = new[] { ' ', ',', '?', '!', '.', '\t' };
            string[] words = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            var result = new List<string>();

            foreach (var word in words)
            {
                if (IsPalindrome(word))
                {
                    result.Add(word);
                }
            }

            Console.WriteLine($"[{string.Join(", ", result.Distinct().OrderBy(x => x))}]");
        }

        private static bool IsPalindrome(string word)
        {
            for (int i = 0; i < word.Length / 2; i++)
            {
                if (!word[i].Equals(word[word.Length - i - 1]))
                {
                    return false;
                }
            }

            return true;
        }

        public static void UnicodeCharacters()
        {
            string textToConvert = Console.ReadLine();

            int len = textToConvert.Length;

            StringBuilder result = new StringBuilder();
            foreach (char c in textToConvert)
            {
                result.Append("\\u");
                result.Append(string.Format("{0:x4}", (int)c));
            }
            Console.WriteLine(result.ToString());
        }

        public static void TextFilter()
        {
            string[] filter = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();

            foreach (var word in filter)
            {
                text = text.Replace(word, new string('*', word.Length));
            }

            Console.WriteLine(text);
        }

        public static void MultiplyBigNumbers()
        {
            string firstNumber = Console.ReadLine().TrimStart(new char[] { '0' });
            byte secondNumber = byte.Parse(Console.ReadLine());

            if (firstNumber == "0" || secondNumber == 0 || firstNumber == "")
            {
                Console.WriteLine(0);
                return;
            }

            byte product = 0;
            byte numberInMind = 0;
            byte remainder = 0;
            StringBuilder result = new StringBuilder();

            for (int i = firstNumber.Length - 1; i >= 0; i--)
            {
                product = (byte)(byte.Parse(firstNumber[i].ToString()) * secondNumber + numberInMind);
                numberInMind = (byte)(product / 10);
                remainder = (byte)(product % 10);
                result.Append(remainder);
                if (i == 0 && numberInMind != 0)
                {
                    result.Append(numberInMind);
                }
            }

            char[] resultToCharArr = result.ToString().ToCharArray();
            Array.Reverse(resultToCharArr);
            Console.WriteLine(new string(resultToCharArr));
        }

        public static void SumBigNumbers()
        {
            string firstNumber = Console.ReadLine().TrimStart(new char[] { '0' });
            string secondNumber = Console.ReadLine().TrimStart(new char[] { '0' });

            if (firstNumber.Length > secondNumber.Length)
            {
                secondNumber = secondNumber.PadLeft(firstNumber.Length, '0');
            }
            else
            {
                firstNumber = firstNumber.PadLeft(secondNumber.Length, '0');
            }

            byte sum = 0;
            byte numberInMind = 0;
            byte remainder = 0;
            StringBuilder result = new StringBuilder();

            for (int i = firstNumber.Length - 1; i >= 0; i--)
            {
                sum = (byte)(byte.Parse(firstNumber[i].ToString()) + byte.Parse(secondNumber[i].ToString()) + numberInMind);
                numberInMind = (byte)(sum / 10);
                remainder = (byte)(sum % 10);
                result.Append(remainder);
                if (i == 0 && numberInMind != 0)
                {
                    result.Append(numberInMind);
                }
            }

            char[] resultToChar = result.ToString().ToCharArray();
            Array.Reverse(resultToChar);
            Console.WriteLine(new string(resultToChar));
        }

        public static void CountSubstringOccurence()
        {
            string text = Console.ReadLine().ToLower();
            string part = Console.ReadLine().ToLower();
            int len = part.Length;
            int countSubstrings = 0;
            for (int i = 0; i <= text.Length - len; i++)
            {
                if (text.Substring(i, len).Equals(part))
                {
                    countSubstrings++;
                }
            }
            Console.WriteLine(countSubstrings);
        }

        public static void ConvertFromNTo10Base()
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();
            int baseNumber = int.Parse(input[0]);
            string numberToConvert = input[1];
            BigInteger result = 0;
            int len = numberToConvert.Length;
            for (int i = 0; i < len; i++)
            {
                int currentDigit = int.Parse(numberToConvert[len - 1 - i].ToString());
                result += currentDigit * BigInteger.Pow(baseNumber, i);
            }
            Console.WriteLine(result);
        }

        public static void ConvertFrom10ToNbase()
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();
            BigInteger baseNumber = BigInteger.Parse(input[0]);
            BigInteger numberToConvert = BigInteger.Parse(input[1]);
            string result = string.Empty;
            while (numberToConvert != 0)
            {
                result = numberToConvert % baseNumber + result;
                numberToConvert = numberToConvert / baseNumber;
            }
            Console.WriteLine(result);
        }

        public static void FormattingNumbers()
        {
            string[] input = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int firstNumber = int.Parse(input[0]);
            var secondNumber = double.Parse(input[1]);
            var thirdNumber = double.Parse(input[2]);
            var firstNumInHex = Convert.ToString(firstNumber, 2);
            var firstNumBin = Convert.ToString(firstNumber, 2).PadLeft(10, '0');
            if (firstNumBin.Length > 10)
            {
                firstNumBin = firstNumBin.Substring(0, 10);
            }
            Console.WriteLine("|{0,-10:X}|{1,10}|{2,10:F2}|{3,-10:F3}|", firstNumber, firstNumBin, secondNumber, thirdNumber);
        }

        public static void StringLength()
        {
            var input = Console.ReadLine();
            var result = input.PadRight(20, '*');
            Console.WriteLine(result);
        }

        public static void ReverseStringLessMemory()
        {
            var input = Console.ReadLine();
            char[] result = new char[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                result[result.Length - i - 1] = input[i];
            }

            input = new string(result);

            Console.WriteLine(input);
        }
    }
}