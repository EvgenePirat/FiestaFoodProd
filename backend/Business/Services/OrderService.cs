using AutoMapper;
using Business.Interfaces;
using Business.Models.CustomerInfos.Request;
using Business.Models.Filter;
using Business.Models.OrderDetails.Request;
using Business.Models.Orders.Request;
using Business.Models.Orders.Response;
using CustomExceptions.CustomerInfoCustomException;
using CustomExceptions.OrderCustomExceptions;
using DataAccess.Interfaces;
using DataAccess.Utilities;
using Entities.Entities;
using Entities.Enums;

namespace Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOrderDetailService _orderDetailService;
        private readonly ICustomerInfoService _customerInfoService;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper, IOrderDetailService orderDetailService, ICustomerInfoService customerInfoService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _orderDetailService = orderDetailService;
            _customerInfoService = customerInfoService;
        }

        public async Task<OrderModel> CreateOrderAsync(CreateOrderModel model, CancellationToken ct)
        {
            await using var transaction = await _unitOfWork.BeginTransactionDbContextAsync(ct);
            try
            {
                var order = new Order();

                var customerInfo = await GetOrderCustomerInfo(model, ct);
                order.CustomerInfoId = customerInfo.Id;

                var orderDetail = _mapper.Map<OrderDetail>(model.OrderDetail);

                _unitOfWork.OrderDetailRepository.Add(orderDetail);
                await _unitOfWork.SaveAsync(ct);

                order.OrderDetail = orderDetail;
                order.OrderDetail.OrderState = OrderState.Pending;

                order.Products = await GetOrderProductsAsync(model.ProductIds, ct);
                order.Price = order.Products.Sum(pr => pr.Price);

                _unitOfWork.OrderRepository.Add(order);
                await _unitOfWork.SaveAsync(ct);

                await transaction.CommitAsync(ct);
                order.CustomerInfo = customerInfo;
                return _mapper.Map<OrderModel>(order);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(ct);
                throw new OrderArgumentException("Unable to create order", ex);
            }
        }


        public async Task<OrderModel> GetOrderByIdAsync(Guid id, CancellationToken ct)
        {
            var order = await _unitOfWork.OrderRepository.GetByIdAsync(id, ct) ??
                        throw new OrderArgumentException($"Order with this id {id} not exist");
            return _mapper.Map<OrderModel>(order);
        }

        public async Task<PagedOrdersModel> GetFilteredOrdersAsync(FilterModel filter, CancellationToken ct)
        {
            var dbFilter = _mapper.Map<FilterState>(filter);
            var result = await _unitOfWork.OrderRepository.GetPagedByQueryAsync(dbFilter, ct);
            return _mapper.Map<PagedOrdersModel>(result);
        }

        public async Task<OrderModel> UpdateOrderAsync(UpdateOrderModel model, CancellationToken ct)
        {
            await using var transaction = await _unitOfWork.BeginTransactionDbContextAsync(ct);
            try
            {
                var order = await _unitOfWork.OrderRepository.GetByIdAsync(model.Id, ct)
                            ?? throw new OrderArgumentException($"Order with this id {model.Id} does not exist");

                order.Products = await GetOrderProductsAsync(model.ProductIds, ct);
                order.Price = order.Products.Sum(pr => pr.Price);

                if (model.CustomerInfo is not null)
                {
                    await _customerInfoService.UpdateCustomerInfoAsync(model.CustomerInfo, ct);
                }

                _unitOfWork.OrderRepository.Update(order);
                await _unitOfWork.SaveAsync(ct);

                await transaction.CommitAsync(ct);
                return _mapper.Map<OrderModel>(order);
            }
            catch (OrderArgumentException ex)
            {
                await transaction.RollbackAsync(ct);
                throw new OrderArgumentException(ex.Message);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(ct);
                throw new OrderArgumentException("Unable to save order", ex);
            }
        }

        public async Task DeleteOrderByIdAsync(Guid id, CancellationToken ct)
        {
            var order = await _unitOfWork.OrderRepository.GetByIdAsync(id, ct) ??
                        throw new OrderArgumentException($"Order with this id {id} not exist");
            _unitOfWork.OrderRepository.Delete(order);
            await _unitOfWork.SaveAsync(ct);
        }

        private async Task<IEnumerable<Product>> GetOrderProductsAsync(IEnumerable<Guid> productIds, CancellationToken ct)
        {
            var products = await _unitOfWork.ProductRepository.GetProductsByIds(productIds, ct)
                           ?? throw new OrderArgumentException($"Products with ids: {string.Join(", ", productIds)} not exist");

            var existingProductIds = products.Select(pr => pr.Id);
            var nonExistentProductIds = productIds.Except(existingProductIds);

            if (nonExistentProductIds.Any())
            {
                throw new OrderArgumentException($"Products with ids: {string.Join(", ", nonExistentProductIds)} not exist");
            }

            return products;
        }

        private async Task<CustomerInfo> GetOrderCustomerInfo(CreateOrderModel model, CancellationToken ct)
        {
            if (model is { CustomerInfoId: null, CustomerInfo: not null })
            {
                var mappedModel = _mapper.Map<CustomerInfo>(model.CustomerInfo);
                _unitOfWork.CustomerInfoRepository.Add(mappedModel);
                return mappedModel;
            }

            if (model.CustomerInfoId is not null)
            {
                return await _unitOfWork.CustomerInfoRepository.GetCustomerInfoById((Guid)model.CustomerInfoId, ct) 
                       ?? throw new CustomerInfoArgumentException($"Customer with this id {model.CustomerInfoId} not exist");
            }

            throw new OrderArgumentException("Missing required customer information");
        }
    }
}
