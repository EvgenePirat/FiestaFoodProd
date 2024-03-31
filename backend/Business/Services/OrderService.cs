using AutoMapper;
using Business.Interfaces;
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

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderModel> GetOrderByIdAsync(Guid id, CancellationToken ct)
        {
            var order = await _unitOfWork.OrderRepository.GetByIdAsync(id, ct) ??
                        throw new OrderArgumentException($"Order with this id {id} not exist");

            return _mapper.Map<OrderModel>(order);
        }

        private async Task<bool> CheckSumOrder(Order order, CancellationToken ct)
        {
            var dishes = await _unitOfWork.DishRepository.GetDishesByIds(
                order.OrderItems.Select(d => d.DishId), ct);
            var sum = (from orderItem in order.OrderItems
                       let dish = dishes.FirstOrDefault(d => d.Id == orderItem.DishId)
                       select orderItem.Count * dish.Price).Sum();
            return sum.Equals(order.OrderDetail.Sum);
        }

        public async Task<OrderModel> CreateOrderAsync(CreateOrderModel model, CancellationToken ct)
        {
            await using var transaction = await _unitOfWork.BeginTransactionDbContextAsync(ct);
            var createModel = new Order();

            try
            {
                if (model is not { OrderState: OrderState.Todo, OrderDetail.PaymentStatus: PaymentStatus.Payed })
                    return _mapper.Map<OrderModel>(createModel);

                createModel = _mapper.Map<Order>(model);

                if (await CheckSumOrder(createModel, ct) == false)
                {
                    throw new OrderDetailArgumentException("Dishes price are not equal order sum");
                }

                await SubtractIngredients(createModel.OrderItems, ct);

                _unitOfWork.OrderRepository.Add(createModel);

                await _unitOfWork.SaveAsync(ct);

                await transaction.CommitAsync(ct);

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

        public async Task<OrderModel> UpdateOrderStateAsync(UpdateOrderStateModel model, CancellationToken ct)
        {
            await using var transaction = await _unitOfWork.BeginTransactionDbContextAsync(ct);
            try
            {
                var order = await _unitOfWork.OrderRepository.GetByIdAsync(model.OrderId, ct) ??
                            throw new OrderArgumentException($"Order with this id {model.OrderId} not exist");
                order.OrderState = _mapper.Map<Entities.Enums.OrderState>(model.OrderState);
                await _unitOfWork.SaveAsync(ct);
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

        public Task<PagedOrdersModel> GetFilteredOrdersAsync(FilterModel filter, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderModel> UpdateOrderAsync(Guid id, UpdateOrderModel model, CancellationToken ct)
        {
            await using var transaction = await _unitOfWork.BeginTransactionDbContextAsync(ct);
            try
            {
                var order = await _unitOfWork.OrderRepository.GetByIdAsync(id, ct)
                            ?? throw new OrderArgumentException($"Order with this id {id} does not exist");

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

        private async Task SubtractIngredients(IEnumerable<OrderItem> items, CancellationToken ct)
        {
            foreach (var item in items)
            {
                var dish = _unitOfWork.DishRepository.GetDishById(item.DishId, ct).Result;

                var ingredients = await _unitOfWork.IngredientsRepository.GetAllAsync(ct);

                if (dish is null) continue;
                foreach (var dishIngredient in dish.DishIngridients)
                {
                    var ingredient = ingredients.FirstOrDefault(i => i.Id == dishIngredient.IngredientId);

                    if (ingredient == null) continue;
                    if (ingredient.Quantity.Count > dishIngredient.Count * item.Count)
                        ingredient.Quantity.Count -= dishIngredient.Count * item.Count;
                    else
                        throw new IngredientArgumentException($"Quantity for {ingredient.Name} not enough. Now - {ingredient.Quantity.Count} {ingredient.Quantity.Measurement}");
                }
            }

            await _unitOfWork.SaveAsync(ct);
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

            foreach (var item in order.OrderItems)
            {
                item.OrderId = order.Id;
            }

            return order;
        }
    }
}
