using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WatchPerformance
{
    internal class Performance
    {
        private static void Main(string[] args)
        {
            //list performance
            var watch = Stopwatch.StartNew();
            var list = new List<string>();

            for (int i = 0; i < 1000000; i++)
            {
                list.Add(i.ToString());
            }

            watch.Stop();
            Console.WriteLine($"List add {watch.ElapsedTicks}");

            watch = Stopwatch.StartNew();
            list.Contains("888888");
            watch.Stop();
            Console.WriteLine($"List contains {watch.ElapsedTicks}");

            watch = Stopwatch.StartNew();
            list.Remove("888888");
            watch.Stop();
            Console.WriteLine($"List remove {watch.ElapsedTicks}");

            //hash set performance
            watch = Stopwatch.StartNew();

            var set = new HashSet<string>();

            for (int i = 0; i < 1000000; i++)
            {
                set.Add(i.ToString());
            }

            watch.Stop();
            Console.WriteLine($"Hashset add {watch.ElapsedTicks}");

            watch = Stopwatch.StartNew();
            set.Contains("888888");
            watch.Stop();
            Console.WriteLine($"Hashset contains {watch.ElapsedTicks}");

            watch = Stopwatch.StartNew();
            set.Remove("888888");
            watch.Stop();
            Console.WriteLine($"Hashset remove {watch.ElapsedTicks}");

            //sortedset performance
            watch = Stopwatch.StartNew();

            var sortset = new SortedSet<string>();

            for (int i = 0; i < 1000000; i++)
            {
                sortset.Add(i.ToString());
            }

            watch.Stop();
            Console.WriteLine($"SortedSet add {watch.ElapsedTicks}");

            watch = Stopwatch.StartNew();
            sortset.Contains("888888");
            watch.Stop();
            Console.WriteLine($"SortedSet contains {watch.ElapsedTicks}");

            watch = Stopwatch.StartNew();
            sortset.Remove("888888");
            watch.Stop();
            Console.WriteLine($"SortedSet remove {watch.ElapsedTicks}");

            //stack performance
            watch = Stopwatch.StartNew();

            var stack = new Stack<string>();

            for (int i = 0; i < 1000000; i++)
            {
                stack.Push(i.ToString());
            }

            watch.Stop();
            Console.WriteLine($"Stack add {watch.ElapsedTicks}");

            watch = Stopwatch.StartNew();
            stack.Contains("888888");
            watch.Stop();
            Console.WriteLine($"Stack contains {watch.ElapsedTicks}");

            watch = Stopwatch.StartNew();
            stack.Pop();
            watch.Stop();
            Console.WriteLine($"Stack remove {watch.ElapsedTicks}");
        }
    }
}