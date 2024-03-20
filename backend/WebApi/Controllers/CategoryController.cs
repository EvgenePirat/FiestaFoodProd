using AutoMapper;
using Business.Interfaces;
using Business.Models.Categories;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.CategoriesDto.Request;
using WebApi.Models.CategoriesDto.Response;
using WebApi.Utilities;

namespace WebApi.Controllers
{
    public class CategoryController : CustomControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper; 
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryService categoryService, IMapper mapper, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost("create")]
        public async Task<ActionResult<CategoryDto>> CreateCategory([FromForm]CreateCategoryDto model, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Post, Create Category, Task started", nameof(CategoryController), nameof(CreateCategory));

            var mappedCategory = _mapper.Map<CreateCategoryModel>(model);

            var result = await _categoryService.CreateCategoryAsync(mappedCategory, ct);

            var mappedResult = _mapper.Map<CategoryDto>(result);

            _logger.LogInformation("{controller}.{method} - Post, Create Category, Result - Ok, Task ended", nameof(CategoryController), nameof(CreateCategory));

            return Ok(mappedResult);
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories(CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Get, get all categories, Task started", 
                nameof(CategoryController), nameof(GetCategories));
            
            var result = await _categoryService.GetAllCategoriesAsync(ct);

            var mappedResult = _mapper.Map<IEnumerable<CategoryDto>>(result);
            _logger.LogInformation("{controller}.{method} - Get, get all categories, Result - Ok, Task ended", 
                nameof(CategoryController), nameof(GetCategories));
            return Ok(mappedResult);
        }

        [HttpPut("update")]
        public async Task<ActionResult<CategoryDto>> UpdateCategory([FromQuery] UpdateCategoryDto model, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Post, Update Category, Task started",
                nameof(CategoryController), nameof(UpdateCategory));

            var mappedModel = _mapper.Map<UpdateCategoryModel>(model);

            var result = await _categoryService.UpdateCategoryAsync(mappedModel, ct);

            var mappedResult = _mapper.Map<CategoryDto>(result);

            _logger.LogInformation("{controller}.{method} - Post, Update Category, Result - Ok, Task ended", 
                nameof(CategoryController), nameof(UpdateCategory));
            return Ok(mappedResult);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteCategory(int id, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Delete, delete category, Task started", 
                nameof(CategoryController), nameof(DeleteCategory));

            await _categoryService.DeleteCategoryAsync(id, ct);

            _logger.LogInformation("{controller}.{method} - Delete, delete category, Result - Ok, Task ended", 
                nameof(CategoryController), nameof(DeleteCategory));
            return Ok($"Category {id} - was deleted");
        }
    }
}
