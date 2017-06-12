namespace _03ProblemWordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;


    public class WordCount
    {
        public static void Main()
        {
            StreamReader reader = new StreamReader("../../words.txt");
            StreamReader textreader = new StreamReader("../../text.txt");
            StreamWriter writer = new StreamWriter("../../result.txt");
            try
            {
              
                string line = reader.ReadLine();
                var wordsCount = new Dictionary<string,int>();
                //read words.txt
                while (line!=null)
                {
                    if (!wordsCount.ContainsKey(line))
                    {
                        wordsCount.Add(line,0);
                    }
                    
                    line = reader.ReadLine();
                }

                //read text
                StringBuilder allText = new StringBuilder();
                var textline = textreader.ReadLine();
                while (textline!=null)
                {
                    allText.Append(textline);
                    textline = textreader.ReadLine();
                }

                string[] textToCheck = allText.ToString().ToLower().Split(new []{' ','\t',',','.','!','?','-'},StringSplitOptions.RemoveEmptyEntries).ToArray();
                
                //check text and get results

                foreach (var word in textToCheck)
                {
                    if (wordsCount.ContainsKey(word))
                    {
                        wordsCount[word]++;
                    } 
                }

                foreach (var pair in wordsCount.OrderByDescending(x=>x.Value))
                {
                    writer.WriteLine($"{pair.Key} - {pair.Value}");
                }
              
            }
            finally
            {
                reader.Close();
                textreader.Close();
                writer.Close();
            }


        }
    }
}
