using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsole.Matrix
{
    abstract class MatrixBase
    {
        protected const int Size = 1000;
        protected static int[,] MatrixA;
        protected static int[,] MatrixB;
        static MatrixBase() //инициализация матриц
        {
            Random rnd = new Random();
            MatrixA = new int[Size, Size];
            MatrixB = new int[Size, Size];
            FillingMatrix(ref MatrixA);
            FillingMatrix(ref MatrixB);
        }
        protected static void FillingMatrix(ref int[,] matrix) //заполнение матриц рандомными числами
        {
            Random random = new Random();

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    matrix[i, j] = random.Next(0, 11);
                }
            }
        }
    }
}
