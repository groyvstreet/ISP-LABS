using System;

namespace Lab2_int
{
    class Program
    {
        static void Main(string[] args)
        {
            bool inputCorrect;
            ulong a, b = 0, multi = 1;
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
                    multi = 1;

                    for (ulong i = a; i <= b; i++)
                    {
                        multi *= i;
                    }

                    if (multi == 0)
                    {
                        if (a > 0 && b > 0)
                        {
                            Console.WriteLine("Overlow!\n");
                            inputCorrect = false;
                        }
                        else
                        {
                            Console.WriteLine("a * b is ZERO!\n");
                            inputCorrect = false;
                        }
                    }
                }

            } while (!inputCorrect);

            int level = 0;
            ulong divider = 1;

            while (multi % divider == 0)
            {
                Console.WriteLine($"Level {level}: {multi} / {divider} = " + multi / divider + " + " + multi % divider);
                divider *= 2;
                level++;
            }

            Console.WriteLine($"Level {level}: {multi} / {divider} = " + multi / divider + " + " + multi % divider);
            Console.WriteLine("Max level: " + --level);
        }
    }
}
