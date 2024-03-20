using AutoMapper;
using Business.Interfaces;
using Business.Models.Categories;
using CustomExceptions.CategoryCustomExceptions;
using CustomExceptions.DishCustomExceptions;
using DataAccess.Interfaces;
using Entities.Entities;
using FileStorageHandler.Interfaces;

namespace Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;
        private readonly IDirectoryService _directoryService;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService, IDirectoryService directoryService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fileService = fileService;
            _directoryService = directoryService;
        }

        public async Task<CategoryModel> CreateCategoryAsync(CreateCategoryModel model, CancellationToken ct)
        {
            var mappedModel = _mapper.Map<Category>(model);

            var categoryExist = await _unitOfWork.CategoryRepository.FindByCategoryNameAsync(model.CategoryName, ct);

            if (categoryExist != null)
                throw new CategoryArgumentException("Category with name already exist");

            var defaultPath = await _directoryService.GetDefaultPathAsync(mappedModel, ct);

            mappedModel.PhotoPaths = defaultPath;

            _unitOfWork.CategoryRepository.Add(mappedModel);

            await _unitOfWork.SaveAsync(ct);

            var category = await _unitOfWork.CategoryRepository.FindByCategoryNameAsync(model.CategoryName, ct);

            if (model.FormFile is not null)
                await _fileService.UploadFileAsync(model.FormFile, defaultPath, ct);

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

            var defaultPath = string.IsNullOrEmpty(categoryToUpdate.PhotoPaths)
                ? await _directoryService.GetDefaultPathAsync(categoryToUpdate, ct)
                : categoryToUpdate.PhotoPaths;

            if (categoryToUpdate.CategoryName != model.CategoryName)
                await UpdateFolderAndPath(model,defaultPath,categoryToUpdate,ct);

            try
            {
                _unitOfWork.CategoryRepository.Update(categoryToUpdate);
                await _unitOfWork.SaveAsync(ct);

                if (model.FormFile is not null)
                    await _fileService.UploadFileAsync(model.FormFile, defaultPath, ct);
            }
            catch
            {
                if (categoryToUpdate.CategoryName != model.CategoryName)
                    await _directoryService.RenameFolderAsync(defaultPath, categoryToUpdate.CategoryName, ct);

                throw new CategoryArgumentException("An error occurred while updating the Category.");
            }

            return _mapper.Map<CategoryModel>(categoryToUpdate);
        }

        private async Task UpdateFolderAndPath(UpdateCategoryModel model, string defaultPath, Category categoryToUpdate, CancellationToken ct)
        {
            await _directoryService.RenameFolderAsync(defaultPath, model.CategoryName, ct);

            categoryToUpdate.CategoryName = model.CategoryName;

            defaultPath = await _directoryService.GetDefaultPathAsync(categoryToUpdate, ct);

            if (string.IsNullOrEmpty(defaultPath))
                throw new DirectoryNotFoundException("Exception with directory (not found)");

            categoryToUpdate.PhotoPaths = defaultPath;
        }

        public async Task DeleteCategoryAsync(int id, CancellationToken ct)
        {
            var categoryToDelete = await _unitOfWork.CategoryRepository.GetByIdAsync(id, ct)
                                ?? throw new CategoryArgumentException("Category with this id not exist");

            _unitOfWork.CategoryRepository.Delete(categoryToDelete);

            await _directoryService.DeleteFolderByPathAsync(categoryToDelete.PhotoPaths, ct);

            await _unitOfWork.SaveAsync(ct);
        }
    }
}
