using AutoMapper;
using Business.Interfaces;
using Business.Models.Pagination;
using Business.Models.Providers;
using CustomExceptions.ProviderCustomExceptions;
using DataAccess.Interfaces;
using DataAccess.Utilities;
using Entities.Entities;

namespace Business.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProviderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateProviderAsync(CreateProviderModel model, CancellationToken ct)
        {
            var mappedModel = _mapper.Map<Provider>(model);
            _unitOfWork.ProviderRepository.Add(mappedModel);
            await _unitOfWork.SaveAsync(ct);
        }

        public async Task<ProviderModel> GetProviderByProductAsync(Guid productId, CancellationToken ct)
        {
            var provider = await _unitOfWork.ProviderRepository.GetProviderByProductIdAsync(productId, ct)
                           ?? throw new ProviderArgumentException("Provider with this id not exist");
            return _mapper.Map<ProviderModel>(provider);
        }

        public async Task<ProviderModel> GetProviderByIdAsync(Guid providerId, CancellationToken ct)
        {
            var provider = await _unitOfWork.ProviderRepository.GetByIdAsync(providerId, ct) 
                           ?? throw new ProviderArgumentException("Provider with this id not exist");
            return _mapper.Map<ProviderModel>(provider);
        }

        public async Task<PagedProviders> GetAllCompanyProvidersAsync(PaginationModel pagination, CancellationToken ct)
        {
            var mappedPagination = _mapper.Map<PaginationDb>(pagination);

            var result = await _unitOfWork.ProviderRepository.GetPagedAsync(mappedPagination, ct);

            var brands = _mapper.Map<IEnumerable<ProviderModel>>(result.Result);

            return new PagedProviders
            {
                Providers = _mapper.Map<IEnumerable<ProviderModel>>(brands),
                TotalPages = result.TotalPages
            };
        }

        // TODO: Refactor
        public async Task<ProviderModel> UpdateProviderAsync(UpdateProviderModel model, CancellationToken ct)
        {
            var providerToUpdate = await _unitOfWork.ProviderRepository.GetByIdAsync(model.Id, ct)
                                   ?? throw new ProviderArgumentException("Provider with this id not exist");
            providerToUpdate.Name = model.Name;

            _unitOfWork.ProviderRepository.Update(providerToUpdate);
            await _unitOfWork.SaveAsync(ct);

            return _mapper.Map<ProviderModel>(providerToUpdate);
        }

        public async Task DeleteProviderAsync(Guid providerId, CancellationToken ct)
        {
            var providerToDelete = await _unitOfWork.ProviderRepository.GetByIdAsync(providerId, ct)
                                ?? throw new ProviderArgumentException("Provider with this id not exist");
            _unitOfWork.ProviderRepository.Delete(providerToDelete);
            await _unitOfWork.SaveAsync(ct);
        }
    }
}
