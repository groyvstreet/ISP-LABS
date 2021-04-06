using System;
using System.Runtime.InteropServices;

namespace Lab4_2
{
    class Program
    {
        [DllImport("dllmath.dll")]
        public static extern int Module(int num);
        [DllImport("dllmath.dll")]
        public static extern double ModuleD(double num);
        [DllImport("dllmath.dll")]
        public static extern int Max(int num1, int num2);
        [DllImport("dllmath.dll")]
        public static extern int Min(int num1, int num2);
        [DllImport("dllmath.dll")]
        public static extern int Pow(int num, int level);
        [DllImport("dllmath.dll")]
        public static extern double Sin(double x);
        [DllImport("dllmath.dll")]
        public static extern double Cos(double x);
        [DllImport("dllmath.dll")]
        public static extern double Tg(double x);
        [DllImport("dllmath.dll")]
        public static extern double Ctg(double x);
        static void Main(string[] args)
        {
            Console.WriteLine($"Module (-5): {Module(-5)}");
            Console.WriteLine($"Module (-5.5): {ModuleD(-5.5)}");
            Console.WriteLine($"Max (12, 1): {Max(12, 1)}");
            Console.WriteLine($"Min (12, 1): {Min(12, 1)}");
            Console.WriteLine($"2 ^ 3 = {Pow(2, 3)}");
            Console.WriteLine($"Sin(0.5) = {Sin(0.5)}");
            Console.WriteLine($"Cos(0.5) = {Cos(0.5)}");
            Console.WriteLine($"Tg(0.5) = {Tg(0.5)}");
            Console.WriteLine($"Ctg(0.5) = {Ctg(0.5)}");
        }
    }
}
