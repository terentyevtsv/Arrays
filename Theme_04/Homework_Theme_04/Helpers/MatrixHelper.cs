using System;

namespace Homework_Theme_04.Helpers
{
    public static class MatrixHelper
    {
        /// <summary>
        /// Функция для ввода целочисленных данных
        /// </summary>
        /// <param name="message">Сообщение подсказка</param>
        /// <returns>Целое значение</returns>
        private static int GetInputNumber(string message)
        {
            Console.Write($"{message}: ");
            return int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Считывание размерностей матриц
        /// </summary>
        /// <returns></returns>
        private static int[] ReadMatrixSizes()
        {
            int rowsCount = GetInputNumber("Количество строк");
            int columnsCount = GetInputNumber(
                "Количество столбцов");
            if (rowsCount <= 0 || columnsCount <= 0)
                return null;

            return new[]
            {
                rowsCount,
                columnsCount
            };
        }

        /// <summary>
        /// Генерация случайной матрицы
        /// </summary>
        /// <param name="rowsCount">количество строк</param>
        /// <param name="columnsCount">количество столбцов</param>
        /// <returns></returns>
        private static int[,] GenerateMatrix(int rowsCount, 
            int columnsCount, string message, Random random)
        {
            var matrix = new int[rowsCount, columnsCount];

            Console.WriteLine($"{message}:");
            var buf = new int[columnsCount];

            // Сохранение и печать первоначальной матрицы
            for (int i = 0; i < rowsCount; ++i)
            {
                for (int j = 0; j < columnsCount; ++j)
                {
                    matrix[i, j] = random.Next(0, 100);
                    buf[j] = matrix[i, j];
                }

                Console.WriteLine(string.Join("\t", buf));
            }

            return matrix;
        }

        /// <summary>
        /// Умножение матрицы на число
        /// </summary>
        /// <param name="random"></param>
        public static void MultiplyMatrixNumber(Random random)
        {
            // Размеры матрицы
            var matrixSizes = ReadMatrixSizes();
            if (matrixSizes == null)
            {
                Console.WriteLine("Введите положительную размерность матрицы!");
                return;
            }

            int rowsCount = matrixSizes[0];
            int columnsCount = matrixSizes[1];

            // Генерация случайной матрицы
            var matrix = GenerateMatrix(rowsCount, 
                columnsCount, "Исходная матрица", random);

            // Множитель
            int number = GetInputNumber("Число для умножения");
            
            Console.WriteLine($"Результат умножения на {number}:");

            // Рассчет и печать результата
            var buf = new int[columnsCount];
            for (int i = 0; i < rowsCount; ++i)
            {
                for (int j = 0; j < columnsCount; ++j)
                {
                    buf[j] = matrix[i, j] * number;
                }

                Console.WriteLine(string.Join("\t", buf));
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Суммирование матриц
        /// </summary>
        /// <param name="matrix1">первая матрица</param>
        /// <param name="matrix2">вторая матрица</param>
        /// <param name="columnsCount">количество столбцов</param>
        /// <param name="rowsCount">количество строк</param>
        private static void AddMatrixes(int[,] matrix1, int[,] matrix2, int columnsCount, int rowsCount)
        {
            Console.WriteLine("Сложение матриц:");

            var buf = new int[columnsCount];
            for (int i = 0; i < rowsCount; ++i)
            {
                for (int j = 0; j < columnsCount; ++j)
                    buf[j] = matrix1[i, j] + matrix2[i, j];
                Console.WriteLine(string.Join("\t", buf));
            }

            Console.ReadKey();
        }

        /// <summary>
        /// разность матриц
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <param name="columnsCount"></param>
        /// <param name="rowsCount"></param>
        private static void SubtractMatrixes(int[,] matrix1, int[,] matrix2, int columnsCount, int rowsCount)
        {
            Console.WriteLine("Вычитание матриц:");

            var buf = new int[columnsCount];
            for (int i = 0; i < rowsCount; ++i)
            {
                for (int j = 0; j < columnsCount; ++j)
                    buf[j] = matrix1[i, j] - matrix2[i, j];
                Console.WriteLine(string.Join("\t", buf));
            }

            Console.ReadKey();
        }

        /// <summary>
        /// сложение и вычитание матриц
        /// </summary>
        /// <param name="random"></param>
        public static void ShowSimpleMatrixOperations(Random random)
        {
            // Размеры матриц
            var matrixSizes = ReadMatrixSizes();
            if (matrixSizes == null)
            {
                Console.WriteLine("Введите положительную размерность матрицы!");
                return;
            }

            int rowsCount = matrixSizes[0];
            int columnsCount = matrixSizes[1];

            // Генерация случайной матрицы
            var matrix1 = GenerateMatrix(rowsCount, 
                columnsCount, "Первая матрица", random);
            var matrix2 = GenerateMatrix(rowsCount, 
                columnsCount, "Вторая матрица", random);

            AddMatrixes(matrix1, matrix2, columnsCount, rowsCount);
            SubtractMatrixes(matrix1, matrix2, columnsCount, rowsCount);
        }

        /// <summary>
        /// Умножение матриц
        /// </summary>
        /// <param name="random"></param>
        public static void ShowMatrixesMultiplication(Random random)
        {
            int rowCount1 =  GetInputNumber("количество строк первой матрицы");
            int columnsCount2 = GetInputNumber("количество столбцов второй матрицы");
            int commonValue = GetInputNumber("Количество столбцов в первой матрице = количество строк во второй матрице");

            if (rowCount1 <= 0 ||
                columnsCount2 <= 0 ||
                commonValue <= 0)
            {
                Console.WriteLine("Размерности матриц должны быть положительными");
                return;
            }

            var matrix1 = GenerateMatrix(rowCount1, 
                commonValue, "Первая матрица", random);
            var matrix2 = GenerateMatrix(commonValue,
                columnsCount2, "Вторая матрица", random);

            var matrix = new int[rowCount1, columnsCount2];
            
            // Произведение матриц
            for (int i = 0; i < rowCount1; ++i)
            {
                for (int j = 0; j < columnsCount2; ++j)
                {
                    for (int k = 0; k < commonValue; ++k)
                        matrix[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }

            Console.WriteLine("Произведение матриц:");
            var buf = new int[columnsCount2];
            for (int i = 0; i < rowCount1; ++i)
            {
                for (int j = 0; j < columnsCount2; ++j)
                {
                    buf[j] = matrix[i, j];
                }
                Console.WriteLine(string.Join("\t", buf));
            }

            Console.ReadKey();
        }
    }
}
