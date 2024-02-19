using AutoMapper;
using Business.Interfaces;
using Business.Models.Filter;
using Business.Models.Pagination;
using Business.Models.Products;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.FiltersDto;
using WebApi.Models.PaginationsDto;
using WebApi.Models.ProductsDto.Request;
using WebApi.Models.ProductsDto.Response;
using WebApi.Utilities;

namespace WebApi.Controllers
{
    public class ProductController : CustomControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, IMapper mapper, ILogger<ProductController> logger)
        {
            _productService = productService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost("add")]
        public async Task<ActionResult<ProductDto>> CreateProduct([FromForm]AddProductDto model, CancellationToken ct)
        {
            var mappedModel = _mapper.Map<AddProductModel>(model);
            var product = await _productService.AddProductAsync(mappedModel, ct);
            var mappedProduct = _mapper.Map<ProductDto>(product);
            return Ok(mappedProduct);
        }

        /// <summary>
        /// Method in controller for get product with id from db
        /// </summary>
        /// <param name="productId">guid if dor search in bd</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>returned model with data from db or problem</returns>
        [HttpGet("by-id")]
        public async Task<ActionResult<ProductDto>> GetProductByIdAsync(Guid productId, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - get product method with id in controller, Task started", 
                nameof(ProductController), nameof(GetProductByIdAsync));
            var product = await _productService.GetProductByIdAsync(productId, ct);
            var mappedProduct = _mapper.Map<ProductDto>(product);
            _logger.LogInformation("{controller}.{method} - get product method with id, Result - Ok, Task ended", 
                nameof(ProductController), nameof(GetProductByIdAsync));
            return Ok(mappedProduct);
        }

        [HttpGet("by-category-id")]
        public async Task<ActionResult<PagedProductDto>> GetProductByCategoryAsync(int categoryId, [FromQuery]PaginationDto model, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Get paged products by category, Task started,", nameof(ProductController), nameof(GetProductByCategoryAsync));

            var mappedModel = _mapper.Map<PaginationModel>(model);
            var result = await _productService.GetProductsByCategoryAsync(categoryId, mappedModel, ct);

            var mappedResult = _mapper.Map<PagedProductDto>(result);
            _logger.LogInformation("{controller}.{method} - Get paged products by category, Result - Ok, Task ended", nameof(ProductController), nameof(GetProductByCategoryAsync));
            return Ok(mappedResult);
        }

        [HttpGet("filtered")]
        public async Task<ActionResult<PagedProductDto>> GetFilteredProductAsync([FromQuery]ProductFilterDto filter, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Get paged products by query filter, Task started,", nameof(ProductController), nameof(GetFilteredProductAsync));

            var mappedFilter = _mapper.Map<FilterModel>(filter);
            var result = await _productService.GetFilteredProductsAsync(mappedFilter, ct);

            var mappedResult = _mapper.Map<PagedProductDto>(result);
            _logger.LogInformation("{controller}.{method} - Get paged products by query filter, Result - Ok, Task ended", nameof(ProductController), nameof(GetFilteredProductAsync));
            return Ok(mappedResult);
        }

        [HttpPut("update")]
        public async Task<ActionResult<ProductModel>> UpdateProductAsync([FromForm] UpdateProductDto model, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Update product (FromForm), Task started,", nameof(ProductController), 
                nameof(UpdateProductAsync));

            var mappedFilter = _mapper.Map<UpdateProductModel>(model);
            var product = await _productService.UpdateProductAsync(mappedFilter, ct);

            var mappedProduct = _mapper.Map<ProductDto>(product);
            _logger.LogInformation("{controller}.{method} - Update product (FromForm), Result - Ok, Task ended", 
                nameof(ProductController), nameof(UpdateProductAsync));
            return Ok(mappedProduct);
        }

        [HttpDelete("by-id")]
        public async Task<IActionResult> DeleteProductAsync(Guid productId, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Delete product by id, Task started,", nameof(ProductController),
                nameof(DeleteProductAsync));
            
            await _productService.DeleteProductByIdAsync(productId, ct);

            _logger.LogInformation("{controller}.{method} - Delete product by id, Result - Ok, Task ended",
                nameof(ProductController), nameof(DeleteProductAsync));
            return Ok($"Product {productId} was deleted");
        }
    }
}
