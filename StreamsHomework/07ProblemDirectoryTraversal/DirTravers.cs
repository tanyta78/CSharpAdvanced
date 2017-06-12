using System;
using System.IO;
using System.Linq;
using System.Text;

namespace _07ProblemDirectoryTraversal
{
    public class DirTravers
    {
        private static StringBuilder builder = new StringBuilder();

        public static void Main()
        {

            Console.WriteLine("Please insert path to directory folder!");
            string directoryPath = Console.ReadLine();
          
            if (Directory.Exists(directoryPath))
            {
                DirectoryInfo info = new DirectoryInfo(directoryPath);
                Traverse(info, 1);

                SaveDataToTextFile(builder);

                Console.WriteLine("Results exported into: report.txt");
            }
            else
            {
                Console.WriteLine($"Not a valid path: {directoryPath}");
            }
        }

        private static void SaveDataToTextFile(StringBuilder stringBuilder)
        {
            StreamWriter sr = new StreamWriter(@"report.txt");

            using (sr)
            {
                sr.Write(stringBuilder.ToString());
            }
        }

        private static void Traverse(DirectoryInfo info, int indent)
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;
            try
            {
                files = info.GetFiles("*.*").Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden)).ToArray();
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            if (files != null)
            {
                //Console.WriteLine($"{new string('-', indentetion)}{root.Name}");
               builder.AppendLine($"{new string('-', indent)}{info.Name}");
                var extensions = files.Select(f => f.Extension).Distinct().OrderBy(x => x);

                foreach (var ext in extensions)
                {
                    //Console.WriteLine($"{ext}");
                    builder.AppendLine($"{ext}");
                    foreach (System.IO.FileInfo fi in files.Where(f => f.Extension == ext).OrderByDescending(x => x.Length).ThenBy(ff => ff.Name))
                    {
                        //Console.WriteLine($"{new string('-', indentetion + 1)}{fi.Name} - {(decimal)fi.Length / 1024:F3}kb");
                        builder.AppendLine($"{new string('~', indent + 1)}{fi.Name} - {(decimal)fi.Length / 1024:F3}kb");
                    }
                }
                // Now find all the subdirectories under this directory.
                subDirs = info.GetDirectories();

                foreach (System.IO.DirectoryInfo dirInfo in subDirs.OrderBy(d => d.Name))
                {
                    // Resursive call for each subdirectory.
                    Traverse(dirInfo, indent++);
                }
            }
        }
    }
}
