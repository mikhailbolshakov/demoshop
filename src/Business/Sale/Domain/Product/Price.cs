using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Sale.Domain.Products
{
    public class Price
    {
        /// <summary>
        /// from this date the price is valid
        /// </summary>
        public DateTime ValidityStartDate { get; set; }

        /// <summary>
        /// until this date the price is valid
        /// </summary>
        public DateTime ValidityEndDate { get; set; }

        /// <summary>
        /// price amount
        /// </summary>
        public decimal Amount { get; set; }

    }
}
