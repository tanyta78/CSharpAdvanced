namespace _01ProblemOddLines
{
    using System;
    using System.IO;

    public class OddLines
    {
        public static void Main()
        {
            StreamReader reader = new StreamReader("../../somefile.txt");

            try
            {
                int linenumber = 0;

                string line = reader.ReadLine();
                while (line != null)
                {

                    if (linenumber % 2 == 1)
                    {
                        Console.WriteLine(line);
                    }
                    linenumber++;
                    line = reader.ReadLine();
                }
            }
            finally
            {
                reader.Close();
            }
           
        }
    }
}