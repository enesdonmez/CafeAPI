using CafeAPI.Application.Dtos.MenuItemDtos;
using CafeAPI.Application.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CafeAPI.Api.Controllers
{
    [Route("api/menuitems")]
    [ApiController]
    public class MenuItemsController(IMenuItemService _menuItemService) : BaseController
    {

        [EndpointDescription("Menüyü getirir.")]
        [HttpGet]
        public async Task<IActionResult> GetAllMenuItems()
        {
            var menuItems = await _menuItemService.GetAllMenuItems();
            return CreateResponse(menuItems);
        }

        [EndpointDescription("Menüdeki ürünü Id ye göre getirir.")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuItemById(int id)
        {
            var menuItem = await _menuItemService.GetMenuItemById(id);
            return CreateResponse(menuItem);
        }

        [EndpointDescription("Menüye ürün ekler.")]
        [Authorize(Roles = "user")]
        [HttpPost]
        public async Task<IActionResult> CreateMenuItem([FromBody] CreateMenuItemDto createMenuItemDto)
        {
            var result = await _menuItemService.CreateMenuItem(createMenuItemDto);
            return CreateResponse(result);
        }

        [EndpointDescription("Menüdeki ürünü günceller.")]
        [Authorize(Roles = "user")]
        [HttpPut]
        public async Task<IActionResult> UpdateMenuItem([FromBody] UpdateMenuItemDto updateMenuItemDto)
        {
            var result = await _menuItemService.UpdateMenuItem(updateMenuItemDto);
            return CreateResponse(result);
        }

        [EndpointDescription("Menüdeki ürünü Id ye göre siler.")]
        [Authorize(Roles = "user")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            var result = await _menuItemService.DeleteMenuItem(id);
            return CreateResponse(result);
        }
    }
}
