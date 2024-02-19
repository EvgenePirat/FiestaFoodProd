using AutoMapper;
using Business.Interfaces;
using Business.Models.Dishes;
using Business.Models.Filter;
using Business.Models.Pagination;
using CustomExceptions.CategoryCustomExceptions;
using CustomExceptions.DishCustomExceptions;
using DataAccess.Interfaces;
using DataAccess.Utilities;
using Entities.Entities;
using FileStorageHandler.Interfaces;

namespace Business.Services
{
    public class DishService : IDishService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDirectoryService _directoryService;
        private readonly IFileService _fileService;

        public DishService(IUnitOfWork unitOfWork,IMapper mapper, IDirectoryService directoryService, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _directoryService = directoryService;
            _fileService = fileService;
        }

        public async Task<DishModel> AddDishAsync(AddDishModel model, CancellationToken ct)
        {
            var mappedModel = await CheckDishEntityExist(model, ct);

            // Initialize default defaultPath for Dish
            var defaultPath = await _directoryService.GetDefaultPathAsync(mappedModel, ct);
            // Create a folders by path
            await _directoryService.CreateFolderAsync(defaultPath, ct);

            mappedModel.PhotoPaths = defaultPath;
            _unitOfWork.DishRepository.Add(mappedModel);

            await _unitOfWork.SaveAsync(ct);

            if (model.Files is not null && model.Files.Any())
                await _fileService.UploadFilesAsync(model.Files, defaultPath, ct);
            return _mapper.Map<DishModel>(mappedModel);
        }

        /// <summary>
        /// Implementation business logic for get Dish with id
        /// </summary>
        /// <param name="id">Id for search in bd</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Returns Dish if exist or throw exception</returns>
        /// <exception cref="DishArgumentException">If Dish not found</exception>
        public async Task<DishModel> GetDishByIdAsync(int id, CancellationToken ct)
        {
            var Dish = await _unitOfWork.DishRepository.GetDishById(id, ct)
                          ?? throw new DishArgumentException("Dish with this id not found");
            var mappedDish = _mapper.Map<DishModel>(Dish);
            return mappedDish;
        }

        public async Task<PagedDishModel> GetDishesByCategoryAsync(int categoryId, PaginationModel model, CancellationToken ct)
        {
            var mappedModel = _mapper.Map<PaginationDb>(model);
            var result = await _unitOfWork.DishRepository.GetDishByCategory(categoryId, mappedModel, ct);

            return new PagedDishModel
            {
                Dishes = _mapper.Map<IEnumerable<DishModel>>(result.Result),
                TotalPages = result.TotalPages,
            };
        }

        public async Task<PagedDishModel> GetFilteredDishesAsync(FilterModel filter, CancellationToken ct)
        {
            var mappedFilter = _mapper.Map<FilterState>(filter);
            var result = await _unitOfWork.DishRepository.GetDishesByQueryAsync(mappedFilter, ct);
            
            return new PagedDishModel
            {
                Dishes = _mapper.Map<IEnumerable<DishModel>>(result.Result),
                TotalPages = result.TotalPages
            };
        }

        public async Task<DishModel> UpdateDishAsync(UpdateDishModel model, CancellationToken ct)
        {
            var dishToUpdate = await CheckDishEntityExist(model, ct);
            var dishName = dishToUpdate.Name;
            var defaultPath = string.IsNullOrEmpty(dishToUpdate.PhotoPaths)
                ? await _directoryService.GetDefaultPathAsync(dishToUpdate, ct)
                : dishToUpdate.PhotoPaths;

            if (dishToUpdate.Name != model.Name)
            {
                await _directoryService.RenameFolderAsync(defaultPath, model.Name, ct);
                dishToUpdate.Name = model.Name;

                // Get new default path for Dish
                defaultPath = await _directoryService.GetDefaultPathAsync(dishToUpdate, ct);
                if (string.IsNullOrEmpty(defaultPath))
                    throw new DirectoryNotFoundException("Exception with directory (not found)");
                dishToUpdate.PhotoPaths = defaultPath;
            }

            dishToUpdate.Description = model.Description;
            dishToUpdate.Price = model.Price;
            dishToUpdate.CategoryId = model.CategoryId;

            try
            {
                _unitOfWork.DishRepository.Update(dishToUpdate);
                await _unitOfWork.SaveAsync(ct);
                if (model.Files is not null && model.Files.Any())
                    await _fileService.UploadFilesAsync(model.Files, defaultPath, ct);
            }
            catch
            {
                if (dishToUpdate.Name != model.Name)
                    await _directoryService.RenameFolderAsync(defaultPath, dishName, ct);
                throw new DishArgumentException("An error occurred while updating the Dish.");
            }

            return _mapper.Map<DishModel>(dishToUpdate);;
        }

        public async Task DeleteDishByIdAsync(int id, CancellationToken ct)
        {
            var Dish = await _unitOfWork.DishRepository.GetDishById(id, ct)
                        ?? throw new DishArgumentException("Dish with this id not found");
            _unitOfWork.DishRepository.Delete(Dish);

            await _directoryService.DeleteFolderByPathAsync(Dish.PhotoPaths, ct);

            await _unitOfWork.SaveAsync(ct);
        }

        private async Task<Dish> CheckDishEntityExist(AddDishModel model, CancellationToken ct)
        {
            var mappedModel = _mapper.Map<Dish>(model);

            mappedModel.Category = await _unitOfWork.CategoryRepository.GetByIdAsync(model.CategoryId, ct)
                                   ?? throw new CategoryArgumentException($"Category with this {model.CategoryId} not exist");

            return mappedModel;
        }

        private async Task<Dish> CheckDishEntityExist(UpdateDishModel model, CancellationToken ct)
        {
            var Dish = await _unitOfWork.DishRepository.GetDishById(model.Id, ct)
                                  ?? throw new DishArgumentException("Dish with this id not found");

            Dish.Category = await _unitOfWork.CategoryRepository.GetByIdAsync(model.CategoryId, ct)
                            ?? throw new CategoryArgumentException($"Category with this {model.CategoryId} not exist");

            return Dish;
        }
    }
}
