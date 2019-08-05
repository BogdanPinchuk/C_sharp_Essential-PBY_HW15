#define hardcode    // хардкод
//#define hand        // ручний ввід

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp1
{
    class Program
    {
        static void Main()
        {
            // Join Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // створення екземпляра робітників
            Worker[] workers = new Worker[5];

            // дані для хардкоду
            #region хардкод
            string[] names = new string[5]
                {
                "Пінчук Б.Ю.",
                "Кучеренко В.",
                "Мілевський В.",
                "Шоломницький О.О.",
                "Дідух Я."
                };

            string[] positions = new string[5]
            {
                "Інженер-програміст",
                "Зам-директор",
                "Інженер-конструктор",
                "Водій/студент",
                "IT-Application"
            };

            string[] years = new string[5]
            {
                "27.06.2016",
                "01.05.2015",
                "01.09.2014",
                "01.07.2019",
                "забув"
            };
            #endregion

            #region Введення даних
            for (int i = 0; i < workers.Length; i++)
            {
                // введення даних
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nВведіть ПІБ: ");
                Console.ForegroundColor = ConsoleColor.Gray;
#if hand
                workers[i].FullName = Console.ReadLine();
#endif
#if hardcode
                workers[i].FullName = names[i];
                Console.Write(workers[i].FullName);
#endif

                // введення даних
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nВведіть посаду: ");
                Console.ForegroundColor = ConsoleColor.Gray;
#if hand
                workers[i].Position = Console.ReadLine();
#endif
#if hardcode
                workers[i].Position = positions[i];
                Console.Write(workers[i].Position);
#endif

                // введення даних
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nВведіть рік прийняття на роботу: ");
                Console.ForegroundColor = ConsoleColor.Gray;
                string s = string.Empty;
#if hand
                s = Console.ReadLine();
#endif
#if hardcode
                s = years[i];
#endif
                // аналіз
                workers[i].Year = ExceptionMethod(s);
                Console.Write(workers[i].Year);

                Console.WriteLine();
            } 
            #endregion

            // Сортування
            workers = workers.OrderBy(t => t.FullName).ToArray();

            // виведення
            Console.WriteLine("\n\tРезультат виведення після сортування:");
            for (int i = 0; i < workers.Length; i++)
            {
                var s = new StringBuilder()
                    .Append($"\n\t| Name - {workers[i].FullName}, ")
                    .Append($"\n\t| Positions - {workers[i].Position},")
                    .Append($"\n\t| Year - {workers[i].Year.Year}.\n");

                Console.WriteLine(s.ToString());
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\tТі хто пропрацював більше 2-х років:");
            Console.ResetColor();
            for (int i = 0; i < workers.Length; i++)
            {
                if (DateTime.Now.Year - workers[i].Year.Year > 2)
                {
                    var s = new StringBuilder()
                        .Append($"\n\t| Name - {workers[i].FullName}, ")
                        .Append($"\n\t| Positions - {workers[i].Position},")
                        .Append($"\n\t| Year - {workers[i].Year.Year}.\n");

                    Console.WriteLine(s.ToString());
                }
            }

            // repeat
            DoExitOrRepeat();
        }

        /// <summary>
        /// Аналіз дати
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static DateTime ExceptionMethod(string s)
        {
            // намагання переворити рядок в час
            try
            {
                return DateTime.Parse(s);
            }
            catch (FormatException e)
            {
                Console.Write(e.Message);
                return DateTime.Now;
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
