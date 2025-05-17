using CafeAPI.Domain.Entities;

namespace CafeAPI.Application.Interfaces
{
    public interface IMenuItemRepository
    {
        Task<List<MenuItem>> GetMenuItemFilterByCategoryIdAsync(int categoryId);
    }
}
