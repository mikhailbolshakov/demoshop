using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Sale.Infrastructure.Products
{

    public class PriceBson
    {
        public DateTime ValidityStartDate { get; set; }

        public DateTime ValidityEndDate { get; set; }

        public decimal Amount { get; set; }

    }
}
