using AutoMapper;
using Business.Interfaces;
using Business.Models.Categories;
using CustomExceptions.CategoryCustomExceptions;
using DataAccess.Interfaces;
using Entities.Entities;

namespace Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CategoryModel> CreateCategoryAsync(CreateCategoryModel model, CancellationToken ct)
        {
            var mappedModel = _mapper.Map<Category>(model);
            _unitOfWork.CategoryRepository.Add(mappedModel);
            await _unitOfWork.SaveAsync(ct);

            var category = await _unitOfWork.CategoryRepository.FindByCategoryNameAsync(model.CategoryName, ct);

            return _mapper.Map<CategoryModel>(category);
        }

        public async Task<IEnumerable<CategoryModel>> GetAllCategoriesAsync(CancellationToken ct)
        {
            var categories = await _unitOfWork.CategoryRepository.GetAllAsync(ct);
            return _mapper.Map<IEnumerable<CategoryModel>>(categories);
        }

        public async Task<CategoryModel> UpdateCategoryAsync(UpdateCategoryModel model, CancellationToken ct)
        {
            var categoryToUpdate = await _unitOfWork.CategoryRepository.GetByIdAsync(model.Id, ct)
                                ?? throw new CategoryArgumentException("Category with this id not exist");

            categoryToUpdate.Description = model.Description;
            categoryToUpdate.CategoryName = model.CategoryName;

            _unitOfWork.CategoryRepository.Update(categoryToUpdate);
            await _unitOfWork.SaveAsync(ct);

            return _mapper.Map<CategoryModel>(categoryToUpdate);
        }

        public async Task DeleteCategoryAsync(int id, CancellationToken ct)
        {
            var categoryToDelete = await _unitOfWork.CategoryRepository.GetByIdAsync(id, ct)
                                ?? throw new CategoryArgumentException("Category with this id not exist");
            _unitOfWork.CategoryRepository.Delete(categoryToDelete);
            await _unitOfWork.SaveAsync(ct);
        }
    }
}
