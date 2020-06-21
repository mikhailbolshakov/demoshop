using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Sale.Domain.Products
{
    public class Product 
    {
        /// <summary>
        /// Id of product
        /// </summary>
        public Guid? ProductId { get; set; }

        /// <summary>
        /// product code
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// code of a category a product belongs to
        /// a product might have different attributes and logic depending on product's category
        /// </summary>
        public string CategoryCode { get; set; }

        /// <summary>
        /// short description
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// full decsription
        /// </summary>
        public string FullDescription { get; set; }

        /// <summary>
        /// product details specified for the particular category
        /// </summary>
        public JObject Details { get; set; }

        /// <summary>
        /// product's prices
        /// </summary>
        public List<Price> Prices { get; set; }
    }
}
