namespace CafeAPI.Domain.Entities;

public class User : BaseEntity
{
   public string AppUserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Role { get; set; }
}
