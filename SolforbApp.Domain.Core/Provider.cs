using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolforbApp.Domain.Core
{
    public class Provider : BaseEntitu
    {
        public string Name { get; set; }

        public List<Order> Orders { get; set; } = new ();
    }
}
