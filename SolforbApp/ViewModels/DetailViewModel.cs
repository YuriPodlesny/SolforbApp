using Microsoft.AspNetCore.Mvc.Rendering;
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
        public IQueryable<OrderItem> OrderItems { get; set; }

        public string OrderItemName { get; set; }
        public SelectList Names { get; set; }

        public string OrderItemUnit { get; set; }
        public SelectList Units { get; set; }
    }
}

