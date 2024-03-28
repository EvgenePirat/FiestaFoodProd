using AutoMapper;
using Business.Interfaces;
using Business.Models.Dishes;
using Business.Models.Enums;
using Business.Models.Filter;
using Business.Models.Orders.Request;
using Business.Models.Orders.Response;
using Business.Models.Pagination;
using CustomExceptions.IngredientCustomException;
using CustomExceptions.OrderCustomExceptions;
using CustomExceptions.OrderDetailCustomExceptions;
using DataAccess.Interfaces;
using DataAccess.Utilities;
using Entities.Entities;

namespace Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IDishService _dishService;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper, IOrderDetailService orderDetailService, IDishService dishService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _orderDetailService = orderDetailService;
            _dishService = dishService;
        }

        public async Task<OrderModel> GetOrderByIdAsync(Guid id, CancellationToken ct)
        {
            var order = await _unitOfWork.OrderRepository.GetByIdAsync(id, ct) ??
                        throw new OrderArgumentException($"Order with this id {id} not exist");

            return _mapper.Map<OrderModel>(order);
        }

        private async Task<bool> CheckSumOrder(Order order, CancellationToken ct)
        {
            double sum = 0;

            foreach (var item in order.OrderItems)
            {
                var dish = await _unitOfWork.DishRepository.GetDishById(item.DishId, ct);

                if(dish != null)
                    sum = sum + (dish.Price * item.Count);
            }

            return sum == order.OrderDetail.Sum;
        }

        public async Task<OrderModel?> CreateOrderAsync(CreateOrderModel model, CancellationToken ct)
        {
            await using var transaction = await _unitOfWork.BeginTransactionDbContextAsync(ct);
            var createModel = new Order();

            try
            {
                if(model.OrderState == OrderState.Todo && model.OrderDetail.PaymentStatus == PaymentStatus.Payed)
                {
                    createModel = _mapper.Map<Order>(model);

                    if((await CheckSumOrder(createModel, ct)) == false)
                    {
                        throw new OrderDetailArgumentException("Dishes price are not equal order sum");
                    }

                    await SubtractIngredients(createModel.OrderItems, ct);

                    _unitOfWork.OrderRepository.Add(createModel);          

                    await _unitOfWork.SaveAsync(ct);

                    await transaction.CommitAsync(ct);
                }


                return _mapper.Map<OrderModel>(createModel);

            }
            catch (OrderDetailArgumentException ex)
            {
                await transaction.RollbackAsync(ct);
                throw;
            }
            catch (IngredientArgumentException ex)
            {
                await transaction.RollbackAsync(ct);
                throw;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(ct);
                throw new OrderArgumentException("Unable to create order", ex);
            }
        }


        private async Task SubtractIngredients(IEnumerable<OrderItem> items, CancellationToken ct)
        {
            foreach(OrderItem item in items)
            {
                var dish = _unitOfWork.DishRepository.GetDishById(item.DishId, ct).Result;

                var ingredients = await _unitOfWork.IngredientsRepository.GetAllAsync(ct);

                if(dish != null)
                {
                    foreach (var dishIngridient in dish.DishIngridients)
                    {
                        var ingredient = ingredients.FirstOrDefault(i => i.Id == dishIngridient.IngredientId);

                        if (ingredient != null)
                        {
                            if (ingredient.Quantity.Count > (dishIngridient.Count * item.Count))
                                ingredient.Quantity.Count -= (dishIngridient.Count * item.Count);
                            else
                                throw new IngredientArgumentException($"Quantity for {ingredient.Name} not enough. Now - {ingredient.Quantity.Count} {ingredient.Quantity.Measurement}");
                        }
                    }
                }         
            }

            await _unitOfWork.SaveAsync(ct);
        }

        public async Task DeleteOrderByIdAsync(Guid id, CancellationToken ct)
        {
            var order = await _unitOfWork.OrderRepository.GetByIdAsync(id, ct) ??
                        throw new OrderArgumentException($"Order with this id {id} not exist");

            _unitOfWork.OrderRepository.Delete(order);

            await _unitOfWork.SaveAsync(ct);
        }

        public Task<PagedOrdersModel> GetFilteredOrdersAsync(FilterModel filter, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderModel> UpdateOrderAsync(UpdateOrderModel model, CancellationToken ct)
        {
            await using var transaction = await _unitOfWork.BeginTransactionDbContextAsync(ct);
            try
            {
                var order = await _unitOfWork.OrderRepository.GetByIdAsync(model.Id, ct)
                            ?? throw new OrderArgumentException($"Order with this id {model.Id} does not exist");

                order = SetUpdateDataForOrderDetails(order, model);

                order = SetUpdateDataForOrder(order, model);

                order = SetUpdateDataForOrderItemsAsync(order, model);

                _unitOfWork.OrderDetailRepository.Update(order.OrderDetail);

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

        private Order SetUpdateDataForOrderDetails(Order order, UpdateOrderModel model)
        {
            order.OrderDetail.IsPaid = model.OrderDetail.IsPaid;
            order.OrderDetail.PaymentType = (Entities.Enums.PaymentType)model.OrderDetail.PaymentType;
            order.OrderDetail.PaymentStatus = (Entities.Enums.PaymentStatus)model.OrderDetail.PaymentStatus;
            order.OrderDetail.Sum = model.OrderDetail.Sum;

            return order;
        }

        private Order SetUpdateDataForOrder(Order order, UpdateOrderModel model)
        {
            order.OrderState = (Entities.Enums.OrderState)model.OrderState;
            order.OrderCreateDate = model.OrderCreateDate;
            order.OrderFinishedDate = model.OrderFinishedDate;
            
            return order;
        }

        private Order SetUpdateDataForOrderItemsAsync(Order order, UpdateOrderModel model)
        {
            order.OrderItems = _mapper.Map<IEnumerable<OrderItem>>(model.OrderItems);

            foreach(OrderItem item in order.OrderItems)
            {
                item.OrderId = order.Id;
            }

            return order;
        }

        public async Task<PagedOrdersModel> GetAllOrdersAsync(PaginationModel pagination, CancellationToken ct)
        {
            var mappedModel = _mapper.Map<PaginationDb>(pagination);

            var result = await _unitOfWork.OrderRepository.GetAllOrdersPagination(mappedModel, ct);

            return new PagedOrdersModel()
            {
                Orders = _mapper.Map<IEnumerable<OrderModel>>(result.Result),
                TotalPages = result.TotalPages
            };

        }
    }
}
