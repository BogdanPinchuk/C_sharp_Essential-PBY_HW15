using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp1
{
    /// <summary>
    /// Працівник
    /// </summary>
    struct Worker
    {
        /// <summary>
        /// Прізвище та ініціали
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Посада
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// Рік прийняття на роботу
        /// </summary>
        public DateTime Year { get; set; }
    }
}
