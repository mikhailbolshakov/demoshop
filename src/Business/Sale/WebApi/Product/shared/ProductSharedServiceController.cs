using DemoShop.Libs.CommonTypes.Paging;
using DemoShop.Libs.WebApi;
using DemoShop.Sale.API.Product.shared.Dto;
using DemoShop.Sale.API.Product.shared.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoShop.Sale.WebApi.Product.shared
{
    [ApiController, Authorize, Route("api/sale/shared/product")]
    public class ProductSharedServiceController : DsControllerBase
    {

        private readonly IProductSharedService _service;

        public ProductSharedServiceController(IProductSharedService service)
        {
            _service = service;
        }
        
        [HttpGet("get-products"), AllowAnonymous]
        public async Task<ActionResult<List<ProductShortInfo>>> GetProductsAsync([FromQuery] GetProductsRequest request, int pageSize, int pageNumber)
        {
            var apiRq = new PagedRequest<GetProductsRequest>(request);
            return (await _service.GetProductsAsync(apiRq)).ToList();
        }

        [HttpPost("add-product/{categoryCode}"), Authorize("Admin")]
        public async Task<ActionResult<CommonProductResponse>> AddProductAsync(string categoryCode, [FromBody] dynamic requestJSON)
        {
            // we take a request as a raw JSON 
            // in order to correctly handle different types of requests depending on product category
            var addProductRq = new AddProductRequest()
            {
                ProductCode = requestJSON.ProductCode,
                CategoryCode = categoryCode,
                ShortDescription = requestJSON.ShortDescription,
                FullDescription = requestJSON.FullDescription,
                Details = requestJSON.Details
            };

            return await _service.AddProductAsync(addProductRq);
        }

        [HttpPost("update-price/{productId}"), Authorize("Admin")]
        public async Task<ActionResult<CommonProductResponse>> UpdatePriceAsync(Guid productId, Price price)
        {
            return await _service.UpdatePriceAsync(productId, price);
        }

    }
}
