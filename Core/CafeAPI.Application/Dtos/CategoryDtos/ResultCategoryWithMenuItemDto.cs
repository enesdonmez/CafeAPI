using CafeAPI.Application.Dtos.MenuItemDtos;

namespace CafeAPI.Application.Dtos.CategoryDtos
{
    public class ResultCategoryWithMenuItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CategoriesMenuItemDto> MenuItems { get; set; } 
    }
}
