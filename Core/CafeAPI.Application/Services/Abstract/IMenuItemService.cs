using CafeAPI.Application.Dtos.MenuItemDtos;

namespace CafeAPI.Application.Services.Abstract;

public interface IMenuItemService
{
    Task<List<ResultMenuItemDto>> GetAllMenuItems();
    Task<DetailMenuItemDto> GetMenuItemById(int id);
    Task CreateMenuItem(CreateMenuItemDto createMenuItemDto);
    Task UpdateMenuItem(UpdateMenuItemDto updateMenuItemDto);
    Task DeleteMenuItem(int id);
}
