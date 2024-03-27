using AutoMapper;
using Business.Interfaces;
using Business.Models.OrderDetails.Request;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.OrderDetails.Request;
using WebApi.Models.OrderDetails.Response;
using WebApi.Utilities;

namespace WebApi.Controllers
{ 
//{
//    public class OrderDetailController : CustomControllerBase
//    {
//        private readonly IOrderDetailService _orderDetailService;
//        private readonly ILogger<OrderDetailController> _logger;
//        private readonly IMapper _mapper;
//        public OrderDetailController(IOrderDetailService orderDetailService, ILogger<OrderDetailController> logger, IMapper mapper)
//        {
//            _orderDetailService = orderDetailService;
//            _logger = logger;
//            _mapper = mapper;
//        }

//        [HttpPost("create")]
//        public async Task<ActionResult<OrderDetailDto>> CreateOrderDetailAsync([FromBody] CreateOrderDetailDto model, CancellationToken ct)
//        {
//            _logger.LogInformation("{controller}.{method} - Post, Create OrderDetail, Task started",
//                nameof(OrderDetailController), nameof(CreateOrderDetailAsync));

//            var mappedModel = _mapper.Map<CreateOrderDetailModel>(model);

//            var orderDetail = await _orderDetailService.CreateOrderDetailAsync(mappedModel, ct);

//            var mappedOrderDetail = _mapper.Map<OrderDetailDto>(orderDetail);

//            _logger.LogInformation("{controller}.{method} - Post, Create OrderDetail, Result - Ok, Task ended",
//                nameof(OrderDetailController), nameof(CreateOrderDetailAsync));

//            return Ok(mappedOrderDetail);
//        }

//        [HttpGet("by-id")]
//        public async Task<ActionResult<OrderDetailDto>> GetOrderDetailByIdAsync([FromQuery] Guid id, CancellationToken ct)
//        {
//            _logger.LogInformation("{controller}.{method} - Get, Get OrderDetail by id {id}, Task started",
//                nameof(OrderDetailController), nameof(GetOrderDetailByIdAsync));

//            var OrderDetail = await _orderDetailService.GetOrderDetailAsyncById(id, ct);

//            var mappedOrderDetail = _mapper.Map<OrderDetailDto>(OrderDetail);

//            _logger.LogInformation("{controller}.{method} - Get, Get OrderDetail by id {id}, Result - Ok, Task ended",
//                nameof(OrderDetailController), nameof(GetOrderDetailByIdAsync));

//            return Ok(mappedOrderDetail);
//        }
//        [HttpPut("update")]
//        public async Task<ActionResult<OrderDetailDto>> UpdateOrderDetailAsync([FromBody] UpdateOrderDetailDto model, CancellationToken ct)
//        {
//            _logger.LogInformation("{controller}.{method} - Put, Update OrderDetail {model.Id}, Task started",
//                nameof(OrderDetailController), nameof(UpdateOrderDetailAsync));

//            var updateModel = _mapper.Map<UpdateOrderDetailModel>(model);

//            var OrderDetail = await _orderDetailService.UpdateOrderDetailAsync(updateModel, ct);

//            var mappedOrderDetail = _mapper.Map<OrderDetailDto>(OrderDetail);

//            _logger.LogInformation("{controller}.{method} - Put, Update OrderDetail {model.Id}, Result - Ok, Task ended",
//                nameof(OrderDetailController), nameof(UpdateOrderDetailAsync));

//            return Ok(mappedOrderDetail);
//        }

//        [HttpDelete("by-id")]
//        public async Task<IActionResult> DeleteOrderDetailByIdAsync(Guid id, CancellationToken ct)
//        {
//            _logger.LogInformation("{controller}.{method} - Delete, Delete OrderDetail by id, Task started",
//                nameof(OrderDetailController), nameof(DeleteOrderDetailByIdAsync));

//            await _orderDetailService.DeleteOrderDetailByIdAsync(id, ct);

//            _logger.LogInformation("{controller}.{method} - Delete, Delete OrderDetail by id, Result - Ok, Task ended",
//                nameof(OrderDetailController), nameof(DeleteOrderDetailByIdAsync));

//            return Ok("OrderDetail has been deleted");
//        }
//    }
}
