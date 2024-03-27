using AutoMapper;
using Business.Interfaces;
using Business.Models.Categories;
using Business.Models.Ingredients.Request;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.CategoriesDto.Request;
using WebApi.Models.CategoriesDto.Response;
using WebApi.Models.IngredientsDto.Request;
using WebApi.Models.IngredientsDto.Response;
using WebApi.Utilities;

namespace WebApi.Controllers
{
    public class IngredientController : CustomControllerBase
    {
        private readonly IIngredientService _ingredientService;
        private readonly IMapper _mapper; 
        private readonly ILogger<IngredientController> _logger;

        public IngredientController(IIngredientService ingredientService, IMapper mapper, ILogger<IngredientController> logger)
        {
            _ingredientService = ingredientService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost("create")]
        public async Task<ActionResult<IngredientDto>> CreateIngredient([FromForm]CreateIngredientDto model, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Post, Create Ingredient, Task started", nameof(IngredientController), nameof(CreateIngredient));

            var mappedIngredient = _mapper.Map<CreateIngredientModel>(model);

            var result = await _ingredientService.CreateIngredientAsync(mappedIngredient, ct);

            var mappedResult = _mapper.Map<IngredientDto>(result);

            _logger.LogInformation("{controller}.{method} - Post, Create Ingredient, Result - Ok, Task ended", nameof(IngredientController), nameof(CreateIngredient));

            return Ok(mappedResult);
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<IngredientDto>>> GetIngredients(CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Get, get all ingredients, Task started", 
                nameof(IngredientController), nameof(GetIngredients));
            
            var result = await _ingredientService.GetAllIngredientsAsync(ct);

            var mappedResult = _mapper.Map<IEnumerable<IngredientDto>>(result);

            _logger.LogInformation("{controller}.{method} - Get, get all ingredients, Result - Ok, Task ended", 
                nameof(IngredientController), nameof(GetIngredients));

            return Ok(mappedResult);
        }

        [HttpPut("update")]
        public async Task<ActionResult<IngredientDto>> UpdateIIngredient([FromQuery] UpdateIngredientDto model, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Post, Update Ingredient, Task started",
                nameof(IngredientController), nameof(UpdateIIngredient));

            var mappedModel = _mapper.Map<UpdateIngredientModel>(model);

            var result = await _ingredientService.UpdateIngredientAsync(mappedModel, ct);

            var mappedResult = _mapper.Map<IngredientDto>(result);

            _logger.LogInformation("{controller}.{method} - Post, Update Ingredient, Result - Ok, Task ended", 
                nameof(IngredientController), nameof(UpdateIIngredient));

            return Ok(mappedResult);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteIngredient(int id, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Delete, delete ingredient, Task started", 
                nameof(IngredientController), nameof(DeleteIngredient));

            await _ingredientService.DeleteIngredientAsync(id, ct);

            _logger.LogInformation("{controller}.{method} - Delete, delete ingredient, Result - Ok, Task ended", 
                nameof(IngredientController), nameof(DeleteIngredient));

            return Ok($"Ingredient {id} - was deleted");
        }
    }
}
