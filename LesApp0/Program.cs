using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0
{
    class Program
    {
        /// <summary>
        /// Делегат арифметичної операції
        /// </summary>
        delegate void DelAO(double a, double b);

        static void Main()
        {
            // Join Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // змінні для розрахунку
            double a, b;
            // операція для виконання
            string oper;
            // доступ до наступної операції
            bool error = true;
            // делегат операції
            DelAO delAO = null;

            Console.ForegroundColor = ConsoleColor.Green;
            // введення
            Console.Write("\n\tКалькулятор:\n");
            Console.ForegroundColor = ConsoleColor.Gray;

            // введення даних
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nВведіть число: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("a = ");
            error = double.TryParse(Console.ReadLine().Replace(".", ","), out a);
            AnaliseOfInputNumber(error);

            // введення операції
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Введіть операцію: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            oper = Console.ReadLine();
            error = "+-*/".Contains(oper);
            //error = oper.Contains("+-*/");
            AnaliseOfInputNumber(error);
            // присвоєння операції
            delAO = ChangeAO(oper);

            // введення даних
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Введіть число: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("b = ");
            error = double.TryParse(Console.ReadLine().Replace(".", ","), out b);
            AnaliseOfInputNumber(error);

            // виведення даних
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"\n\tРезультат: \n");
            Console.ForegroundColor = ConsoleColor.Gray;
            delAO(a, b);

            // repeat
            DoExitOrRepeat();
        }

        static DelAO ChangeAO(string oper)
        {
            switch (oper)
            {
                case "+":
                    return Calculator.Add;
                case "-":
                    return Calculator.Sub;
                case "*":
                    return Calculator.Mul;
                case "/":
                    return Calculator.Div;
                default:
                    return null;
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

        /// <summary>
        /// Умова коли невірно введені дані
        /// </summary>
        /// <param name="res"></param>
        static void AnaliseOfInputNumber(bool res)
        {
            if (!res)
            {
                Console.WriteLine("\nНевірно введені дані!");
                DoExitOrRepeat();
            }
        }
    }
}
