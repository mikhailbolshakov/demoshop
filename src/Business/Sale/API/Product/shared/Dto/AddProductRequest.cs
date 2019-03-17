using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Sale.API.Product.shared.Dto
{

    public class AddProductRequest
    {
        /// <summary>
        /// product code
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// product category
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
        /// product details 
        /// set of details are specified for each product type
        /// </summary>
        public JObject Details { get; set; }
    }
}
