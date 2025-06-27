using CafeAPI.Application.Dtos.CategoryDtos;
using CafeAPI.Application.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;

namespace CafeAPI.Api.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(ICategoryService categoryService, ILogger<CategoriesController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        [EndpointDescription("Kategorileri getirir.")]
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            _logger.LogInformation("GetAllCategories endpoint called");

            var categories = await _categoryService.GetAllCategories();

            _logger.LogInformation("GetAllCategories: Categories={Categories}, Count={Count}",JsonConvert.SerializeObject(categories.Data),categories.Data.Count());


            return CreateResponse(categories);
        }

        [EndpointDescription("Kategorileri getirir.")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            return CreateResponse(category);
        }

        [EndpointDescription("Kategori oluşturur.")]
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto createCategoryDto)
        {
            var result = await _categoryService.CreateCategory(createCategoryDto);
            return CreateResponse(result);
        }

        [EndpointDescription("Kategoriyi günceller.")]
        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryDto updateCategoryDto)
        {
            var result = await _categoryService.UpdateCategory(updateCategoryDto);
            return CreateResponse(result);
        }

        [EndpointDescription("Kategori siler.")]
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryService.DeleteCategory(id);
            return CreateResponse(result);
        }

        [EndpointDescription("Kategorileri menü itemlerine ile birlikte getirir.")]
        [HttpGet("categorieswithmenuitem")]
        public async Task<IActionResult> GetAllCategoriesWithMenuItems()
        {
            var categories = await _categoryService.GetAllCategoriesWithMenuItems();
            return CreateResponse(categories);
        }
    }
}
