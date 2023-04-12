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

        public IQueryable<Order> GetOrderIncludeProvider()
        {
            return _context.Order.Include(p => p.Provider);
        }
    }
}
