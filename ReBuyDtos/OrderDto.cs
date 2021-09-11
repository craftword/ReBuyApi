using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReBuyDtos
{
    public class OrderDto
    {
        public double Amount { get; set; }
        public string ShippingAddress { get; set; }
        public string State { get; set; }

        public string ProductId { get; set; }
        public string UserId { get; set; }

    }
}
