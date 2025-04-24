namespace CafeAPI.Domain.Entities;

public class MenuItem : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Image { get; set; } 
    public bool IsAvailable { get; set; } 
    public int CategoryId { get; set; }
    public Category Category { get; set; } 
}
