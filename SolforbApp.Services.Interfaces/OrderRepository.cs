using Microsoft.EntityFrameworkCore;
using SolforbApp.Domain.Core;
using SolforbApp.Domain.Interfaces;
using SolforbApp.Infrastructure.Data;
using SolforbApp.Infrastructure.Data.Repository;

namespace SolforbApp.Services.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly SolforbDbContext _context;
        public OrderRepository(SolforbDbContext context) : base(context)
        {
            _context = context;
        }

        public new async Task<bool> Create(Order entety)
        {
            await _context.AddAsync(entety);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public new async Task<bool> Update(Order entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public IQueryable<Order> GetOrderIncludeProvider()
        {
            return _context.Order.Include(p => p.Provider);
        }
    }
}
