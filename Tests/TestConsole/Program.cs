using System.Threading;
using System.Linq;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace TestConsole
{
    class Program
    {
        const int Size = 1000;
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
            Random rnd = new Random();
            int[,] MatrixA = new int[Size, Size];
            int[,] MatrixB = new int[Size, Size];
            int[,] ResultMatrixP = new int[Size, Size];
            FillingMatrix(ref MatrixA);
            FillingMatrix(ref MatrixB);

            var ParallelTask = new Task<int[,]>(() => MultipleMatrix(MatrixA, MatrixB));
            ParallelTask.Start();

            //какая-то работа в основном потоке
            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine("Работа в основном потоке");
            }

            ResultMatrixP = ParallelTask.Result;
            
        }

        static void FillingMatrix(ref int[,] matrix)
        {
            Random random = new Random();

            for (int i = 0; i < Size; i++)
            {
                for (int j=0; j < Size; j++)
                {
                    matrix[i, j] = random.Next(0, 11);
                }
            }
        }

        static int[,] MultipleMatrix(int[,] matrixA, int[,] matrixB)
        {
            int[,] matrixC = new int[Size, Size];

            Console.WriteLine($"Вычисления производятся в #{Task.CurrentId} задаче #{Thread.CurrentThread.ManagedThreadId} потока");

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size ;j++)
                {
                    matrixC[i, j] = MultipleCell(i, j, matrixA, matrixB);
                }
            }

            Console.WriteLine($"Вычисления закончены в #{Task.CurrentId} задаче #{Thread.CurrentThread.ManagedThreadId} потока");

            return matrixC;
        }
        
        static int MultipleCell(int i, int j, int[,] matrixA, int[,] matrixB)
        {
            int msum=0;
            for (int l = 0; l < Size; l++)
            {
                msum = msum + matrixA[i, l] * matrixB[l, j];
            }
            return msum;
        }

        
    }

}
