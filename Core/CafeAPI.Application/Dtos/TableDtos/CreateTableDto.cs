namespace CafeAPI.Application.Dtos.TableDtos
{
    public class CreateTableDto
    {
        public int TableNumber { get; set; }
        public int Capacity { get; set; }
        public bool IsActive { get; set; } 
    }
}
