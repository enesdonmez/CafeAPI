using CafeAPI.Application.Dtos.MenuItemDtos;
using CafeAPI.Application.Dtos.ResponseDtos;
using CafeAPI.Application.Services.Abstract;
using CafeAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CafeAPI.Api.Controllers
{
    [Route("api/[controller]/[action]")]
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
            if (!menuItems.IsSuccess)
            {
                if (menuItems.ErrorCodes == ErrorCodes.NotFound)
                    return NotFound(menuItems);
                return BadRequest(menuItems);
            }
            return Ok(menuItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuItemById(int id)
        {
            var menuItem = await _menuItemService.GetMenuItemById(id);
            if (!menuItem.IsSuccess)
            {
                if (menuItem.ErrorCodes == ErrorCodes.NotFound)
                    return NotFound(menuItem);
                return BadRequest(menuItem);
            }
            return Ok(menuItem);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenuItem([FromBody] CreateMenuItemDto createMenuItemDto)
        {
           var result = await _menuItemService.CreateMenuItem(createMenuItemDto);
            if (!result.IsSuccess)
            {
                if (result.ErrorCodes == ErrorCodes.NotFound)
                    return NotFound(result);
                return BadRequest(result);
            }
            return Ok("Menü öğesi oluşturuldu.");
        }

        [HttpPut("UpdateMenuItem")]
        public async Task<IActionResult> UpdateMenuItem([FromBody] UpdateMenuItemDto updateMenuItemDto)
        {
            var result = await _menuItemService.UpdateMenuItem(updateMenuItemDto);
            if (!result.IsSuccess)
            {
                if (result.ErrorCodes == ErrorCodes.NotFound)
                    return NotFound(result);
                return BadRequest(result);
            }
            return Ok("Menü öğesi güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            var result = await _menuItemService.DeleteMenuItem(id);
            if (!result.IsSuccess)
            {
                if (result.ErrorCodes == ErrorCodes.NotFound)
                    return NotFound(result);
                return BadRequest(result);
            }
            return Ok("Menü öğesi silindi.");
        }
    }
}
