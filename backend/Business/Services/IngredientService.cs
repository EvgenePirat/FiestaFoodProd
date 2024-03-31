using AutoMapper;
using Business.Interfaces;
using Business.Models.Ingredients.Request;
using Business.Models.Ingredients.Response;
using CustomExceptions.IngredientCustomException;
using DataAccess.Interfaces;
using Entities.Entities;

namespace Business.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public IngredientService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IngredientModel> CreateIngredientAsync(CreateIngredientModel model, CancellationToken ct)
        {
            var mappedEntity = _mapper.Map<Ingredient>(model);

            var ingredientExist = await _unitOfWork.IngredientsRepository.GetByNameAsync(model.Name, ct);

            if (ingredientExist != null)
                throw new IngredientArgumentException("Ingredint with name already exist");

            _unitOfWork.IngredientsRepository.Add(mappedEntity);

            await _unitOfWork.SaveAsync(ct);

            return _mapper.Map<IngredientModel>(mappedEntity);
        }

        public async Task DeleteIngredientAsync(int id, CancellationToken ct)
        {
            var ingredientToDelete = await _unitOfWork.IngredientsRepository.GetByIdAsync(id, ct)
                                                ?? throw new IngredientArgumentException("Ingredient with id not exist");

            _unitOfWork.IngredientsRepository.Delete(ingredientToDelete);

            await _unitOfWork.SaveAsync(ct);
        }

        public async Task<IEnumerable<IngredientModel>> GetAllIngredientsAsync(CancellationToken ct)
        {
            var ingredients = await _unitOfWork.IngredientsRepository.GetAllAsync(ct);
            return _mapper.Map<IEnumerable<IngredientModel>>(ingredients);
        }

        public async Task<IngredientModel> UpdateIngredientAsync(int id, UpdateIngredientModel model, CancellationToken ct)
        {
            var ingredientToUpdate = await _unitOfWork.IngredientsRepository.GetByIdAsync(id, ct)
                                               ?? throw new IngredientArgumentException("Ingredient with id not exist");

            ingredientToUpdate.Name = model.Name;
            ingredientToUpdate.Importance = (Entities.Enums.Importance)model.Importance;
            ingredientToUpdate.Quantity.Count = model.Quantity.Count;
            ingredientToUpdate.Quantity.Measurement = (Entities.Enums.Measurement)model.Quantity.Measurement;

            _unitOfWork.IngredientsRepository.Update(ingredientToUpdate);

            await _unitOfWork.SaveAsync(ct);

            return _mapper.Map<IngredientModel>(ingredientToUpdate);
        }
    }
}
