using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Sale.API.Product.shared.Dto
{
    public class ProductShortInfo
    {
        /// <summary>
        /// Id of product
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// product unique code
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// short description 
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// the valid price
        /// </summary>
        public Price Price { get; set; }
    }
}
