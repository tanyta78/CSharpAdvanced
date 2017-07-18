using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace OfficeStuff
{
    public class StartUp
    {
        public static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            string pattern = @"[|^](\w+) - (\d+) - (\w+)|$";
            Regex inputCheck = new Regex(pattern);
            var companyStuff = new SortedDictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < lines; i++)
            {
                string currentLine = Console.ReadLine();
                if (currentLine != null && inputCheck.IsMatch(currentLine))
                {
                    string company = inputCheck.Match(currentLine).Groups[1].ToString();
                    int quantity = int.Parse(inputCheck.Match(currentLine).Groups[2].ToString());
                    string product = inputCheck.Match(currentLine).Groups[3].ToString();

                    if (!companyStuff.ContainsKey(company))
                    {
                        companyStuff.Add(company, new Dictionary<string, int>());
                    }

                    if (!companyStuff[company].ContainsKey(product))
                    {
                        companyStuff[company].Add(product, 0);
                    }

                    companyStuff[company][product] += quantity;
                }
            }

            foreach (var companyInfo in companyStuff)
            {
                Console.Write($"{companyInfo.Key}: ");
                var sb = new StringBuilder();
                foreach (var productsInfo in companyInfo.Value)
                {
                    sb.Append($"{productsInfo.Key}-{productsInfo.Value}, ");
                }
                sb.Length -= 2;
                Console.WriteLine(sb);
            }
        }
    }
}