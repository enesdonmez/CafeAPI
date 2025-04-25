using AutoMapper;
using CafeAPI.Application.Dtos.CategoryDtos;
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

    public async Task<List<ResultCategoryDto>> GetAllCategories()
    {
        var categories = await _categoryRepository.GetAllAsync();
        var result = _mapper.Map<List<ResultCategoryDto>>(categories);
        return result;
    }

    public async Task<DetailCategoryDto> GetCategoryById(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        var result = _mapper.Map<DetailCategoryDto>(category);
        return result;
    }

    public async Task UpdateCategory(UpdateCategoryDto updateCategoryDto)
    {
        var category = _mapper.Map<Category>(updateCategoryDto);
        await _categoryRepository.UpdateAsync(category);
    }
}
