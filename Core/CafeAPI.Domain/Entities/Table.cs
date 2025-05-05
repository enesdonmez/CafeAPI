namespace CafeAPI.Domain.Entities
{
    public class Table : BaseEntity
    {
        public string TableNumber { get; set; }
        public int Capacity { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
