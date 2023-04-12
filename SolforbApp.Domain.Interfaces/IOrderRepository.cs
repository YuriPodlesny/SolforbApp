using SolforbApp.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolforbApp.Domain.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        IQueryable<Order> GetOrderIncludeProvider();
    }
}
