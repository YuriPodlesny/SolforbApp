using Microsoft.AspNetCore.Mvc.Rendering;
using SolforbApp.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace SolforbApp.ViewModels
{
    public class CreateOrderViewModel
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public int ProviderId { get; set; }

        public IEnumerable<SelectListItem>? Providers { get; set; }
    }
}
