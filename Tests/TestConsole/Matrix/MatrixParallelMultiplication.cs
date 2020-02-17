using System;
using System.Collections.Generic;
using System.Text;
using  System.Threading;
using System.Threading.Tasks;

namespace TestConsole.Matrix
{
    class MatrixParallelMultiplication : MatrixBase
    {
        private static int[,] ResultMatrixP;

        static MatrixParallelMultiplication()
        {
            ResultMatrixP = new int[Size,Size];
        }

        public static void ParallelMatrix()
        {
            var ParallelTask = new Task(() => MultipleMatrix(MatrixA, MatrixB));
            ParallelTask.Start();

            //какая-то работа в основном потоке
            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine("Работа в основном потоке");
            }

        }

        private static void MultipleMatrix(int[,] matrixA, int[,] matrixB) // перемножение матриц
        {
            Console.WriteLine($"Вычисления производятся в #{Task.CurrentId} задаче #{Thread.CurrentThread.ManagedThreadId} потока");

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    ResultMatrixP[i, j] = MultipleCell(i, j, matrixA, matrixB);
                }
            }

            Console.WriteLine($"Вычисления закончены в #{Task.CurrentId} задаче #{Thread.CurrentThread.ManagedThreadId} потока");
        }

        private static int MultipleCell(int i, int j, int[,] matrixA, int[,] matrixB) //единичное вычисление ячейки матрицы
        {
            int msum = 0;
            for (int l = 0; l < Size; l++)
            {
                msum = msum + matrixA[i, l] * matrixB[l, j];
            }
            return msum;
        }

    }
}
