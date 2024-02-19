using AutoMapper;
using Business.Interfaces;
using Business.Models.Brands;
using Business.Models.Pagination;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.BrandsDto;
using WebApi.Models.PaginationsDto;
using WebApi.Utilities;

namespace WebApi.Controllers
{
    public class BrandController : CustomControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBrandService _brandService;
        private readonly ILogger<BrandController> _logger;

        public BrandController(IMapper mapper, IBrandService brandService, ILogger<BrandController> logger)
        {
            _mapper = mapper;
            _brandService = brandService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(BrandDto model, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Post, Create brand", nameof(BrandController), nameof(CreateBrand));

            var mappedBrand = _mapper.Map<CreateBrandModel>(model);

            await _brandService.CreateBrandAsync(mappedBrand, ct);

            _logger.LogInformation("{controller}.{method} - Post, Create Brand, Result - Ok", nameof(BrandController), nameof(CreateBrand));

            return Ok("Brand was added");
        }

        [HttpGet("paged")]
        public async Task<ActionResult<PagedBrandsDto>> GetBrands([FromQuery] PaginationDto pagination, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Get paged brands method in controller", nameof(BrandController), nameof(GetBrands));

            var mappedPagination = _mapper.Map<PaginationModel>(pagination);
            var result = await _brandService.GetBrandsPagedAsync(mappedPagination, ct);

            var mappedResult = _mapper.Map<PagedBrandsDto>(result);
            _logger.LogInformation("{controller}.{method} - Get paged brands method in controller, Result - Ok", nameof(BrandController), nameof(GetBrands));
            return Ok(mappedResult);
        }

        [HttpPut]
        public async Task<ActionResult<BrandDto>> UpdateBrand([FromQuery] UpdateBrandDto model, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Post, Update brand", nameof(BrandController), nameof(UpdateBrand));

            var mappedModel = _mapper.Map<UpdateBrandModel>(model);

            var result = await _brandService.UpdateBrandAsync(mappedModel, ct);

            var mappedResult = _mapper.Map<BrandDto>(result);

            _logger.LogInformation("{controller}.{method} - Post, Update brand, Result - Ok", nameof(BrandController), nameof(UpdateBrand));
            return Ok(mappedResult);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBrand(Guid id, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Delete, delete brand", nameof(BrandController), nameof(DeleteBrand));

            await _brandService.DeleteBrandByIdAsync(id, ct);

            _logger.LogInformation("{controller}.{method} - Delete, Update brand, Result - Ok", nameof(BrandController), nameof(DeleteBrand));
            return Ok("Brand was deleted");
        }
    }
}
