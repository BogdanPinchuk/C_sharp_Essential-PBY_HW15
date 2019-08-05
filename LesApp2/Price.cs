using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp2
{
    /// <summary>
    /// Ціна
    /// </summary>
    struct Price
    {
        /// <summary>
        /// Назва товару
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// Назва магазиру
        /// </summary>
        public string ShopName { get; set; }
        /// <summary>
        /// Ціна товару
        /// </summary>
        public int Cost { get; set; }
    }
}
