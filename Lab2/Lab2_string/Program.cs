using System;

namespace Lab2_string
{
    class Program
    {
        static void Main(string[] args)
        {
            string input, temp = "", result = "";
            Console.Write("Enter a string: ");
            input = Console.ReadLine();
            input = input.Trim();
            input += " ";

            for(int i = 0; i < input.Length; i++)
            {
                temp += Char.ToString(input[i]);

                if(input[i] == ' ')
                {
                    result = result.Insert(0, temp);
                    temp = "";
                }
            }

            Console.WriteLine(result);
        }
    }
}
