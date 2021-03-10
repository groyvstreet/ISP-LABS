using System;

namespace Lab2_DateTime
{
    class Program
    {
        static void DigitsAmount(string format)
        {
            int index;
            int[] digits = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            for (int i = 0; i < format.Length; i++)
            {
                if (Char.IsDigit(format[i]))
                {
                    index = format[i] - '0';
                    digits[index]++;
                }
            }

            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine(i + " amount: " + digits[i]);
            }

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            DateTime date = DateTime.Now;
            string format1 = date.ToString("F"), format2 = date.ToString("g");

            Console.WriteLine(format1);
            DigitsAmount(format1);
            Console.WriteLine(format2);
            DigitsAmount(format2);
        }
    }
}
