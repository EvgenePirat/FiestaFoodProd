﻿using AutoMapper;
using Business.Interfaces;
using Business.Models.Dishes.Request;
using Business.Models.Dishes.Response;
using Business.Models.DishIngredients.Request;
using Business.Models.Filter;
using Business.Models.Pagination;
using CustomExceptions.CategoryCustomExceptions;
using CustomExceptions.DishCustomExceptions;
using DataAccess.Interfaces;
using DataAccess.Utilities;
using Entities.Entities;
using FileStorageHandler.Interfaces;
using FileStorageHandler.Services;
using Microsoft.AspNetCore.Http;

namespace Business.Services
{
    public class DishService : IDishService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDirectoryService _directoryService;
        private readonly IFileService _fileService;
        private readonly IMediaHandlerService _mediaHandlerService;

        public DishService(IUnitOfWork unitOfWork,IMapper mapper, IDirectoryService directoryService, IFileService fileService, IMediaHandlerService mediaHandlerService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _directoryService = directoryService;
            _fileService = fileService;
            _mediaHandlerService = mediaHandlerService;
        }

        public async Task<DishModel> AddDishAsync(AddDishModel model, CancellationToken ct)
        {
            var mappedModel = await CheckDishEntityExist(model, ct);

            var defaultPath = await _directoryService.GetDefaultPathAsync(mappedModel, ct);

            if (model.File is not null)
            {
                List<IFormFile> files = new List<IFormFile> { model.File };
                await _fileService.UploadFilesAsync(files, defaultPath, ct);
            }

            mappedModel.Image = await _mediaHandlerService.GetPhotoByPathAsync(defaultPath, ct);

            _unitOfWork.DishRepository.Add(mappedModel);

            await _unitOfWork.SaveAsync(ct);

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

        public async Task<DishModel> UpdateDishAsync(int id, UpdateDishModel model, CancellationToken ct)
        {
            var dishToUpdate = await CheckDishEntityExist(id, model, ct);
            var dishName = dishToUpdate.Title;
            var defaultPath = string.IsNullOrEmpty(dishToUpdate.Image)
                ? await _directoryService.GetDefaultPathAsync(dishToUpdate, ct)
                : dishToUpdate.Image;

            if (dishToUpdate.Title != model.Name)
            {
                await _directoryService.RenameFolderAsync(defaultPath, model.Name, ct);
                dishToUpdate.Title = model.Name;

                // Get new default path for Dish
                defaultPath = await _directoryService.GetDefaultPathAsync(dishToUpdate, ct);
                if (string.IsNullOrEmpty(defaultPath))
                    throw new DirectoryNotFoundException("Exception with directory (not found)");
                dishToUpdate.Image = defaultPath;
            }

            dishToUpdate.Price = model.Price;
            dishToUpdate.CategoryId = model.CategoryId;

            try
            {
                _unitOfWork.DishRepository.Update(dishToUpdate);
                await _unitOfWork.SaveAsync(ct);
                if (model.File is not null)
                {
                    List<IFormFile> files = new List<IFormFile> { model.File };
                    await _fileService.UploadFilesAsync(files, defaultPath, ct);
                }
            }
            catch
            {
                if (dishToUpdate.Title != model.Name)
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

            await _directoryService.DeleteFolderByPathAsync(Dish.Image, ct);

            await _unitOfWork.SaveAsync(ct);
        }

        private async Task<Dish> CheckDishEntityExist(AddDishModel model, CancellationToken ct)
        {
            var mappedModel = _mapper.Map<Dish>(model);
            mappedModel.DishIngredients = _mapper.Map<IEnumerable<DishIngredient>>(model.DishIngridients);

            mappedModel.Category = await _unitOfWork.CategoryRepository.GetByIdAsync(model.CategoryId, ct)
                                   ?? throw new CategoryArgumentException($"Category with this {model.CategoryId} not exist");

            return mappedModel;
        }

        private async Task<Dish> CheckDishEntityExist(int id, UpdateDishModel model, CancellationToken ct)
        {
            var dish = await _unitOfWork.DishRepository.GetDishById(id, ct)
                                  ?? throw new DishArgumentException("Dish with this id not found");

            dish.Category = await _unitOfWork.CategoryRepository.GetByIdAsync(model.CategoryId, ct)
                            ?? throw new CategoryArgumentException($"Category with this {model.CategoryId} not exist");

            return dish;
        }

        public async Task UpdateDishIngredientsForDishAsync(int dishId, List<UpdateDishIngredientModel> model, CancellationToken ct)
        {
            var dish = await _unitOfWork.DishRepository.GetDishById(dishId, ct)
                      ?? throw new DishArgumentException("Dish with this id not found");


            foreach (var dishIngredientModel in model)
            {
                foreach (var elem in dish.DishIngredients)
                {
                    if (elem.IngredientId == dishIngredientModel.IngredientId)
                    {
                        elem.Count = dishIngredientModel.Count;
                        _unitOfWork.DishIngredientRepository.Update(elem);
                    }
                    else
                    {
                        var dishIngredient = _mapper.Map<DishIngredient>(dishIngredientModel);
                        dishIngredient.DishId = dishId;
                        _unitOfWork.DishIngredientRepository.Add(dishIngredient);
                    }
                }
            }

            await _unitOfWork.SaveAsync(ct);
        }

        public async Task<IEnumerable<DishModel>> GetAllDishesAsync(CancellationToken ct)
        {
            var dishes = await _unitOfWork.DishRepository.GetAllAsync(ct);

            return _mapper.Map<IEnumerable<DishModel>>(dishes);
        }
    }
}
