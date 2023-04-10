using SolforbApp.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolforbApp.Domain.Interfaces
{
    public interface IOrderItemRepository : IBaseRepository<OrderItem>
    {
        IQueryable<OrderItem> GetOrderItemsByOrderId(int orderId);
    }
}
