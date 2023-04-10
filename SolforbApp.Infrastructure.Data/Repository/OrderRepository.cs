using SolforbApp.Domain.Core;
using SolforbApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolforbApp.Infrastructure.Data.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(SolforbDbContext context) : base(context)
        {
        }
    }
}
