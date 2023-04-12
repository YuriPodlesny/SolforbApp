using Microsoft.AspNetCore.Mvc.Rendering;
using SolforbApp.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace SolforbApp.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Order> Orders { get; set; }

        public string Number { get; set; }
        public SelectList Numbers {  get; set; }

        public int ProviderId { get; set; }
        public IEnumerable<SelectListItem> Providers { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataStart { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataEnd { get; set; }
    }
}
