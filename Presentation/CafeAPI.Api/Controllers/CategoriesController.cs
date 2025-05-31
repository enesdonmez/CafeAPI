using CafeAPI.Application.Dtos.CategoryDtos;
using CafeAPI.Application.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CafeAPI.Api.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategories();
            return CreateResponse(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
           return CreateResponse(category);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto createCategoryDto)
        {
            var result = await _categoryService.CreateCategory(createCategoryDto);
            return CreateResponse(result);
        }

        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryDto updateCategoryDto)
        {
            var result = await _categoryService.UpdateCategory(updateCategoryDto);
            return CreateResponse(result);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryService.DeleteCategory(id);
            return CreateResponse(result);
        }

        [HttpGet("categorieswithmenuitem")]
        public async Task<IActionResult> GetAllCategoriesWithMenuItems()
        {
            var categories = await _categoryService.GetAllCategoriesWithMenuItems();
            return CreateResponse(categories);
        }
    }
}
