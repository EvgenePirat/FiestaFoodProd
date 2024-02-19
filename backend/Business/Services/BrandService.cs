using AutoMapper;
using Business.Interfaces;
using Business.Models.Brands;
using Business.Models.Pagination;
using CustomExceptions.BrandCustomExceptions;
using DataAccess.Interfaces;
using DataAccess.Utilities;
using Entities.Entities;

namespace Business.Services
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BrandService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task CreateBrandAsync(CreateBrandModel model, CancellationToken ct)
        {
            var mappedModel = _mapper.Map<Brand>(model);
            _unitOfWork.BrandRepository.Add(mappedModel);
            await _unitOfWork.SaveAsync(ct);
        }

        // Todo: discus about verification model
        public async Task<BrandModel> UpdateBrandAsync(UpdateBrandModel brand, CancellationToken ct)
        {
            var brandToUpdate = await _unitOfWork.BrandRepository.GetById(brand.Id, ct) 
                                ?? throw new BrandArgumentException("Brand with this id not exist");
            brandToUpdate.Description = brand.Description;
            brandToUpdate.Name = brand.Name;

            _unitOfWork.BrandRepository.Update(brandToUpdate);
            await _unitOfWork.SaveAsync(ct);

            return _mapper.Map<BrandModel>(brandToUpdate);
        }

        public async Task DeleteBrandByIdAsync(Guid id, CancellationToken ct)
        {
            var brandToDelete = await _unitOfWork.BrandRepository.GetById(id, ct)
                                ?? throw new BrandArgumentException("Brand with this id not exist");
            _unitOfWork.BrandRepository.Delete(brandToDelete);
            await _unitOfWork.SaveAsync(ct);
        }

        // Todo: Register Mapper
        public async Task<BrandPaged> GetBrandsPagedAsync(PaginationModel pagination, CancellationToken ct)
        {
            var mappedPagination = _mapper.Map<PaginationDb>(pagination);

            var result = await _unitOfWork.BrandRepository.GetPagedAsync(mappedPagination, ct);

            var brands = _mapper.Map<IEnumerable<BrandModel>>(result.Result);

            return new BrandPaged
            {
                Brands = _mapper.Map<IEnumerable<BrandModel>>(brands),
                TotalPages = result.TotalPages
            };
        }
    }
}
