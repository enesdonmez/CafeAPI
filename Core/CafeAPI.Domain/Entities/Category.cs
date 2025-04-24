namespace CafeAPI.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<MenuItems> MenuItems { get; set; }
    }
}
