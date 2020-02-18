using System.Threading;
using System.Linq;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using TestConsole.Matrix;
using  System.Linq;

namespace TestConsole
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //небольшая развлекаловка с событиями
            //EventsTest test = new EventsTest();
            //KeyPresser keyPresser = new KeyPresser();
            //test.OnMethod += keyPresser.Message;
            //var thread = new Thread(() => keyPresser.Changing()) { IsBackground = true };
            //thread.Start();
            //test.RunTest();

            //Lesson5();

            Lesson6();
        }

        static void Lesson5()
        {
            Console.WriteLine("Число для фатокториала:");
            MyThreadClass.NumF = int.Parse(Console.ReadLine());
            Console.WriteLine("Число для суммы:");
            MyThreadClass.NumS = int.Parse(Console.ReadLine());
            var thread_one = new Thread(MyThreadClass.FactorialCalculating);
            var thread_two = new Thread(MyThreadClass.SumCalculating);
            thread_one.Start();
            thread_two.Start();
            thread_one.Join();
            thread_two.Join();
            Parallel.Invoke(new ParallelOptions { MaxDegreeOfParallelism = 3 }, MyThreadClass.FactorialCalculating, MyThreadClass.SumCalculating, MyThreadClass.FactorialCalculating);
        }

        static void Lesson6()
        {

            MatrixParallelMultiplication.ParallelMatrix(); //параллельное вычисление

            MatrixAsyncMultiplication.AsyncMatrix();//асинхронный расчет

        }

    }

}
