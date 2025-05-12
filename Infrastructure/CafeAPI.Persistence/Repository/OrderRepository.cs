using CafeAPI.Application.Dtos.OrderDtos;
using CafeAPI.Application.Interfaces;
using CafeAPI.Domain.Entities;
using CafeAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CafeAPI.Persistence.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllOrdersWithDetailAsync()
        {
            var result = await _context.Orders
                .Include(x => x.OrderItems)
                .ThenInclude(x => x.MenuItem)
                .ThenInclude(x => x.Category)
                .AsNoTracking()
                .ToListAsync();

            return result;
        }

        public async Task<ResultOrderByIdWithDetailDto> GetOrderByIdWithDetailAsync(int id)
        {
            var result = await _context.Orders
            .Where(x => x.Id == id)
            .Select(x => new ResultOrderByIdWithDetailDto{
                Id = x.Id,
                TableId = x.TableId,
                TotalPrice = x.TotalPrice,
                Status = x.Status,
                CreatedAt = x.CreatedAt,
                Items = x.OrderItems.Select(oi => new OrderItemDto
                {
                    Id = oi.Id,
                    Quantity = oi.Quantity,
                    MenuItemName = oi.MenuItem.Name,
                    CategoryName = oi.MenuItem.Category.Name,
                    Price = oi.Price
                    
                }).ToList()
            })
            .AsNoTracking()
            .FirstOrDefaultAsync();

            return result!;
        }
    }
}
