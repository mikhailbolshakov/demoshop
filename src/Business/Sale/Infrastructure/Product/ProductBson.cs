using DemoShop.Sale.Infrastructure.Products;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Sale.Infrastructure.Products
{
    public class ProductBson
    {
        [BsonId]
        public Guid? ProductId { get; set; }

        public string ProductCode { get; set; }

        public string CategoryCode { get; set; }

        public string Details { get; set; }

        public string ShortDescription { get; set; }

        public string FullDescription { get; set; }

        public List<PriceBson> Prices { get; set; }
    }
}
