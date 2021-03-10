using System;

namespace Lab2_int
{
    class Program
    {
        static void Main(string[] args)
        {
            bool inputCorrect;
            ulong a, b = 0;
            string strA, strB;

            do
            {
                Console.Write("Enter a: ");
                strA = Console.ReadLine();
                Console.Write("Enter b: ");
                strB = Console.ReadLine();

                inputCorrect = ulong.TryParse(strA, out a);

                if (inputCorrect)
                {
                    inputCorrect = ulong.TryParse(strB, out b);
                }

                if(a > b)
                {
                    inputCorrect = false;
                }

                if (!inputCorrect)
                {
                    Console.WriteLine("Invalid input!\n");
                }

                if (inputCorrect)
                {
                    if (a == 0)
                    {
                        Console.WriteLine("Product of numbers is ZERO!\n");
                        inputCorrect = false;
                    }
                }

            } while (!inputCorrect);

            ulong level = 0;
            --a;

            while (a != 0)
            {
                a /= 2;
                level -= a;
            }

            while (b != 0)
            {
                b /= 2;
                level += b;
            }

            Console.WriteLine("Max level: " + level);
        }
    }
}
