using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace _06ProblemZipSlicedFile
{
    public class ZipSlisedFile
    {
        public static void Main()
        {
            Console.Write("Hello user! What do you want to do - Slice or Merge: ");
            var userChoice = Console.ReadLine().ToLower();
            if (userChoice == "slice")
            {

                Console.Write("Enter file path: ");
                var filePath = Console.ReadLine();
                Console.Write("Enter destination folder: ");
                var folder = Console.ReadLine();
                Console.WriteLine("How many parts do you want? ");
                var slices = int.Parse(Console.ReadLine());
                try
                {
                    Slice(filePath, folder, slices);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Something went wrong when slicing: {ex.Message}");
                }
            }
            else
            {

                var files = new List<string>();
                int counter = 1;
                Console.WriteLine("Enter files paths or END to stop adding files to the list.");
                Console.Write($"Path for file{counter}: ");
                var path = Console.ReadLine();

                while (path.ToUpper() != "END")
                {
                    if (!path.EndsWith(".GZ"))
                    {
                        Console.WriteLine("Only .gz files accepted for merging.");
                        Console.Write($"Path for file{counter}: ");
                        path = Console.ReadLine();
                        continue;
                    }
                    counter++;
                    files.Add(path);
                    Console.Write($"Path for file{counter}: ");
                    path = Console.ReadLine();
                }

                Console.Write("Enter destination folder: ");
                var folder = Console.ReadLine();



                try
                {
                    Assemble(files, folder);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Something went wrong when merging: {ex.Message}");
                }

            }
        }

        private static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }
            Console.WriteLine("Slicing...");
            FileStream fsIN = new FileStream(sourceFile, FileMode.Open, FileAccess.Read);
            using (fsIN)
            {
                int sizeOfEachFile = (int)Math.Ceiling((double)fsIN.Length / parts);
                string fileName = Path.GetFileNameWithoutExtension(sourceFile);
                string extension = Path.GetExtension(sourceFile);

                for (int i = 1; i <= parts; i++)
                {
                    var outFilepath = destinationDirectory + "\\" + fileName + $"Part{i}" + extension;
                    FileStream fsOUT = new FileStream(outFilepath, FileMode.Create, FileAccess.Write);

                    using (fsOUT)
                    {
                        GZipStream zipStream = new GZipStream(fsOUT, CompressionMode.Compress, false);
                        int bytesRead = 0;
                        byte[] buffer = new byte[sizeOfEachFile];

                        if ((bytesRead = fsIN.Read(buffer, 0, sizeOfEachFile)) > 0)
                        {
                            zipStream.Write(buffer, 0, bytesRead);
                        }
                    }
                }
            }
            Console.WriteLine("Slicing and zipping done.");
        }


        private static void Assemble(List<string> files, string folder)
        {
            if (files.Count <= 0)
            {
                Console.WriteLine("No input files specified!");
                return;
            }
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            Console.WriteLine("Merging");


            var fileExtension = Path.GetExtension(files.First());

            var path = folder + "\\" + "assembled" + fileExtension;

            FileStream fsOUT = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);

            using (fsOUT)
            {
                foreach (var filePath in files)
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = 0;

                    FileStream inpFile = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                    GZipStream zipStream = new GZipStream(inpFile, CompressionMode.Decompress, false);
                    using (inpFile)
                    {
                        using (zipStream)
                        {
                            while ((bytesRead = zipStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                fsOUT.Write(buffer, 0, bytesRead);
                            }
                        }

                    }
                }
            }

            Console.WriteLine("Files Merged");
        }
    }
}
