using AutoMapper;
using Business.Interfaces;
using Business.Models.CustomerInfos.Request;
using Business.Models.Pagination;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.CustomerInfosDto.Request;
using WebApi.Models.CustomerInfosDto.Response;
using WebApi.Models.FiltersDto;
using WebApi.Models.PaginationsDto;
using WebApi.Utilities;

namespace WebApi.Controllers
{
    public class CustomerInfoController : CustomControllerBase
    {
        private readonly ICustomerInfoService _customerInfoService;
        private readonly IMapper _mapper;
        private readonly ILogger<CustomerInfoController> _logger;

        public CustomerInfoController(IMapper mapper, ILogger<CustomerInfoController> logger, ICustomerInfoService customerInfoService)
        {
            _mapper = mapper;
            _logger = logger;
            _customerInfoService = customerInfoService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<CustomerInfoDto>> CreateCustomerInfoAsync(CreateCustomerInfoDto model, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Post, Create Customer information, Task started", nameof(CustomerInfoController), nameof(CreateCustomerInfoAsync));

            var mappedCustomerInfo = _mapper.Map<CreateCustomerInfoModel>(model);

            var result = await _customerInfoService.CreateCustomerInfoAsync(mappedCustomerInfo, ct);

            var mappedResult = _mapper.Map<CustomerInfoDto>(result);

            _logger.LogInformation("{controller}.{method} - Post, Create Customer information, Result Ok, Task finished", nameof(CustomerInfoController), nameof(CreateCustomerInfoAsync));

            return Ok(mappedResult);
        }

        [HttpGet("all")]
        public async Task<ActionResult<PagedCustomerInfoDto>> GetAllCustomerInfosAsync([FromQuery] PaginationDto paged, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Get, get all Customers information, Task started", 
                nameof(CustomerInfoController), nameof(GetAllCustomerInfosAsync));

            var mappedPagination = _mapper.Map<PaginationModel>(paged);

            var result = await _customerInfoService.GetAllCustomerInfoAsync(mappedPagination, ct);

            var mappedResult = _mapper.Map<PagedCustomerInfoDto>(result);

            _logger.LogInformation("{controller}.{method} - Get, get all Customers information, Result Ok, Task finished", 
                nameof(CustomerInfoController), nameof(GetAllCustomerInfosAsync));

            return Ok(mappedResult);
        }

        [HttpGet("by-query")]
        public async Task<ActionResult<PagedCustomerInfoDto>> GetCustomerInfosByQueryAsync([FromQuery] FilterDto filter, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Get, get all Customers information by query, Task started", 
                nameof(CustomerInfoController), nameof(GetCustomerInfosByQueryAsync));

            var mappedPagination = _mapper.Map<PaginationModel>(filter);

            var result = await _customerInfoService.GetAllCustomerInfoAsync(mappedPagination, ct);

            var mappedResult = _mapper.Map<PagedCustomerInfoDto>(result);

            _logger.LogInformation("{controller}.{method} - Get, get all Customers information by query, Result Ok, Task finished", 
                nameof(CustomerInfoController), nameof(GetCustomerInfosByQueryAsync));

            return Ok(mappedResult);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteCustomerInfoAsync(Guid id, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Delete, delete Customer information, Task started", nameof(CustomerInfoController), nameof(DeleteCustomerInfoAsync));

            await _customerInfoService.DeleteCustomerInfoAsync(id, ct);

            _logger.LogInformation("{controller}.{method} - Delete, delete Customer information, Result Ok, Task finished", nameof(CustomerInfoController), nameof(DeleteCustomerInfoAsync));

            return Ok("Customer information was deleted");
        }

        [HttpPut("update")]
        public async Task<ActionResult<CustomerInfoDto>> UpdateCustomerInfoAsync([FromForm] UpdateCustomerInfoDto model, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Put, Update Customer information, Task started",nameof(CustomerInfoController), nameof(UpdateCustomerInfoAsync));

            var mappedModel = _mapper.Map<UpdateCustomerInfoModel>(model);

            var result = await _customerInfoService.UpdateCustomerInfoAsync(mappedModel, ct);

            var mappedResult = _mapper.Map<CustomerInfoDto>(result);

            _logger.LogInformation("{controller}.{method} - Put, Update Customer information,Result Ok, Task finished", nameof(CustomerInfoController), nameof(UpdateCustomerInfoAsync));

            return Ok(mappedResult);
        }
    }
}
