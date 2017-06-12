namespace _02ProblemLineNumbers
{
    using System;
    using System.IO;


    public class LineNumbers
    {
       public static void Main()
        {

            StreamReader reader = new StreamReader("../../somefile.txt");
            StreamWriter writer = new StreamWriter("../../somenewfile.txt");
            try
            {
                int linenumber = 1;

                string line = reader.ReadLine();
                while (line != null)
                {
                    writer.WriteLine($"{linenumber}. " + line);
                    linenumber++;
                    line = reader.ReadLine();
                }
            }
            finally
            {

                writer.Close();
                reader.Close();
            }
           

        }
    }
}
