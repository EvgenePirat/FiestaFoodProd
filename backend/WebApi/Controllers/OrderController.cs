using AutoMapper;
using Business.Interfaces;
using Business.Models.Orders.Request;
using Business.Models.Pagination;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Orders.Request;
using WebApi.Models.Orders.Response;
using WebApi.Models.PaginationsDto;
using WebApi.Utilities;

namespace WebApi.Controllers
{
    public class OrderController : CustomControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrderController> _logger;
        private readonly IMapper _mapper;
        public OrderController(IOrderService orderService, ILogger<OrderController> logger, IMapper mapper)
        {
            _orderService = orderService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> CreateOrderAsync([FromBody]CreateOrderDto model, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Post, Create Order, Task started", 
                nameof(OrderController), nameof(CreateOrderAsync));

            var mappedModel = _mapper.Map<CreateOrderModel>(model);

            var order = await _orderService.CreateOrderAsync(mappedModel, ct);

            var mappedOrder = _mapper.Map<OrderDto>(order);

            _logger.LogInformation("{controller}.{method} - Post, Create Order, Result - Ok, Task ended",
                nameof(OrderController), nameof(CreateOrderAsync));

            return Ok(mappedOrder);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<OrderDto>> GetOrderByIdAsync(Guid id, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Get, Get Order by id {id}, Task started",
                nameof(OrderController), nameof(GetOrderByIdAsync), id);

            var order = await _orderService.GetOrderByIdAsync(id, ct);

            var mappedOrder = _mapper.Map<OrderDto>(order);

            _logger.LogInformation("{controller}.{method} - Get, Get Order by id {id}, Result - Ok, Task ended",
                nameof(OrderController), nameof(GetOrderByIdAsync), id);

            return Ok(mappedOrder);
        }

        //[HttpGet("filtered")]
        //public async Task<ActionResult<PagedOrdersDto>> GetFilteredOrderAsync([FromQuery] FilterDto model, CancellationToken ct)
        //{
        //    _logger.LogInformation("{controller}.{method} - Get, Get Order by filter, Task started",
        //        nameof(OrderController), nameof(GetFilteredOrderAsync));

        //    var mappedFilter = _mapper.Map<FilterModel>(model);

        //    var result = await _orderService.GetFilteredOrdersAsync(mappedFilter, ct);

        //    var mappedResult = _mapper.Map<PagedOrdersDto>(result);

        //    _logger.LogInformation("{controller}.{method} - Get, Get Order by filter, Result - Ok, Task ended",
        //        nameof(OrderController), nameof(GetFilteredOrderAsync));

        //    return Ok(mappedResult);
        //}

        [HttpGet("all")]
        public async Task<ActionResult<PagedOrdersDto>> GetAllOrderAsync([FromQuery] PaginationDto model, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Get, Get all orders, Task started",
                nameof(OrderController), nameof(GetAllOrderAsync));

            var mappedModel = _mapper.Map<PaginationModel>(model);

            var result = await _orderService.GetAllOrdersAsync(mappedModel, ct);

            var mappedResult = _mapper.Map<PagedOrdersDto>(result);

            _logger.LogInformation("{controller}.{method} - Get, Get Order by filter, Result - Ok, Task ended",
                nameof(OrderController), nameof(GetAllOrderAsync));

            return Ok(mappedResult);
        }


        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<OrderDto>> UpdateOrderAsync(Guid id, [FromBody] UpdateOrderDto model, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Put, Update Order {Id}, Task started",
                nameof(OrderController), nameof(UpdateOrderAsync), id);

            var updateModel = _mapper.Map<UpdateOrderModel>(model);

            var order = await _orderService.UpdateOrderAsync(id, updateModel, ct);

            var mappedOrder = _mapper.Map<OrderDto>(order);

            _logger.LogInformation("{controller}.{method} - Put, Update Order {model.Id}, Result - Ok, Task ended",
                nameof(OrderController), nameof(UpdateOrderAsync), id);

            return Ok(mappedOrder);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteOrderByIdAsync(Guid id, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Delete, Delete Order by id, Task started",
                nameof(OrderController), nameof(DeleteOrderByIdAsync));

            await _orderService.DeleteOrderByIdAsync(id, ct);

            _logger.LogInformation("{controller}.{method} - Delete, Delete Order by id, Result - Ok, Task ended",
                nameof(OrderController), nameof(DeleteOrderByIdAsync));

            return Ok("Order has been deleted");
        }
    }
}
