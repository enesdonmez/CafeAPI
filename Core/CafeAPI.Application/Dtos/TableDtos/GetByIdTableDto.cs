namespace CafeAPI.Application.Dtos.TableDtos;

public class GetByIdTableDto
{
    public int Id { get; set; }
    public string TableNumber { get; set; }
    public int Capacity { get; set; }
    public bool IsActive { get; set; } 
}
