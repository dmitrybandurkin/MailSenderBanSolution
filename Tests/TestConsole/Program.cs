using System;
using System.Threading;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var thread_one = new Thread(MyThreadClass.FactorialCalculating);
            var thread_two = new Thread(MyThreadClass.SumCalculating);

            Console.WriteLine("Число для факториала?");
            MyThreadClass.NumF = int.Parse(Console.ReadLine());
            thread_one.Start();
            Console.WriteLine("Число для суммы?");
            MyThreadClass.NumS = int.Parse(Console.ReadLine());
            thread_two.Start();

            Console.ReadKey();
        }
    }

    public static class MyThreadClass
    {
        public static int NumF { get; set; }
        public static int NumS { get; set; }

        public static void FactorialCalculating() => Console.WriteLine($"Факториал: {Factorial(NumF)}");
        public static void SumCalculating() => Console.WriteLine($"Сумма: {Sum(NumS)}");
        static int Factorial(int i)
        {
            Thread.Sleep(500);
            Console.WriteLine($"Идет вычисление факториала");
            return (i == 1) ? 1 : i * Factorial(i - 1);
        }
        static int Sum(int n)
        {
            Thread.Sleep(500);
            Console.WriteLine($"Идет вычисление суммы");
            return (n == 0) ? 0 : n + Sum(n - 1);
        }
    }
}
