using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework_Theme_04.Helpers
{
    public static class TaskHelper1
    {
        private static void InputIncomesOutgoArrays(int[] incomes, int[] outgo, int monthCount)
        {
            // Исходные данные
            Console.WriteLine($"Введите доход и расход в тыс. руб. для {monthCount} месяцев через пробел:");
            for (int i = 0; i < monthCount; ++i)
            {
                // Доход и расход в текущем месяце
                Console.Write($"Месяц № {i + 1}: ");

                string[] strItems = Console.ReadLine().Split(' ');
                incomes[i] = int.Parse(strItems[0]);
                outgo[i] = int.Parse(strItems[1]);
            }
        }

        private static int GetPositiveProfitMonthCount(int[] incomes, int[] outgo, int[] profits, int monthCount)
        {
            // Вывод результата
            Console.WriteLine($"Месяц\tДоход, тыс. руб.\tРасход, тыс. руб.\tПрибыль, тыс. руб.");

            int positiveProfitMonthCount = 0;
            for (int i = 0; i < monthCount; i++)
            {
                // Расчет результата для месяца i
                profits[i] = incomes[i] - outgo[i];

                // Подсчет месяцев с положительной прибылью
                if (profits[i] > 0)
                    ++positiveProfitMonthCount;

                Console.WriteLine($"{i + 1,5}\t{incomes[i],16}\t{outgo[i],17}\t{profits[i],18}");
            }

            return positiveProfitMonthCount;
        }

        private static int[] GetLowProfitMonths(int[] profits)
        {
            // Сортировка прибыли
            var lowProfits = profits
                .Where(p => p > 0)
                .Distinct()
                .OrderBy(p => p)
                .Take(3)
                .ToList();

            // Месяцы с худшей прибылью
            var monthNumbers = new List<int>();
            for (int i = 0; i < profits.Length; i++)
            {
                if (lowProfits.Contains(profits[i]))
                    monthNumbers.Add(i + 1);
            }

            return monthNumbers.ToArray();
        }

        public static void MakeTask1()
        {
            const int monthCount = 12;

            var incomes = new int[monthCount];
            var outgo = new int[monthCount];
            InputIncomesOutgoArrays(incomes, outgo, monthCount);

            var profits = new int[monthCount];
            int positiveProfitMonthCount = GetPositiveProfitMonthCount(incomes, outgo, profits, monthCount);

            int[] months = GetLowProfitMonths(profits);

            Console.WriteLine($"Худшая прибыль в месяцах: {string.Join(",", months)}");
            Console.WriteLine($"Месяцев с положительной прибылью: {positiveProfitMonthCount}");

            Console.ReadKey();
        }
    }
}
