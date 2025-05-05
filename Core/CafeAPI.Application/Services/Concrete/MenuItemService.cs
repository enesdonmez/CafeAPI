using AutoMapper;
using CafeAPI.Application.Dtos.MenuItemDtos;
using CafeAPI.Application.Dtos.ResponseDtos;
using CafeAPI.Application.Interfaces;
using CafeAPI.Application.Services.Abstract;
using CafeAPI.Domain.Entities;
using FluentValidation;

namespace CafeAPI.Application.Services.Concrete;

public class MenuItemService : IMenuItemService
{
    private readonly IGenericRepository<MenuItem> _menuItemRepository;
    private readonly IGenericRepository<Category> _categoryRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateMenuItemDto> _createMenuItemValidator;
    private readonly IValidator<UpdateMenuItemDto> _updateMenuItemValidator;

    public MenuItemService(IGenericRepository<MenuItem> menuItemRepository, IMapper mapper, IValidator<CreateMenuItemDto> createMenuItemValidator, IValidator<UpdateMenuItemDto> updateMenuItemValidator, IGenericRepository<Category> categoryRepository)
    {
        _menuItemRepository = menuItemRepository;
        _mapper = mapper;
        _createMenuItemValidator = createMenuItemValidator;
        _updateMenuItemValidator = updateMenuItemValidator;
        _categoryRepository = categoryRepository;
    }

    public async Task<ResponseDto<object>> CreateMenuItem(CreateMenuItemDto createMenuItemDto)
    {
        try
        {
            var validate = await _createMenuItemValidator.ValidateAsync(createMenuItemDto);
            if (!validate.IsValid)
            {
                return new ResponseDto<object>
                {
                    IsSuccess = false,
                    Message = string.Join(",", validate.Errors.Select(x => x.ErrorMessage)),
                    ErrorCodes = ErrorCodes.ValidationError
                };
            }
            var menuItem = _mapper.Map<MenuItem>(createMenuItemDto);
            await _menuItemRepository.AddAsync(menuItem);
            return new ResponseDto<object> { IsSuccess = true, Data = menuItem, Message = "Menü Öğesi Eklendi." };
        }
        catch (Exception)
        {
            return new ResponseDto<object> { IsSuccess = false, Message = "Bir hata oluştu.", ErrorCodes = ErrorCodes.Exception };
        }

    }

    public async Task<ResponseDto<object>> DeleteMenuItem(int id)
    {
        var existsmenuItem = await _menuItemRepository.GetByIdAsync(id);
        if (existsmenuItem == null)
        {
            return new ResponseDto<object> { IsSuccess = false, Message = "Menü öğesi Bulunamadı.", ErrorCodes = ErrorCodes.NotFound };
        }
        var menuItem = await _menuItemRepository.GetByIdAsync(id);
        await _menuItemRepository.DeleteAsync(menuItem);
        return new ResponseDto<object> { IsSuccess = true, Message = "Menü Öğesi Silindi." };

    }

    public async Task<ResponseDto<List<ResultMenuItemDto>>> GetAllMenuItems()
    {
        try
        {
            var menuItems = await _menuItemRepository.GetAllAsync();
            var categories = await _categoryRepository.GetAllAsync();
            if (menuItems.Count == 0)
            {
                return new ResponseDto<List<ResultMenuItemDto>> { IsSuccess = false, Message = "Menü öğesi Bulunamadı.", ErrorCodes = ErrorCodes.NotFound };
            }
            var result = _mapper.Map<List<ResultMenuItemDto>>(menuItems);
            return new ResponseDto<List<ResultMenuItemDto>> { IsSuccess = true, Data = result };
        }
        catch (Exception)
        {
            return new ResponseDto<List<ResultMenuItemDto>> { IsSuccess = false, Message = "Bir hata oluştu.", ErrorCodes = ErrorCodes.Exception };
        }

    }

    public async Task<ResponseDto<DetailMenuItemDto>> GetMenuItemById(int id)
    {
        try
        {
            var menuItem = await _menuItemRepository.GetByIdAsync(id);
            var categories = await _categoryRepository.GetAllAsync();
            if (menuItem == null)
            {
                return new ResponseDto<DetailMenuItemDto> { IsSuccess = false, Message = "Menü öğesi Bulunamadı.", ErrorCodes = ErrorCodes.NotFound };
            }
            var result = _mapper.Map<DetailMenuItemDto>(menuItem);
            return new ResponseDto<DetailMenuItemDto> { IsSuccess = true, Data = result };
        }
        catch (Exception)
        {
            return new ResponseDto<DetailMenuItemDto> { IsSuccess = false, Message = "Bir hata oluştu.", ErrorCodes = ErrorCodes.Exception };
        }

    }

    public async Task<ResponseDto<object>> UpdateMenuItem(UpdateMenuItemDto updateMenuItemDto)
    {
        try
        {
            var validate = await _updateMenuItemValidator.ValidateAsync(updateMenuItemDto);
            if (!validate.IsValid)
            {
                return new ResponseDto<object>
                {
                    IsSuccess = false,
                    Message = string.Join(",", validate.Errors.Select(x => x.ErrorMessage)),
                    ErrorCodes = ErrorCodes.ValidationError
                };
            }
            var existingMenuItem = await _menuItemRepository.GetByIdAsync(updateMenuItemDto.Id);
            if (existingMenuItem == null)
            {
                return new ResponseDto<object> { IsSuccess = false, Message = "Menü Öğesi Bulunamadı.", ErrorCodes = ErrorCodes.NotFound };
            }
            var menuItem = _mapper.Map<MenuItem>(updateMenuItemDto);
            await _menuItemRepository.UpdateAsync(menuItem);
            return new ResponseDto<object> { IsSuccess = true, Data = menuItem, Message = "Menü Öğesi Güncellendi." };
        }
        catch (Exception)
        {
            return new ResponseDto<object> { IsSuccess = false, Message = "Bir hata oluştu.", ErrorCodes = ErrorCodes.Exception };
        }
       
    }
}
