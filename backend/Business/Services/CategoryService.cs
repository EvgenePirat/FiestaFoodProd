using AutoMapper;
using Business.Interfaces;
using Business.Models.Categories.Request;
using Business.Models.Categories.Response;
using CustomExceptions.CategoryCustomExceptions;
using CustomExceptions.DishCustomExceptions;
using DataAccess.Interfaces;
using Entities.Entities;
using FileStorageHandler.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;
        private readonly IDirectoryService _directoryService;
        private readonly IMediaHandlerService _mediaHandlerService;

        public CategoryService(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IFileService fileService, 
            IDirectoryService directoryService, 
            IMediaHandlerService mediaHandlerService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fileService = fileService;
            _directoryService = directoryService;
            _mediaHandlerService = mediaHandlerService;
        }

        public async Task<CategoryModel> CreateCategoryAsync(CreateCategoryModel model, CancellationToken ct)
        {
            var mappedModel = _mapper.Map<Category>(model);

            var categoryExist = await _unitOfWork.CategoryRepository.FindByCategoryNameAsync(model.Title, ct);

            if (categoryExist != null)
                throw new CategoryArgumentException("Category with name already exist");

            var defaultPath = await _directoryService.GetDefaultPathAsync(mappedModel, ct);

            if (model.File is not null)
            {
                List<IFormFile> files = new List<IFormFile> { model.File };
                await _fileService.UploadFilesAsync(files, defaultPath, ct);
            }

            mappedModel.Image = await _mediaHandlerService.GetPhotoByPathAsync(defaultPath, ct);
            mappedModel.Title = model.Title;

            _unitOfWork.CategoryRepository.Add(mappedModel);

            await _unitOfWork.SaveAsync(ct);

            var category = await _unitOfWork.CategoryRepository.FindByCategoryNameAsync(model.Title, ct);
                
            return _mapper.Map<CategoryModel>(category);
        }

        public async Task<IEnumerable<CategoryModel>> GetAllCategoriesAsync(CancellationToken ct)
        {
            var categories = await _unitOfWork.CategoryRepository.GetAllAsync(ct);

            return _mapper.Map<IEnumerable<CategoryModel>>(categories);
        }

        public async Task<CategoryModel> UpdateCategoryAsync(int id, UpdateCategoryModel model, CancellationToken ct)
        {
            var categoryToUpdate = await _unitOfWork.CategoryRepository.GetByIdAsync(id, ct)
                                ?? throw new CategoryArgumentException("Category with this id not exist");

            var defaultPath = string.IsNullOrEmpty(categoryToUpdate.Image)
                ? await _directoryService.GetDefaultPathAsync(categoryToUpdate, ct)
                : categoryToUpdate.Image;

            if (categoryToUpdate.Image != model.Title)
                await UpdateFolderAndPath(model,defaultPath,categoryToUpdate,ct);

            try
            {
                _unitOfWork.CategoryRepository.Update(categoryToUpdate);
                await _unitOfWork.SaveAsync(ct);

                if (model.File is not null)
                {
                    List<IFormFile> files = new List<IFormFile> { model.File };
                    await _fileService.UploadFilesAsync(files, defaultPath, ct);
                }
            }
            catch
            {
                if (categoryToUpdate.Title != model.Title)
                    await _directoryService.RenameFolderAsync(defaultPath, categoryToUpdate.Title, ct);

                throw new CategoryArgumentException("An error occurred while updating the Category.");
            }
            categoryToUpdate.Image = await _mediaHandlerService.GetPhotoByPathAsync(defaultPath, ct);
            return _mapper.Map<CategoryModel>(categoryToUpdate);
        }

        private async Task UpdateFolderAndPath(UpdateCategoryModel model, string defaultPath, Category categoryToUpdate, CancellationToken ct)
        {
            await _directoryService.RenameFolderAsync(defaultPath, model.Title, ct);

            categoryToUpdate.Title = model.Title;

            defaultPath = await _directoryService.GetDefaultPathAsync(categoryToUpdate, ct);

            if (string.IsNullOrEmpty(defaultPath))
                throw new DirectoryNotFoundException("Exception with directory (not found)");

            categoryToUpdate.Image = defaultPath;
        }

        public async Task DeleteCategoryAsync(int id, CancellationToken ct)
        {
            var categoryToDelete = await _unitOfWork.CategoryRepository.GetByIdAsync(id, ct)
                                ?? throw new CategoryArgumentException("Category with this id not exist");

            _unitOfWork.CategoryRepository.Delete(categoryToDelete);

            await _directoryService.DeleteFolderByPathAsync(GetPathOnlyFolders(categoryToDelete.Image), ct);

            await _unitOfWork.SaveAsync(ct);
        }

        private string GetPathOnlyFolders(string defaultPath)
        {
            int startIndex = defaultPath.IndexOf("Media") + "Media".Length;

            int endIndex = defaultPath.LastIndexOf("/");

            if (startIndex != -1 && endIndex != -1)
            {
                string folderPath = defaultPath.Substring(startIndex, endIndex - startIndex);
                return folderPath;
            }

            return defaultPath;
        }
    }
}
