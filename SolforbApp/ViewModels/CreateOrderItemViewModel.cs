using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SolforbApp.ViewModels
{
    public class CreateOrderItemViewModel
    {
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Укажите имя")]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите количество")]
        [Display(Name = "Количество")]
        public decimal Quantity { get; set; }

        [Required(ErrorMessage = "Укажите единицу измерения")]
        [Display(Name = "Единица измерения")]
        public string Unit { get; set; }
    }
}
