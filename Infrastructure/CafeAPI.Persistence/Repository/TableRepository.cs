using CafeAPI.Application.Interfaces;
using CafeAPI.Domain.Entities;
using CafeAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CafeAPI.Persistence.Repository
{
    public class TableRepository : ITableRepository
    {
        private readonly AppDbContext _context;

        public TableRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<Table> GetByTableNumberAsync(int tableNumber)
        {
            var result = _context.Tables.AsNoTracking().FirstOrDefaultAsync(x => x.TableNumber == tableNumber);
            return result;
        }
    }
}
