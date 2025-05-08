using AutoMapper;
using CafeAPI.Application.Dtos.CategoryDtos;
using CafeAPI.Application.Dtos.ResponseDtos;
using CafeAPI.Application.Interfaces;
using CafeAPI.Application.Services.Abstract;
using CafeAPI.Domain.Entities;
using FluentValidation;

namespace CafeAPI.Application.Services.Concrete;

public class CategoryService : ICategoryService
{
    private readonly IGenericRepository<Category> _categoryRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateCategoryDto> _createCategoryValidator;
    private readonly IValidator<UpdateCategoryDto> _updateCategoryValidator;

    public CategoryService(IGenericRepository<Category> categoryRepository, IMapper mapper, IValidator<CreateCategoryDto> createCategoryValidator, IValidator<UpdateCategoryDto> updateCategoryValidator)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _createCategoryValidator = createCategoryValidator;
        _updateCategoryValidator = updateCategoryValidator;
    }

    public async Task<ResponseDto<object>> CreateCategory(CreateCategoryDto createCategoryDto)
    {
        try
        {
            var validationResult = await _createCategoryValidator.ValidateAsync(createCategoryDto);
            if (!validationResult.IsValid)
            {
                return new ResponseDto<object> {
                    IsSuccess = false, 
                    Message = string.Join(",",validationResult.Errors.Select(x => x.ErrorMessage)),
                    ErrorCode = ErrorCodes.ValidationError
                };
            }
            var category = _mapper.Map<Category>(createCategoryDto);
            await _categoryRepository.AddAsync(category);
            return new ResponseDto<object> { IsSuccess = true, Data = category, Message = "Kategori Eklendi." };
        }
        catch (Exception ex)
        {
            return new ResponseDto<object> { IsSuccess = false, Message = "Bir hata oluştu.", ErrorCode = ErrorCodes.Exception };
        }

    }

    public async Task<ResponseDto<object>> DeleteCategory(int id)
    {
        try
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return new ResponseDto<object> { IsSuccess = false, Message = "Kategori Bulunamadı.", ErrorCode = ErrorCodes.NotFound };
            }
            await _categoryRepository.DeleteAsync(category);
            return new ResponseDto<object> { IsSuccess = true, Message = "Kategori Silindi." };
        }
        catch (Exception ex)
        {
            return new ResponseDto<object> { IsSuccess = false, Message = "Bir hata oluştu.", ErrorCode = ErrorCodes.Exception };
        }

    }

    public async Task<ResponseDto<List<ResultCategoryDto>>> GetAllCategories()
    {
        try
        {
            var categories = await _categoryRepository.GetAllAsync();
            if (categories.Count == 0)
            {
                return new ResponseDto<List<ResultCategoryDto>> { IsSuccess = false, Message = "Kategori Bulunamadı.", ErrorCode = ErrorCodes.NotFound };
            }
            var result = _mapper.Map<List<ResultCategoryDto>>(categories);
            return new ResponseDto<List<ResultCategoryDto>> { IsSuccess = true, Data = result };
        }
        catch (Exception ex)
        {
            return new ResponseDto<List<ResultCategoryDto>> { IsSuccess = false, Message = "Bir hata oluştu.", ErrorCode = ErrorCodes.Exception };
        }
    }

    public async Task<ResponseDto<DetailCategoryDto>> GetCategoryById(int id)
    {
        try
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return new ResponseDto<DetailCategoryDto> { IsSuccess = false, Message = "Kategori Bulunamadı.", ErrorCode = ErrorCodes.NotFound };
            }
            var result = _mapper.Map<DetailCategoryDto>(category);
            return new ResponseDto<DetailCategoryDto> { IsSuccess = true, Data = result };
        }
        catch (Exception e)
        {
            return new ResponseDto<DetailCategoryDto> { IsSuccess = false, Message = "Bir hata oluştu.", ErrorCode = ErrorCodes.Exception };
        }

    }

    public async Task<ResponseDto<object>> UpdateCategory(UpdateCategoryDto updateCategoryDto)
    {
        try
        {
            var validationResult = await _updateCategoryValidator.ValidateAsync(updateCategoryDto);
            if (!validationResult.IsValid)
            {
                return new ResponseDto<object>
                {
                    IsSuccess = false,
                    Message = string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage)),
                    ErrorCode = ErrorCodes.ValidationError
                };
            }
            var existingCategory = await _categoryRepository.GetByIdAsync(updateCategoryDto.Id);
            if (existingCategory == null)
            {
                return new ResponseDto<object> { IsSuccess = false, Message = "Kategori Bulunamadı.", ErrorCode = ErrorCodes.NotFound };
            }
            var category = _mapper.Map(updateCategoryDto , existingCategory);
            await _categoryRepository.UpdateAsync(category);
            return new ResponseDto<object> { IsSuccess = true, Data = category, Message = "Kategori Güncellendi." };
        }
        catch (Exception ex)
        {
            return new ResponseDto<object> { IsSuccess = false, Message = "Bir hata oluştu.", ErrorCode = ErrorCodes.Exception };
        }

    }
}
