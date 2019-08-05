using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0
{
    /// <summary>
    /// Калькулятор
    /// </summary>
    static class Calculator
    {
        /// <summary>
        /// Сума
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static void Add(double a, double b) => Console.WriteLine("\n\t" + a + " + " + b + " = " + (a + b));
        /// <summary>
        /// Різниця
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static void Sub(double a, double b) => Console.WriteLine("\n\t" + a + " - " + b + " = " + (a - b));
        /// <summary>
        /// Добуток
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static void Mul(double a, double b) => Console.WriteLine("\n\t" + a + " * " + b + " = " + (a * b));
        /// <summary>
        /// Частка
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static void Div(double a, double b)
        {
            try
            {
                if (b == 0)
                {
                    throw new DivideByZeroException();
                }
                else
                {
                    // може рахувати для double, але не для int
                    Console.WriteLine("\n\t" + a + " / " + b + " = " + (a / b));
                }
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);

                Console.WriteLine("\n\tАле все таки, правильна відповідь:");
                if (a > 0)
                {
                    Console.WriteLine("\n\t" + a + " / " + b + " = " + double.PositiveInfinity);
                }
                else if (a < 0)
                {
                    Console.WriteLine("\n\t" + a + " / " + b + " = " + double.NegativeInfinity);
                }
                else if (a == 0)
                {
                    Console.WriteLine("\n\t" + a + " / " + b + " = " + double.NaN);
                }
            }
        }

    }
}
