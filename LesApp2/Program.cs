#define hardcode    // хардкод
//#define hand        // ручний ввід

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp2
{
    class Program
    {
        static void Main()
        {
            // Join Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // створення екземпляра продуктів (2 мало для сортування)
            Price[] prices = new Price[5];

            // дані для хардкоду
            #region хардкод
            string[] names = new string[5]
                {
                "Шашлик",
                "Сік",
                "Овочі",
                "Фрукти",
                "Соуси"
                };

            string[] shops = new string[5]
            {
                "Ашан",
                "Сільпо",
                "АТБ",
                "Novus",
                "Varus"
            };

            string[] costs = new string[5]
            {
                "350",
                "50",
                "150",
                "100",
                "75"
            };
            #endregion

            #region Введення даних
            for (int i = 0; i < prices.Length; i++)
            {
                // введення даних
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nВведіть назву продукту: ");
                Console.ForegroundColor = ConsoleColor.Gray;
#if hand
                prices[i].ProductName = Console.ReadLine();
#endif
#if hardcode
                prices[i].ProductName = names[i];
                Console.Write(prices[i].ProductName);
#endif

                // введення даних
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nВведіть назву магазину: ");
                Console.ForegroundColor = ConsoleColor.Gray;
#if hand
                prices[i].ShopName = Console.ReadLine();
#endif
#if hardcode
                prices[i].ShopName = shops[i];
                Console.Write(prices[i].ShopName);
#endif

                // введення даних
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nВведіть ціну продукту: ");
                Console.ForegroundColor = ConsoleColor.Gray;
                string s = string.Empty;
#if hand
                s = Console.ReadLine();
#endif
#if hardcode
                s = costs[i];
#endif
                // аналіз
                prices[i].Cost = ExceptionMethod(s);
                Console.Write(prices[i].Cost);

                Console.WriteLine();
            }
            #endregion

            // Сортування по назвах магазинів
            #region Сортування
            prices = prices.OrderBy(t => t.ShopName).ToArray();

            // виведення
            Console.WriteLine("\n\tРезультат виведення після сортування:");
            for (int i = 0; i < prices.Length; i++)
            {
                var s = new StringBuilder()
                    .Append($"\n\t| Name - {prices[i].ProductName}, ")
                    .Append($"\n\t| Shop - {prices[i].ShopName},")
                    .Append($"\n\t| Cost - {prices[i].Cost} грн.\n");

                Console.WriteLine(s.ToString());
            }
            #endregion

            // Запит створення запиту
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nВведіть назву продукту для пошуку: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            string productName = string.Empty;
#if hand
            productName = Console.ReadLine();
#endif
#if hardcode
            //productName = "Шашлик";
            productName = "Ковбаса";
            Console.Write(productName);
#endif
            try
            {
                // чи щось найдено
                bool find = false;

                for (int i = 0; i < prices.Length; i++)
                {
                    if (productName.ToLower() == prices[i].ProductName.ToLower())
                    {
                        Console.WriteLine("\n\n\tНайдений продукт:");
                        var s = new StringBuilder()
                            .Append($"\n\t| Name - {prices[i].ProductName}, ")
                            .Append($"\n\t| Shop - {prices[i].ShopName},")
                            .Append($"\n\t| Year - {prices[i].Cost} грн.\n");

                        Console.WriteLine(s.ToString());

                        find = true;
                    }
                }

                if (!find)
                {
                    throw new Exception("\n\n\tТакий продукт відсутній");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // repeat
            DoExitOrRepeat();
        }

        /// <summary>
        /// Аналіз ціни
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static int ExceptionMethod(string s)
        {
            // намагання переворити рядок в час
            try
            {
                return int.Parse(s);
            }
            catch (FormatException e)
            {
                Console.Write(e.Message);
                return default(int);
            }
        }

        /// <summary>
        /// Метод виходу або повторення методу Main()
        /// </summary>
        static void DoExitOrRepeat()
        {
            Console.WriteLine("\n\nСпробувати ще раз: [т, н]");
            Console.Write("\t");
            var button = Console.ReadKey(true);

            if ((button.KeyChar.ToString().ToLower() == "т") ||
                (button.KeyChar.ToString().ToLower() == "n")) // можливо забули переключити розкладку клавіатури
            {
                Console.Clear();
                Main();
                // без використання рекурсії
                //Process.Start(Assembly.GetExecutingAssembly().Location);
                //Environment.Exit(0);
            }
            else
            {
                // закриває консоль
                Environment.Exit(0);
            }
        }
    }
}
