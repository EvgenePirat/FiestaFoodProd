using AutoMapper;
using Business.Interfaces;
using Business.Models.CustomerInfos.Request;
using Business.Models.CustomerInfos.Response;
using Business.Models.Filter;
using Business.Models.Pagination;
using CustomExceptions.CustomerInfoCustomException;
using DataAccess.Interfaces;
using DataAccess.Utilities;
using Entities.Entities;

namespace Business.Services
{
    public class CustomerInfoService : ICustomerInfoService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerInfoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CustomerInfoModel> CreateCustomerInfoAsync(CreateCustomerInfoModel model, CancellationToken ct)
        {
            var mappedModel = _mapper.Map<CustomerInfo>(model);
            _unitOfWork.CustomerInfoRepository.Add(mappedModel);
            await _unitOfWork.SaveAsync(ct);
            return _mapper.Map<CustomerInfoModel>(mappedModel);
        }

        public async Task<PagedCustomerInfoModel> GetAllCustomerInfoAsync(PaginationModel model, CancellationToken ct)
        {
            var mappedPagination = _mapper.Map<PaginationDb>(model);
            var result = await _unitOfWork.CustomerInfoRepository.GetPagedAsync(mappedPagination, ct);
            return _mapper.Map<PagedCustomerInfoModel>(result);
        }

        public async Task<CustomerInfoModel?> GetCustomerByIdAsync(Guid id, CancellationToken ct)
        {
            var customerInfo = await _unitOfWork.CustomerInfoRepository.GetCustomerInfoById(id, ct);
            return _mapper.Map<CustomerInfoModel>(customerInfo);
        }

        public async Task<CustomerInfoModel> UpdateCustomerInfoAsync(UpdateCustomerInfoModel model, CancellationToken ct)
        {
            var userInfoToUpdate = await _unitOfWork.CustomerInfoRepository.GetCustomerInfoById(model.Id, ct)
                                   ?? throw new CustomerInfoArgumentException("Customer Info with this id not exist");

            userInfoToUpdate.City = model.City;
            userInfoToUpdate.Address = model.Address;
            userInfoToUpdate.PhoneNumber = model.PhoneNumber;

            _unitOfWork.CustomerInfoRepository.Update(userInfoToUpdate);
            await _unitOfWork.SaveAsync(ct);

            return _mapper.Map<CustomerInfoModel>(userInfoToUpdate);
        }

        public async Task<PagedCustomerInfoModel> GetCustomerInfosByFilter(FilterModel model, CancellationToken ct)
        {
            var dbFilter = _mapper.Map<FilterState>(model);
            var result = await _unitOfWork.CustomerInfoRepository.GetPagedByQueryAsync(dbFilter, ct);
            return _mapper.Map<PagedCustomerInfoModel>(result);
        }

        public async Task DeleteCustomerInfoAsync(Guid id, CancellationToken ct)
        {
            var userInformationToDelete = await _unitOfWork.CustomerInfoRepository.GetCustomerInfoById(id, ct)
                                          ?? throw new CustomerInfoArgumentException("Customer Info with this id not exist");

            _unitOfWork.CustomerInfoRepository.Delete(userInformationToDelete);
            await _unitOfWork.SaveAsync(ct);
        }
    }
}
