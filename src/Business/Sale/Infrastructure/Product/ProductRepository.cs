using System;
using System.Collections.Generic;
using System.Text;
using DemoShop.Libs.Persistence.DbFactory;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;
using DemoShop.Security.Infrastructure.Consts;
using DemoShop.Sale.Domain.Products.Repository;
using DemoShop.Sale.Domain.Products;

namespace DemoShop.Sale.Infrastructure.Products
{
    public class ProductRepository : IProductRepository
    {

        #region private fields

        private readonly DbFactory _dbFactory;

        #endregion

        #region ctor

        public ProductRepository(DbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        #endregion

        #region IProductRepository

        public async Task<Product> AddAsync(Product product)
        {
            using (var db = _dbFactory.CreateDatabase())
            {
                var bson = ProductRepositoryMapper.Map(product);

                var productCol = db.GetCollection<ProductBson>(DBCollectionConsts.PRODUCT);

                await Task.Run(() => productCol.Insert(bson));
                await Task.Run(() => productCol.EnsureIndex(x => x.CategoryCode));
                await Task.Run(() => productCol.EnsureIndex(x => x.ProductCode));

                return ProductRepositoryMapper.Map(bson);
            }
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            using (var db = _dbFactory.CreateDatabase())
            {
                var productCol = db.GetCollection<ProductBson>(DBCollectionConsts.PRODUCT);
                var bson = await Task.Run(() => productCol.Find(a => a.ProductId == id).SingleOrDefault());
                return ProductRepositoryMapper.Map(bson);
            }

        }

        public async Task<Product> UpdateAsync(Product product)
        {
            using (var db = _dbFactory.CreateDatabase())
            {
                var bson = ProductRepositoryMapper.Map(product);

                var productCol = db.GetCollection<ProductBson>(DBCollectionConsts.PRODUCT);
                await Task.Run(() => productCol.Update(bson));
                return ProductRepositoryMapper.Map(bson);

            }
        }

        #endregion
    }
}
