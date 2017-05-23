
namespace StringEx
{
    using System;
    using System.Linq;

    public class ManualStringProcessing
    {
       public static void Main()
       {
           string[] input = Console.ReadLine().Split().ToArray();
           int firstNumber = int.Parse(input[0]);
           double secondNumber = double.Parse(input[1]);
            double thirdNumber = double.Parse(input[2]);
           var firstNumInHex = Convert.ToString(firstNumber, 2); ;
           Console.WriteLine("|{0,-10:X}|{1,10}|{2,10:F2}|{3,-10:F3}|", firstNumber, firstNumInHex.PadLeft(10, '0'), secondNumber, thirdNumber);
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
