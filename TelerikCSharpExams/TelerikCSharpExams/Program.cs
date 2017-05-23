
namespace TelerikCSharpExams
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            // Feathers();
           // Busies();
            int numberOfDigits = int.Parse(Console.ReadLine());
            int numberOfPages = 0;
            if (numberOfDigits<10)
            {
                numberOfPages = numberOfDigits;
            }//TO DO else if(numberOfDigits)
        }

        private static void Busies()
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            int groups = 1;
            int currentCarSpeed = int.Parse(Console.ReadLine());
            for (int i = 1; i < numberOfCars; i++)
            {
                int nextCarSpeed = int.Parse(Console.ReadLine());
                if (nextCarSpeed > currentCarSpeed)
                {
                    nextCarSpeed = currentCarSpeed;
                }
                else
                {
                    groups++;
                }

                currentCarSpeed = nextCarSpeed;
            }
            Console.WriteLine(groups);
        }

        private static void Feathers()
        {
            ulong numberOfBirds = ulong.Parse(Console.ReadLine());
            ulong allBirdFeathers = ulong.Parse(Console.ReadLine());


            double result = 0;
            if (allBirdFeathers != 0 && numberOfBirds != 0)
            {
                double averageFeathersPerBirds = (double)allBirdFeathers / numberOfBirds;

                if (numberOfBirds % 2 == 1)
                {
                    result = (double)averageFeathersPerBirds / 317;
                }
                else
                {
                    result = averageFeathersPerBirds * 123123123123;
                }
            }


            Console.WriteLine("{0:0.0000}", result);
        }
    }
}
