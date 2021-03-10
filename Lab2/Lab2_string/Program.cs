using System;

namespace Lab2_string
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a string: ");
            string[] words = Console.ReadLine().Split(' ');
            Array.Reverse(words);
            Console.WriteLine(String.Join(" ", words));
        }
    }
}
