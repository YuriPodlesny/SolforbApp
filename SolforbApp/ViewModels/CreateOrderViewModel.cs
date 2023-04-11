using Microsoft.AspNetCore.Mvc.Rendering;
using SolforbApp.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace SolforbApp.ViewModels
{
    public class CreateOrderViewModel
    {
        [Required(ErrorMessage = "Укажите номер заказа")]
        [Display(Name = "Номер заказа")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Укажите дату заказа")]
        [Display(Name = "Дата заказа")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Укажите поставщика заказа")]
        [Display(Name = "Поставщик")]
        public int ProviderId { get; set; }

        public IEnumerable<SelectListItem>? Providers { get; set; }
    }
}
