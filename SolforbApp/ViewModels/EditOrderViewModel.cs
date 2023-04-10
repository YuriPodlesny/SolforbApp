using Microsoft.AspNetCore.Mvc.Rendering;

namespace SolforbApp.ViewModels
{
    public class EditOrderViewModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public int ProviderId { get; set; }

        public IEnumerable<SelectListItem>? Providers { get; set; }
    }
}
