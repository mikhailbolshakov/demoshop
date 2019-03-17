using DemoShop.Libs.CommonTypes.Paging;
using DemoShop.Sale.API.Product.shared.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.Sale.API.Product.shared.Service
{
    public interface IProductSharedService
    {
        /// <summary>
        /// retrieves list of products by criteria in paged manner
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IEnumerable<ProductShortInfo>> GetProductsAsync(PagedRequest<GetProductsRequest> request);

        /// <summary>
        /// get product full info
        /// </summary>
        /// <returns>product full info</returns>
        Task<ProductFullInfo> GetProductAsync(Guid productId);

        /// <summary>
        /// add new product
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CommonProductResponse> AddProductAsync(AddProductRequest request);

        /// <summary>
        /// upload product images
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="images"></param>
        /// <returns></returns>
        Task<object> UploadImagesAsync(Guid productId, byte[] images);

        /// <summary>
        /// updates product's price
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="price"></param>
        Task<CommonProductResponse> UpdatePriceAsync(Guid productId, Price price);

    }
}
