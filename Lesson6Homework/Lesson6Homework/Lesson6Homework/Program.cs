using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            //для матриц 3 на 3 - тест
            Matrix mat1 = new Matrix(3);
            Matrix mat2 = new Matrix(3);

            //Для матриц 100 на 100
            //Matrix mat1 = new Matrix();
            //Matrix mat2 = new Matrix();

            Console.WriteLine("Выводим матрицы \n");
            Console.WriteLine("Матрица 1 \n");
            Console.WriteLine(mat1.ToString());
            Console.WriteLine("Матрица 2 \n");
            Console.WriteLine(mat2.ToString());

            Matrix result = new Matrix(mat1.Scale);
            result = result.Multiply(mat1, mat2).Result;

            Console.WriteLine("\nРезультирующая \n");

            Console.WriteLine(result.ToString());

            Console.ReadLine();
        }
    }
}
