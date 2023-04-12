using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SolforbApp.Domain.Core
{
    [Index(nameof(Number), nameof(ProviderId), IsUnique = true, Name = "IndexNumderAndRroviderId")]
    public class Order : BaseEntitu
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public int ProviderId { get; set; }
        public Provider? Provider { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
