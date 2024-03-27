using AutoMapper;
using Business.Interfaces;
using Business.Models.OrderDetails.Request;
using Business.Models.OrderDetails.Response;
using CustomExceptions.OrderDetailCustomExceptions;
using DataAccess.Interfaces;
using Entities.Entities;
using Entities.Enums;

namespace Business.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderDetailService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        //public async Task<OrderDetailModel> CreateOrderDetailAsync(CreateOrderDetailModel model, CancellationToken ct)
        //{
        //    var orderDetail = _mapper.Map<OrderItem>(model);

        //    _unitOfWork.OrderDetailRepository.Add(orderDetail);
        //    await _unitOfWork.SaveAsync(ct);

        //    return _mapper.Map<OrderDetailModel>(orderDetail);
        //}

        //public async Task<OrderDetailModel> UpdateOrderDetailAsync(UpdateOrderDetailModel model, CancellationToken ct)
        //{
        //    var orderDetail = await _unitOfWork.OrderDetailRepository.GetByIdAsync(model.Id, ct)
        //                      ?? throw new OrderDetailArgumentException($"Entity with this {model.Id} not exist");

        //    orderDetail.IsPaid = model.IsPaid;
        //    orderDetail.OrderState = _mapper.Map<OrderState>(model.OrderState);
        //    _unitOfWork.OrderDetailRepository.Update(orderDetail);
        //    await _unitOfWork.SaveAsync(ct);

        //    return _mapper.Map<OrderDetailModel>(orderDetail);
        //}

        //public async Task DeleteOrderDetailByIdAsync(Guid id, CancellationToken ct)
        //{
        //    var orderDetail = await _unitOfWork.OrderDetailRepository.GetByIdAsync(id, ct)
        //                      ?? throw new OrderDetailArgumentException($"Entity with this {id} not exist");
        //    _unitOfWork.OrderDetailRepository.Delete(orderDetail);
        //    await _unitOfWork.SaveAsync(ct);
        //}

        //public async Task<OrderDetailModel> GetOrderDetailAsyncById(Guid id, CancellationToken ct)
        //{
        //    var orderDetail = await _unitOfWork.OrderRepository.GetByIdAsync(id, ct)
        //                      ?? throw new OrderDetailArgumentException($"OrderDetail with this {id} not exist");
        //    return _mapper.Map<OrderDetailModel>(orderDetail);
        //}

        //public async Task<OrderDetailModel> UpdateOrderDetailState(UpdateOrderDetailStateModel model, CancellationToken ct)
        //{
        //    var orderDetail = await _unitOfWork.OrderDetailRepository.GetByIdAsync(model.Id, ct)
        //                      ?? throw new OrderDetailArgumentException($"Entity with this {model.Id} not exist");

        //    orderDetail.OrderState = _mapper.Map<OrderState>(model.OrderState);

        //    _unitOfWork.OrderDetailRepository.Update(orderDetail);
        //    await _unitOfWork.SaveAsync(ct);

        //    return _mapper.Map<OrderDetailModel>(orderDetail);
        //}
        public Task<OrderDetailModel> CreateOrderDetailAsync(CreateOrderDetailModel model, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOrderDetailByIdAsync(Guid id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDetailModel> GetOrderDetailAsyncById(Guid id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDetailModel> UpdateOrderDetailAsync(UpdateOrderDetailModel model, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
