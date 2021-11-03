using System;

namespace Homework_Theme_04.Helpers
{
    public static class PascalTriangleHelper
    {
        public static void MakePascalTriangle()
        {
            Console.Write("Количество строк треугольника Паскаля: ");
            int rowsCount = int.Parse(Console.ReadLine());
            if (rowsCount <= 0 && rowsCount >=25)
            {
                Console.WriteLine($"Количество строк не в интервале (0; 25)");
                return;
            }

            var pascalTriangle = new int[rowsCount][];

            // Цикл по строкам треугольника
            for (int i = 0; i < rowsCount; ++i)
            {
                // Выделяем память под массив на текущей строке
                int currentMasLength = i + 1;
                pascalTriangle[i] = new int[currentMasLength];

                for (int j = 0; j < currentMasLength; ++j)
                {
                    if (j == 0 || j == currentMasLength - 1)
                    {
                        pascalTriangle[i][j] = 1;
                        continue;
                    }

                    // Пропускаем расчет в первых двух строках
                    if (i < 2)
                        continue;

                    // Промежуточные числа не равные 1 считаем на основе
                    // чисел из верхней строки
                    pascalTriangle[i][j] = pascalTriangle[i - 1][j - 1] + 
                                           pascalTriangle[i - 1][j];
                }
            }

            Print(pascalTriangle, rowsCount);
        }

        /// <summary>
        /// Печать  треугольника Паскаля
        /// </summary>
        /// <param name="pascalTriangle">Треугольник Паскаля</param>
        /// <param name="rowsCount">Количество строк</param>
        private static void Print(int[][] pascalTriangle, int rowsCount)
        {
            for (int i = 0; i < rowsCount; ++i)
            {
                int colsCount = pascalTriangle[i].GetLength(0);
                var buf = new int[colsCount];
                for (int j = 0; j < colsCount; ++j)
                    buf[j] = pascalTriangle[i][j];
                Console.WriteLine(string.Join("\t", buf));
            }
        }
    }
}
