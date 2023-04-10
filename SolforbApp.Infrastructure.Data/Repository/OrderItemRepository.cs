using Microsoft.EntityFrameworkCore;
using SolforbApp.Domain.Core;
using SolforbApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolforbApp.Infrastructure.Data.Repository
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
            return _context.OrderItem.Where(x=>x.OrderId == orderId);
        }


    }
}
