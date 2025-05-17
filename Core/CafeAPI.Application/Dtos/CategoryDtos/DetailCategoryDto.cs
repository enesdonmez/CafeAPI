using CafeAPI.Application.Dtos.MenuItemDtos;

namespace CafeAPI.Application.Dtos.CategoryDtos;

public class DetailCategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<CategoriesMenuItemDto> MenuIems { get; set; }
}
