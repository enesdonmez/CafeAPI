using CafeAPI.Application.Dtos.MenuItemDtos;
using CafeAPI.Application.Dtos.ResponseDtos;

namespace CafeAPI.Application.Services.Abstract;

public interface IMenuItemService
{
    Task<ResponseDto<List<ResultMenuItemDto>>> GetAllMenuItems();
    Task<ResponseDto<DetailMenuItemDto>> GetMenuItemById(int id);
    Task<ResponseDto<object>> CreateMenuItem(CreateMenuItemDto createMenuItemDto);
    Task<ResponseDto<object>> UpdateMenuItem(UpdateMenuItemDto updateMenuItemDto);
    Task<ResponseDto<object>> DeleteMenuItem(int id);
}
