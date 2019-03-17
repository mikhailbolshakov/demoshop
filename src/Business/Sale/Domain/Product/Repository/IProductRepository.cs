using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.Sale.Domain.Products.Repository
{
    public interface IProductRepository
    {
        /// <summary>
        /// adds a new product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task<Product> AddAsync(Product product);

        /// <summary>
        /// adds a new product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task<Product> UpdateAsync(Product product);

        /// <summary>
        /// finds a product by the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Product> GetProductByIdAsync(Guid id);
    }
}
