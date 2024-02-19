using AutoMapper;
using Business.Interfaces;
using Business.Models.Pagination;
using Business.Models.Providers;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.PaginationsDto;
using WebApi.Models.ProvidersDto;
using WebApi.Utilities;

namespace WebApi.Controllers
{
    public class ProviderController : CustomControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProviderService _providerService;
        private readonly ILogger<ProviderController> _logger;

        public ProviderController(IMapper mapper, ILogger<ProviderController> logger, IProviderService providerService)
        {
            _mapper = mapper;
            _logger = logger;
            _providerService = providerService;
        }

        // Todo: return full provider with contact
        [HttpPost("add")]
        public async Task<IActionResult> CreateProviderAsync(CreateProviderDto model, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Post, Create Provider", nameof(ProviderController), nameof(CreateProviderAsync));

            var mappedModel = _mapper.Map<CreateProviderModel>(model);

            await _providerService.CreateProviderAsync(mappedModel, ct);

            _logger.LogInformation("{controller}.{method} - Post, Create Provider, Result - Ok", nameof(ProviderController), nameof(CreateProviderAsync));
            return Ok("Provider was added");
        }

        [HttpGet("by-Id")]
        public async Task<ActionResult<ProviderDto>> GetProviderByIdAsync(Guid id, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Get, Get Provider by Id, Task Started", nameof(ProviderController), nameof(GetProviderByIdAsync));

            var provider = await _providerService.GetProviderByIdAsync(id, ct);

            var mappedProvider = _mapper.Map<ProviderDto>(provider);

            _logger.LogInformation("{controller}.{method} - Get, Get Provider by Id, Result - Ok, Task Ended", 
                nameof(ProviderController), nameof(GetProviderByIdAsync));

            return Ok(mappedProvider);
        }

        [HttpGet("by-productId")]
        public async Task<ActionResult<ProviderDto>> GetProviderByProductIdAsync(Guid productId, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Get, Get Provider by product Id, Task Started", nameof(ProviderController), nameof(GetProviderByProductIdAsync));

            var provider = await _providerService.GetProviderByProductAsync(productId, ct);

            var mappedProvider = _mapper.Map<ProviderDto>(provider);

            _logger.LogInformation("{controller}.{method} - Get, Get Provider by Id, Result - Ok, Task Ended",
                nameof(ProviderController), nameof(GetProviderByProductIdAsync));

            return Ok(mappedProvider);
        }

        [HttpGet("all-providers")]
        public async Task<ActionResult<PagedProviderDto>> GetAllProvidersAsync([FromQuery]PaginationDto pagination, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Get, Get all paginated providers, Task Started", nameof(ProviderController), nameof(GetAllProvidersAsync));

            var mappedPagination = _mapper.Map<PaginationModel>(pagination);
            var provider = await _providerService.GetAllCompanyProvidersAsync(mappedPagination, ct);

            var mappedProviders = _mapper.Map<PagedProviderDto>(provider);

            _logger.LogInformation("{controller}.{method} - Get, Get all paginated providers, Result - Ok, Task Ended",
                nameof(ProviderController), nameof(GetAllProvidersAsync));

            return Ok(mappedProviders);
        }

        [HttpPut("update")]
        public async Task<ActionResult<ProviderDto>> UpdateProviderAsync([FromBody]UpdateProviderDto model, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Put, Update Provider, Task started", nameof(ProviderController), nameof(UpdateProviderAsync));

            var mappedModel = _mapper.Map<UpdateProviderModel>(model);

            var result = await _providerService.UpdateProviderAsync(mappedModel, ct);

            var mappedResult = _mapper.Map<ProviderDto>(result);

            _logger.LogInformation("{controller}.{method} - Put, Update Provider, Result - Ok, Task Ended", nameof(ProviderController), nameof(UpdateProviderAsync));
            return Ok(mappedResult);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteProviderByIdAsync(Guid id, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Delete, Delete provider by Id, Task started",
                nameof(ProviderController), nameof(UpdateProviderAsync));

            await _providerService.DeleteProviderAsync(id, ct);

            _logger.LogInformation("{controller}.{method} - Delete, Delete provider by Id, Result - OK, Task ended", nameof(ProviderController), nameof(UpdateProviderAsync));
            return Ok("Provider was deleted");
        }
    }
}
