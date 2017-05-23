using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Average_Character_Delimiter
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();
            int sum = 0;
            int count = 0;
            foreach (var ch in input)
            {
                if (!ch.Equals(' '))
                {
                    sum += ch;
                    count++;
                }
               
            }
            char toInput = (char)Math.Floor((decimal)sum / count);
            toInput = char.ToUpper(toInput);
            StringBuilder result = new StringBuilder();
            foreach (var ch in input)
            {
                if (ch.Equals(' '))
                {
                    result.Append(toInput);
                }
                else
                {
                    result.Append(ch);
                }
               
            }
            Console.WriteLine(result);

            
        }
    }
}
