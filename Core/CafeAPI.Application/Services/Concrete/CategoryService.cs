using AutoMapper;
using CafeAPI.Application.Dtos.CategoryDtos;
using CafeAPI.Application.Dtos.ResponseDtos;
using CafeAPI.Application.Interfaces;
using CafeAPI.Application.Services.Abstract;
using CafeAPI.Domain.Entities;

namespace CafeAPI.Application.Services.Concrete;

public class CategoryService : ICategoryService
{
    private readonly IGenericRepository<Category> _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(IGenericRepository<Category> categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task CreateCategory(CreateCategoryDto createCategoryDto)
    {
        var category = _mapper.Map<Category>(createCategoryDto);
        await _categoryRepository.AddAsync(category);
    }

    public async Task DeleteCategory(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        await _categoryRepository.DeleteAsync(category);
    }

    public async Task<ResponseDto<List<ResultCategoryDto>>> GetAllCategories()
    {
        try
        {
            var categories = await _categoryRepository.GetAllAsync();
            if (categories.Count == 0)
            {
                return new ResponseDto<List<ResultCategoryDto>> { IsSuccess = false, Message = "Kategori Bulunamadı.", ErrorCodes = ErrorCodes.NotFound };
            }
            var result = _mapper.Map<List<ResultCategoryDto>>(categories);
            return new ResponseDto<List<ResultCategoryDto>> { IsSuccess = true, Data = result };
        }
        catch (Exception ex)
        {
            return new ResponseDto<List<ResultCategoryDto>> { IsSuccess = false, Message = ex.Message, ErrorCodes = ErrorCodes.Exception };   
        }
    }

    public async Task<ResponseDto<DetailCategoryDto>> GetCategoryById(int id)
    {
        try
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return new ResponseDto<DetailCategoryDto> { IsSuccess = false, Message = "Kategori Bulunamadı.", ErrorCodes = ErrorCodes.NotFound };
            }
            var result = _mapper.Map<DetailCategoryDto>(category);
            return new ResponseDto<DetailCategoryDto> { IsSuccess = true, Data = result };
        }
        catch (Exception e)
        {
            return new ResponseDto<DetailCategoryDto> { IsSuccess = false, Message = e.Message, ErrorCodes = ErrorCodes.Exception };
        }

    }

    public async Task UpdateCategory(UpdateCategoryDto updateCategoryDto)
    {
        var category = _mapper.Map<Category>(updateCategoryDto);
        await _categoryRepository.UpdateAsync(category);
    }
}
