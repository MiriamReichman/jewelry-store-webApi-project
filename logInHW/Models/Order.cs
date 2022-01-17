﻿using System;
using System.Collections.Generic;

#nullable disable

namespace logInHW.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? OrderSum { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
