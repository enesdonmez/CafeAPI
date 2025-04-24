namespace CafeAPI.Application.Dtos.MenuItemDtos;

public class CreateMenuItemDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Image { get; set; }
    public bool IsAvailable { get; set; }
    public int CategoryId { get; set; }
}
