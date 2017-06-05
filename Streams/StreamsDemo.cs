using System;
using System.IO;

namespace Streams
{
    public class StreamsDemo
    {
        public static void Main()
        {
            StreamReader reader = new StreamReader("somefile.txt");

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
    }
}
