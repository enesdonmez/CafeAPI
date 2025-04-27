using CafeAPI.Application.Dtos.MenuItemDtos;
using CafeAPI.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CafeAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemsController : ControllerBase
    {
        private readonly IMenuItemService _menuItemService;

        public MenuItemsController(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        [HttpGet("GetAllMenuItem")]
        public async Task<IActionResult> GetAllMenuItems()
        {
            var menuItems = await _menuItemService.GetAllMenuItems();
            return Ok(menuItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuItemById(int id)
        {
            var menuItem = await _menuItemService.GetMenuItemById(id);
            return Ok(menuItem);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenuItem([FromBody] CreateMenuItemDto createMenuItemDto)
        {
            await _menuItemService.CreateMenuItem(createMenuItemDto);
            return Ok("Menü öğesi oluşturuldu.");
        }

        [HttpPut("UpdateMenuItem")]
        public async Task<IActionResult> UpdateMenuItem([FromBody] UpdateMenuItemDto updateMenuItemDto)
        {
            await _menuItemService.UpdateMenuItem(updateMenuItemDto);
            return Ok("Menü öğesi güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            await _menuItemService.DeleteMenuItem(id);
            return Ok("Menü öğesi silindi.");
        }
    }
}
