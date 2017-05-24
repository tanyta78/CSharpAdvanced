namespace StringEx
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class ManualStringProcessing
    {
       public static void Main()
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
