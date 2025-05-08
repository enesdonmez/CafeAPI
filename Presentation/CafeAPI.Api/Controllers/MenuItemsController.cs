using CafeAPI.Application.Dtos.MenuItemDtos;
using CafeAPI.Application.Dtos.ResponseDtos;
using CafeAPI.Application.Services.Abstract;
using CafeAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CafeAPI.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MenuItemsController : BaseController
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
           return CreateResponse(menuItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuItemById(int id)
        {
            var menuItem = await _menuItemService.GetMenuItemById(id);
            return CreateResponse(menuItem);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenuItem([FromBody] CreateMenuItemDto createMenuItemDto)
        {
           var result = await _menuItemService.CreateMenuItem(createMenuItemDto);
            return CreateResponse(result);
        }

        [HttpPut("UpdateMenuItem")]
        public async Task<IActionResult> UpdateMenuItem([FromBody] UpdateMenuItemDto updateMenuItemDto)
        {
            var result = await _menuItemService.UpdateMenuItem(updateMenuItemDto);
            return CreateResponse(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            var result = await _menuItemService.DeleteMenuItem(id);
            return CreateResponse(result);
        }
    }
}
