using Microsoft.VisualBasic;
using SolforbApp.Domain.Core;

namespace SolforbApp.ViewModels
{
    public class DetailViewModel
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string? ProviderName { get; set; }

        public IQueryable<OrderItem>? OrderItems { get; set; }
    }
}

