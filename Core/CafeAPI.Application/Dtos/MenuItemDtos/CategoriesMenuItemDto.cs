using CafeAPI.Application.Dtos.CategoryDtos;

namespace CafeAPI.Application.Dtos.MenuItemDtos
{
    public class CategoriesMenuItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public bool IsAvailable { get; set; }
    }
}
