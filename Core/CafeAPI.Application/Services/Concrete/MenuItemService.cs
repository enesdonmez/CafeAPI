using AutoMapper;
using CafeAPI.Application.Dtos.MenuItemDtos;
using CafeAPI.Application.Interfaces;
using CafeAPI.Application.Services.Abstract;
using CafeAPI.Domain.Entities;

namespace CafeAPI.Application.Services.Concrete;

public class MenuItemService : IMenuItemService
{
    private readonly IGenericRepository<MenuItem> _menuItemRepository;
    private readonly IMapper _mapper;

    public MenuItemService(IGenericRepository<MenuItem> menuItemRepository, IMapper mapper)
    {
        _menuItemRepository = menuItemRepository;
        _mapper = mapper;
    }

    public async Task CreateMenuItem(CreateMenuItemDto createMenuItemDto)
    {
        var menuItem = _mapper.Map<MenuItem>(createMenuItemDto);
        await _menuItemRepository.AddAsync(menuItem);
    }

    public async Task DeleteMenuItem(int id)
    {
        var menuItem = await _menuItemRepository.GetByIdAsync(id);
        await _menuItemRepository.DeleteAsync(menuItem);
    }

    public async Task<List<ResultMenuItemDto>> GetAllMenuItems()
    {
        var menuItems = await _menuItemRepository.GetAllAsync();
        var result = _mapper.Map<List<ResultMenuItemDto>>(menuItems);
        return result;
    }

    public async Task<DetailMenuItemDto> GetMenuItemById(int id)
    {
        var menuItem = await _menuItemRepository.GetByIdAsync(id);
        var result = _mapper.Map<DetailMenuItemDto>(menuItem);
        return result;
    }

    public async Task UpdateMenuItem(UpdateMenuItemDto updateMenuItemDto)
    {
        var menuItem = _mapper.Map<MenuItem>(updateMenuItemDto);
        await _menuItemRepository.UpdateAsync(menuItem);
    }
}
