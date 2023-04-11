using Microsoft.AspNetCore.Mvc.Rendering;
using SolforbApp.Domain.Core;

namespace SolforbApp.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Order> Orders { get; set; }

        public string Number { get; set; }
        public SelectList Numbers {  get; set; }

        public int ProviderId { get; set; }
        public SelectList ProvidersId { get; set; }
    }
}
