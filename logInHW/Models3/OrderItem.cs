using System;
using System.Collections.Generic;

#nullable disable

namespace logInHW.Models3
{
    public partial class OrderItem
    {
        public int OrderItemId { get; set; }
        public int? ProuductId { get; set; }
        public int? OrderId { get; set; }
        public int Quantity { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Prouduct { get; set; }
    }
}
