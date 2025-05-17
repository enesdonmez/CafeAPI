using CafeAPI.Application.Dtos.CategoryDtos;
using CafeAPI.Application.Dtos.ResponseDtos;

namespace CafeAPI.Application.Services.Abstract;

public interface ICategoryService
{
    Task<ResponseDto<List<ResultCategoryDto>>> GetAllCategories();
    Task<ResponseDto<DetailCategoryDto>> GetCategoryById(int id);
    Task<ResponseDto<object>> CreateCategory(CreateCategoryDto createCategoryDto);
    Task<ResponseDto<object>> UpdateCategory(UpdateCategoryDto updateCategoryDto);
    Task<ResponseDto<object>> DeleteCategory(int id);
    Task<ResponseDto<List<ResultCategoryWithMenuItemDto>>> GetAllCategoriesWithMenuItems();
}
