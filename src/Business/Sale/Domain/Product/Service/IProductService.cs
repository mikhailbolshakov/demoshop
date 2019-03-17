using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.Sale.Domain.Products.Service
{
    public interface IProductService
    {
        /// <summary>
        /// add a new product
        /// </summary>
        /// <param name="product">input object</param>
        /// <returns>modified product object</returns>
        Task<Product> AddAsync(Product product);

        /// <summary>
        /// update price for the product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        Task<Product> UpdatePriceAsync(Guid productId, Price price);
    }
}
