using Microsoft.EntityFrameworkCore;
using SolforbApp.Domain.Core;
using SolforbApp.Domain.Interfaces;
using SolforbApp.Infrastructure.Data;
using SolforbApp.Infrastructure.Data.Repository;

namespace SolforbApp.Services.Repository
{
    public class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
    {
        private readonly SolforbDbContext _context;
        public OrderItemRepository(SolforbDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<OrderItem> GetOrderItemsByOrderId(int orderId)
        {
            return _context.OrderItem.Where(x => x.OrderId == orderId);
        }
    }
}
