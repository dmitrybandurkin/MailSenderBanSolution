using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TestConsole.Matrix
{
    class MatrixAsyncMultiplication : MatrixBase
    {
        private static int[,] ResultMatrixAsync;

        static MatrixAsyncMultiplication()
        {
            ResultMatrixAsync = new int[Size, Size];
        }

        public static void AsyncMatrix()
        {
            MultipleMatrix(MatrixA, MatrixB);
            //какая - то работа в основном потоке
            //for (int i = 0; i < 20; i++)
            //{
            //    Thread.Sleep(500);
            //    Console.WriteLine($"Работа в основном потоке {i} итерация");
            //}
            //MultipleMatrix(MatrixA, MatrixB);
        }

        private static async void MultipleMatrix(int[,] matrixA, int[,] matrixB) // перемножение матриц
        {
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    tasks.Add(new Task(() => MultipleCell(i, j, matrixA, matrixB))); // хотел создать ряд асинхронных процессов для долгих единичных рассчетов
                    Console.WriteLine(j);
                }
            }

            foreach (var t in tasks)
            {
                t.Start();
            }
            await Task.WhenAll(tasks);
        }

        private static void MultipleCell(int i, int j, int[,] matrixA, int[,] matrixB) //единичное вычисление ячейки матрицы
        {
            Console.WriteLine($"Начат рассчет в потоке {Thread.CurrentThread.ManagedThreadId} задачи {Task.CurrentId}");
            int msum = 0;
            for (int l = 0; l < Size; l++)
            {
                msum = msum + matrixA[i, l] * matrixB[l, j];
            }

            Task.Delay(1000); // имитация долгой работы
            ResultMatrixAsync[i,j] = msum;
        }
    }
}
