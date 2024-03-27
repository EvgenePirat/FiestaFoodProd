using AutoMapper;
using Business.Interfaces;
using Business.Models.Enums;
using Business.Models.Filter;
using Business.Models.Orders.Request;
using Business.Models.Orders.Response;
using CustomExceptions.IngredientCustomException;
using CustomExceptions.OrderCustomExceptions;
using DataAccess.Interfaces;
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

        //public async Task<OrderModel> CreateOrderAsync(CreateOrderModel model, CancellationToken ct)
        //{
        //    await using var transaction = await _unitOfWork.BeginTransactionDbContextAsync(ct);
        //    try
        //    {
        //        var order = new Order();

        //        var customerInfo = await GetOrderCustomerInfo(model, ct);
        //        order.CustomerInfoId = customerInfo.Id;

        //        var orderDetail = _mapper.Map<OrderItem>(model.OrderDetail);

        //        _unitOfWork.OrderDetailRepository.Add(orderDetail);
        //        await _unitOfWork.SaveAsync(ct);

        //        order.OrderDetail = orderDetail;
        //        order.OrderDetail.OrderState = OrderState.Pending;

        //        order.Dishes = await GetOrderDishesAsync(model.DishesId, ct);
        //        order.Price = order.Dishes.Sum(pr => pr.Price);

        //        _unitOfWork.OrderRepository.Add(order);
        //        await _unitOfWork.SaveAsync(ct);

        //        await transaction.CommitAsync(ct);
        //        order.CustomerInfo = customerInfo;
        //        return _mapper.Map<OrderModel>(order);
        //    }
        //    catch (Exception ex)
        //    {
        //        await transaction.RollbackAsync(ct);
        //        throw new OrderArgumentException("Unable to create order", ex);
        //    }
        //}


        //public async Task<OrderModel> GetOrderByIdAsync(Guid id, CancellationToken ct)
        //{
        //    var order = await _unitOfWork.OrderRepository.GetByIdAsync(id, ct) ??
        //                throw new OrderArgumentException($"Order with this id {id} not exist");
        //    return _mapper.Map<OrderModel>(order);
        //}

        //public async Task<PagedOrdersModel> GetFilteredOrdersAsync(FilterModel filter, CancellationToken ct)
        //{
        //    var dbFilter = _mapper.Map<FilterState>(filter);
        //    var result = await _unitOfWork.OrderRepository.GetPagedByQueryAsync(dbFilter, ct);
        //    return _mapper.Map<PagedOrdersModel>(result);
        //}

        //public async Task<OrderModel> UpdateOrderAsync(UpdateOrderModel model, CancellationToken ct)
        //{
        //    await using var transaction = await _unitOfWork.BeginTransactionDbContextAsync(ct);
        //    try
        //    {
        //        var order = await _unitOfWork.OrderRepository.GetByIdAsync(model.Id, ct)
        //                    ?? throw new OrderArgumentException($"Order with this id {model.Id} does not exist");

        //        order.Dishes = await GetOrderDishesAsync(model.DishesId, ct);
        //        order.Price = order.Dishes.Sum(pr => pr.Price);

        //        if (model.CustomerInfo is not null)
        //        {
        //            await _customerInfoService.UpdateCustomerInfoAsync(model.CustomerInfo, ct);
        //        }

        //        _unitOfWork.OrderRepository.Update(order);
        //        await _unitOfWork.SaveAsync(ct);

        //        await transaction.CommitAsync(ct);
        //        return _mapper.Map<OrderModel>(order);
        //    }
        //    catch (OrderArgumentException ex)
        //    {
        //        await transaction.RollbackAsync(ct);
        //        throw new OrderArgumentException(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        await transaction.RollbackAsync(ct);
        //        throw new OrderArgumentException("Unable to save order", ex);
        //    }
        //}

        //public async Task DeleteOrderByIdAsync(Guid id, CancellationToken ct)
        //{
        //    var order = await _unitOfWork.OrderRepository.GetByIdAsync(id, ct) ??
        //                throw new OrderArgumentException($"Order with this id {id} not exist");
        //    _unitOfWork.OrderRepository.Delete(order);
        //    await _unitOfWork.SaveAsync(ct);
        //}

        //private async Task<IEnumerable<Dish>> GetOrderDishesAsync(IEnumerable<int> dishIds, CancellationToken ct)
        //{
        //    var dishes = await _unitOfWork.DishRepository.GetDishesByIds(dishIds, ct)
        //                   ?? throw new OrderArgumentException($"dishes with ids: {string.Join(", ", dishIds)} not exist");

        //    var ingredients  = await _unitOfWork.IngredientsRepository.GetAllAsync(ct);

        //    foreach (var dish in dishes)
        //    {
        //        SubtractIngredients(ingredients, dish.DishIngredients);
        //    }

        //    await _unitOfWork.IngredientsRepository.UpdateIngredients(ingredients, ct);

        //    var existingDishesIds = dishes.Select(pr => pr.Id);
        //    var nonExistDishesIds = dishIds.Except(existingDishesIds);

        //    if (nonExistDishesIds.Any())
        //    {
        //        throw new OrderArgumentException($"dishes with ids: {string.Join(", ", nonExistDishesIds)} not exist");
        //    }

        //    return dishes;
        //}

        //private async Task<CustomerInfo> GetOrderCustomerInfo(CreateOrderModel model, CancellationToken ct)
        //{
        //    if (model is { CustomerInfoId: null, CustomerInfo: not null })
        //    {
        //        var mappedModel = _mapper.Map<CustomerInfo>(model.CustomerInfo);
        //        _unitOfWork.CustomerInfoRepository.Add(mappedModel);
        //        return mappedModel;
        //    }

        //    if (model.CustomerInfoId is not null)
        //    {
        //        return await _unitOfWork.CustomerInfoRepository.GetCustomerInfoById((Guid)model.CustomerInfoId, ct) 
        //               ?? throw new CustomerInfoArgumentException($"Customer with this id {model.CustomerInfoId} not exist");
        //    }

        //    throw new OrderArgumentException("Missing required customer information");
        //}

        //private static void SubtractIngredients(IEnumerable<Ingredient> ingredients1,
        //    IEnumerable<Ingredient> ingredients2)
        //{
        //    var ingredientDict1 = ingredients1.ToDictionary(i => i.Name);
        //    var ingredientDict2 = ingredients2.ToDictionary(i => i.Name);

        //    // Subtracting kilograms from ingredients1 using ingredients2
        //    foreach (var kvp in ingredientDict2)
        //    {
        //        if (ingredientDict1.TryGetValue(kvp.Key, out var ingredient))
        //        {
        //            //ingredient.Kilograms -= kvp.Value.Kilograms;
        //        }
        //    }
        //}

        public async Task<OrderModel> GetOrderByIdAsync(Guid id, CancellationToken ct)
        {
            var order = await _unitOfWork.OrderRepository.GetByIdAsync(id, ct) ??
                        throw new OrderArgumentException($"Order with this id {id} not exist");

            return _mapper.Map<OrderModel>(order);
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

                    await SubtractIngredients(createModel.OrderItems, ct);

                    _unitOfWork.OrderRepository.Add(createModel);          

                    await _unitOfWork.SaveAsync(ct);

                    await transaction.CommitAsync(ct);
                }


                return _mapper.Map<OrderModel>(createModel);

            }
            catch(IngredientArgumentException ex)
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

        public Task DeleteOrderByIdAsync(Guid id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<PagedOrdersModel> GetFilteredOrdersAsync(FilterModel filter, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<OrderModel> UpdateOrderAsync(UpdateOrderModel model, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
