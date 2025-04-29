using CafeAPI.Application.Dtos.CategoryDtos;
using CafeAPI.Application.Dtos.ResponseDtos;

namespace CafeAPI.Application.Services.Abstract;

public interface ICategoryService
{
    Task<ResponseDto<List<ResultCategoryDto>>> GetAllCategories();
    Task<ResponseDto<DetailCategoryDto>> GetCategoryById(int id);
    Task CreateCategory(CreateCategoryDto createCategoryDto);
    Task UpdateCategory(UpdateCategoryDto updateCategoryDto);
    Task DeleteCategory(int id);
}
