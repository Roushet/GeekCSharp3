using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson6Homework
{
    //TODO ПЕРЕДЕЛАТЬ НА List<List<int>>

    class Matrix
    {
        private int[,] _matrix;

        private int _scale;

        //публичное поле, размер матрицы
        public int Scale { get => _scale; }

        //конструктор по умолчанию, создаёт матрицу 100 на 100
        public Matrix()
        {
            _matrix = new int[100, 100];
            _scale = 100;
            FillMatrixWithRandoms();
        }

        //параметрический конструктор, создаёт матрицу любого размера
        public Matrix(int scale)
        {
            _matrix = new int[scale, scale];
            _scale = scale;
            FillMatrixWithRandoms();
        }

        //индексатор полей матрицы
        public int this[int i, int j]
        {
            get => _matrix[i, j];
            set => _matrix[i, j] = value;
        }

        //заполнение матрицы случайными числами
        private void FillMatrixWithRandoms()
        {
            for (int i = 0; i < _scale; i++)
                for (int j = 0; j < _scale; j++)
                    _matrix[i, j] = RandomProvider.GetThreadRandom().Next(-20, 20);
        }

        //распечатываем матрицу в консоль
        public override string ToString()
        {
            string output = "";

            for (int i = 0; i < _scale; i++)
            {
                for (int j = 0; j < _scale; j++)
                    output += _matrix[i, j].ToString() + " ";

                output += "\n";
            }
            return output;
        }

        public async Task<Matrix> Multiply(Matrix mat1, Matrix mat2)
        {
            if (mat1.Scale != mat2.Scale) throw new Exception(String.Format("Матрицы имеют разные размеры: {0} и {1}", mat1.Scale, mat2.Scale));

            Matrix result = new Matrix(mat1.Scale);
            List<Task<int>> TaskList = new List<Task<int>>();

            for (int i = 0; i < result.Scale; i++)
            {
                for (int j = 0; j < result.Scale; j++)
                {
                    //Замыкания лямда-выражений...Для i и j в цикле создайте временные 
                    // переменные. И в каждой итерации объявляете новую переменную и 
                    //копируете в неё значение. Тогда замыкание будет на неё, 
                    //а не на переменную цикла.

                    int i2 = i;
                    int j2 = j;
                    TaskList.Add(new Task<int>(() => result[i2, j2] = DotProduct(GetRow(mat1,  i2), GetColumn(mat2, j2))));
                    //result[i, j] = DotProduct(GetRow(mat1, i), GetColumn(mat2, j));
                }
            }

            Parallel.ForEach(TaskList, task => task.Start());

            //Task.WaitAll(TaskList.ToArray());

            await Task.WhenAll<int>(TaskList);

            //var res = await Task.WhenAll<int>(TaskList);

            return result;
        }

        public int DotProduct(int[] vector1, int[] vector2)
        {
            if (vector1.Length != vector2.Length) throw new Exception(String.Format("Длины строк матрицы не совпадают: {0} и {1}", vector1.Length, vector2.Length));

            Console.WriteLine("Dot product running at thread {0}", Thread.CurrentThread.ManagedThreadId);

            int result = 0;

            for (int i = 0; i < vector2.Length; i++)
                result += vector1[i] * vector2[i];

            return result;
        }

        private int[] GetRow(Matrix matrix, int row)
        {
            if (row >= matrix.Scale) throw new Exception(String.Format("Попытка получить столбец за пределами матрицы"));

            int[] result = new int[matrix.Scale];
            for (int i = 0; i < matrix.Scale; i++)
            {
                result[i] = matrix[row, i];
            }

            return result;
        }

        private int[] GetColumn(Matrix matrix, int column)
        {
            if (column >= matrix.Scale) throw new Exception(String.Format("Попытка получить строку за пределами матрицы"));

            int[] result = new int[matrix.Scale];
            for (int i = 0; i < matrix.Scale; i++)
            {
                result[i] = matrix[i, column];
            }

            return result;
        }

    }
}
