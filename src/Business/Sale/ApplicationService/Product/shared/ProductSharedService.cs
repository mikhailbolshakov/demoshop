using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DemoShop.Libs.CommonTypes.Paging;
using DemoShop.Sale.API.Product.shared.Dto;
using DemoShop.Sale.API.Product.shared.Service;
using DemoShop.Sale.Domain.Products.Service;

namespace DemoShop.Sale.ApplicationService.Products.shared
{
    public class ProductSharedService : IProductSharedService
    {

        #region private fields

        private readonly IProductService _productService;


        #endregion 

        #region ctor

        public ProductSharedService(IProductService productService)
        {
            _productService = productService;
        }

        #endregion

        #region private methods

        #endregion

        #region IProductSharedService

        public async Task<CommonProductResponse> AddProductAsync(AddProductRequest request)
        {
            var domainProduct = ProductSharedServiceMapper.Map(request); 
            domainProduct = await _productService.AddAsync(domainProduct);
            return new CommonProductResponse() { ProductId = domainProduct.ProductId.Value };
        }

        public async Task<ProductFullInfo> GetProductAsync(Guid productId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductShortInfo>> GetProductsAsync(PagedRequest<GetProductsRequest> request)
        {
            throw new NotImplementedException();
        }

        public async Task<CommonProductResponse> UpdatePriceAsync(Guid productId, Price price)
        {
            var domainPrice = ProductSharedServiceMapper.Map(price);
            var domainProduct = await _productService.UpdatePriceAsync(productId, domainPrice);
            return new CommonProductResponse() { ProductId = domainProduct.ProductId.Value };
        }

        public async Task<object> UploadImagesAsync(Guid productId, byte[] images)
        {
            throw new NotImplementedException();
        }




        #endregion
    }
}
