using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Shoot_List_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> myList = new List<int>();
            string input = Console.ReadLine();
            int lastRemovedInt=-1;
            bool print = false;
            while (!input.Equals("stop"))
            {
                if (!input.Equals("bang"))
                {
                    myList.Insert(0, int.Parse(input));
                }
                else
                {
                    if (myList.Count == 0)
                    {
                        Console.WriteLine($"nobody left to shoot! last one was {lastRemovedInt}");
                        print = true;
                        break;

                    }
                    if (myList.Count==1)
                    {
                        lastRemovedInt = myList[0];
                        
                    }
                    else
                    {
                        lastRemovedInt = myList.Where(d => d < myList.Average()).ToList()[0];
                    }
                    
                    Console.WriteLine($"shot {lastRemovedInt}");
                    myList.Remove(lastRemovedInt);
                    if (myList.Count != 0)
                    {
                       myList= myList.Select(n => n - 1).ToList();
                    }
                }
                input = Console.ReadLine();
            }
            if (!print)
            {
                if (myList.Count == 0)
                {
                    Console.WriteLine($"you shot them all. last one was {lastRemovedInt}");
                }
                else
                {
                    Console.Write("survivors: ");
                    Console.WriteLine(string.Join(" ", myList));
                }
            }
            

        }
    }
}
