using CafeAPI.Domain.Entities;

namespace CafeAPI.Application.Interfaces
{
    public interface ITableRepository
    {
        Task<Table> GetByTableNumberAsync(int tableNumber);
        Task<List<Table>> GetAllActiveTablesAsync();
    }
}
