using AutoMapper;
using Business.Interfaces;
using Business.Models.Dishes;
using Business.Models.Filter;
using Business.Models.Pagination;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.PaginationsDto;
using WebApi.Models.DishesDto.Request;
using WebApi.Models.DishesDto.Response;
using WebApi.Utilities;

namespace WebApi.Controllers
{
    public class DishController : CustomControllerBase
    {
        private readonly IDishService _dishService;
        private readonly IMapper _mapper;
        private readonly ILogger<DishController> _logger;

        public DishController(IDishService Disheservice, IMapper mapper, ILogger<DishController> logger)
        {
            _dishService = Disheservice;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost("add")]
        public async Task<ActionResult<DishDto>> CreateDish(AddDishDto model, CancellationToken ct)
        {
            var mappedModel = _mapper.Map<AddDishModel>(model);
            var dish = await _dishService.AddDishAsync(mappedModel, ct);
            var mappedDish = _mapper.Map<DishDto>(dish);
            return Ok(mappedDish);
        }

        /// <summary>
        /// Method in controller for get Dish with id from db
        /// </summary>
        /// <param name="dishId">int if dor search in bd</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>returned model with data from db or problem</returns>
        [HttpGet("by-id")]
        public async Task<ActionResult<DishDto>> GetDishByIdAsync(int dishId, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - get Dish method with id in controller, Task started", 
                nameof(DishController), nameof(GetDishByIdAsync));
            var dish = await _dishService.GetDishByIdAsync(dishId, ct);
            var mappedDish = _mapper.Map<DishDto>(dish);
            _logger.LogInformation("{controller}.{method} - get Dish method with id, Result - Ok, Task ended", 
                nameof(DishController), nameof(GetDishByIdAsync));
            return Ok(mappedDish);
        }

        [HttpGet("by-category-id")]
        public async Task<ActionResult<PagedDishDto>> GetDishByCategoryAsync(int categoryId, [FromQuery]PaginationDto model, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Get paged Dishes by category, Task started,", nameof(DishController), nameof(GetDishByCategoryAsync));

            var mappedModel = _mapper.Map<PaginationModel>(model);
            var result = await _dishService.GetDishesByCategoryAsync(categoryId, mappedModel, ct);

            var mappedResult = _mapper.Map<PagedDishDto>(result);
            _logger.LogInformation("{controller}.{method} - Get paged Dishes by category, Result - Ok, Task ended", nameof(DishController), nameof(GetDishByCategoryAsync));
            return Ok(mappedResult);
        }

        [HttpGet("filtered")]
        public async Task<ActionResult<PagedDishDto>> GetFilteredDishAsync([FromQuery]DishFilterDto filter, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Get paged Dishes by query filter, Task started,", nameof(DishController), nameof(GetFilteredDishAsync));

            var mappedFilter = _mapper.Map<FilterModel>(filter);
            var result = await _dishService.GetFilteredDishesAsync(mappedFilter, ct);

            var mappedResult = _mapper.Map<PagedDishDto>(result);
            _logger.LogInformation("{controller}.{method} - Get paged Dishes by query filter, Result - Ok, Task ended", nameof(DishController), nameof(GetFilteredDishAsync));
            return Ok(mappedResult);
        }

        [HttpPut("update")]
        public async Task<ActionResult<DishModel>> UpdateDishAsync([FromForm] UpdateDishDto model, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Update Dish (FromForm), Task started,", nameof(DishController), 
                nameof(UpdateDishAsync));

            var mappedFilter = _mapper.Map<UpdateDishModel>(model);
            var dish = await _dishService.UpdateDishAsync(mappedFilter, ct);

            var mappedDish = _mapper.Map<DishDto>(dish);
            _logger.LogInformation("{controller}.{method} - Update Dish (FromForm), Result - Ok, Task ended", 
                nameof(DishController), nameof(UpdateDishAsync));
            return Ok(mappedDish);
        }

        [HttpDelete("by-id")]
        public async Task<IActionResult> DeleteDishAsync(int dishId, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Delete Dish by id, Task started,", nameof(DishController),
                nameof(DeleteDishAsync));
            
            await _dishService.DeleteDishByIdAsync(dishId, ct);

            _logger.LogInformation("{controller}.{method} - Delete Dish by id, Result - Ok, Task ended",
                nameof(DishController), nameof(DeleteDishAsync));
            return Ok($"Dish {dishId} was deleted");
        }
    }
}
