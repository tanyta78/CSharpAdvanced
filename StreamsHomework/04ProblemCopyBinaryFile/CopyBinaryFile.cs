namespace _04ProblemCopyBinaryFile
{
    using System;
    using System.IO;
    using System.Text;

    public class CopyBinaryFile
    {
        private const string CupOfCoffee = "../../good.jpg";
        private const string DestinationPath = "../../result.jpg";

        public static void Main()
        {
            using (var source = new FileStream(CupOfCoffee, FileMode.Open))
            {
                using (var destination = new FileStream(DestinationPath, FileMode.Create))
                {
                    double fileLenght = source.Length;
                    byte[] buffer = new byte[4096];

                    while (true)
                    {
                        int readBytes = source.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                        {
                            break;
                        }

                        destination.Write(buffer, 0, readBytes);

                        //Console.WriteLine("{0:P}", Math.Min(source.Position / fileLenght, 1));
                    }
                }
            }


        }
    }
}
