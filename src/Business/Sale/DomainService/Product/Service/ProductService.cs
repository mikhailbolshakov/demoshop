using DemoShop.Libs.WebApi.ExceptionHandling.CustomExceptions;
using DemoShop.Sale.Domain.Products;
using DemoShop.Sale.Domain.Products.Repository;
using DemoShop.Sale.Domain.Products.Service;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace DemoShop.Sale.DomainService.Products.Service
{
    public class ProductService : IProductService
    {

        #region private fields

        private readonly IProductRepository _repository;

        #endregion 

        #region ctor

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }


        #endregion

        #region private method

        private Product EnrichNewProduct(Product product)
        {
            // setup an Id
            product.ProductId = Guid.NewGuid();
            
            // set empty details if not specified
            product.Details = product.Details ?? JObject.Parse("{}");

            return product;
        }

        private void ValidateProduct(Product product)
        {

        }

        private void ValidateUpdatePrice(Product product, Price newPrice)
        {

        }

        #endregion

        #region IProductService

        public async Task<Product> AddAsync(Product incomingProduct)
        {
            // enrich a new object
            var product = EnrichNewProduct(incomingProduct);

            // validate product
            ValidateProduct(product);

            // persist product
            product = await _repository.AddAsync(product);

            // TODO: Domain event

            return product;            
        }

        public async Task<Product> UpdatePriceAsync(Guid productId, Price price)
        {
            var product = await _repository.GetProductByIdAsync(productId);

            if (product == null)
                throw new DsNotFoundException($"Can not update price. Product isn't found by id {productId}");

            ValidateUpdatePrice(product, price);

            // add price
            // TODO: interval logic
            product.Prices.Add(price);

            // persist changes
            product = await _repository.UpdateAsync(product);

            return product;

        }

        #endregion
    }
}
