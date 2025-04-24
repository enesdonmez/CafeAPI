namespace CafeAPI.Application.Dtos.MenuItemDtos;

public class UpdateMenuItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Image { get; set; }
    public bool IsAvailable { get; set; }
    public int CategoryId { get; set; }
}
