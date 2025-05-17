using CafeAPI.Application.Interfaces;
using CafeAPI.Domain.Entities;
using CafeAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CafeAPI.Persistence.Repository
{
    public class MenuItemRepository(AppDbContext _context) : IMenuItemRepository
    {
        public async Task<List<MenuItem>> GetMenuItemFilterByCategoryIdAsync(int categoryId)
        { 
            var result = await _context.MenuItems
                .Where(x => x.CategoryId == categoryId)
                .AsNoTracking()
                .ToListAsync();

            return result;
        }
    }
}
