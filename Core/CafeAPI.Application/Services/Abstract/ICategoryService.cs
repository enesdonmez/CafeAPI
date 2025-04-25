using CafeAPI.Application.Dtos.CategoryDtos;

namespace CafeAPI.Application.Services.Abstract;

public interface ICategoryService
{
    Task<List<ResultCategoryDto>> GetAllCategories();
    Task<DetailCategoryDto> GetCategoryById(int id);
    Task CreateCategory(CreateCategoryDto createCategoryDto);
    Task UpdateCategory(UpdateCategoryDto updateCategoryDto);
    Task DeleteCategory(int id);
}
