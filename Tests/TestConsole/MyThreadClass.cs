using System;
using System.Threading;

namespace TestConsole
{
    public static class MyThreadClass
    {
        public static int NumF { get; set; }
        public static int NumS { get; set; }

        public static void FactorialCalculating() => Console.WriteLine($"Факториал: {Factorial(NumF)}");
        public static void SumCalculating() => Console.WriteLine($"Сумма: {Sum(NumS)}");
        static int Factorial(int i)
        {
            Thread.Sleep(100);
            Console.WriteLine($"Идет вычисление факториала");
            return (i == 1) ? 1 : i * Factorial(i - 1);
        }
        static int Sum(int n)
        {
            Thread.Sleep(100);
            Console.WriteLine($"Идет вычисление суммы");
            return (n == 0) ? 0 : n + Sum(n - 1);
        }
    }
}
