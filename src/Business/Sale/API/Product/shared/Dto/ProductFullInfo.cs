using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Sale.API.Product.shared.Dto
{
    public class ProductFullInfo : ProductShortInfo
    {

        /// <summary>
        /// full description 
        /// </summary>
        public string FullDescription { get; set; }

        /// <summary>
        /// product image
        /// </summary>
        public byte[] Image { get; set; }
    }
}
