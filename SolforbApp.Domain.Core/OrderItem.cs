using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolforbApp.Domain.Core
{
    public class OrderItem : BaseEntitu
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
    }
}
