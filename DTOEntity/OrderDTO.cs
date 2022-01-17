using MyLibrary;
using System;
using System.Collections.Generic;

namespace DTOEntity
{
    public class OrderDTO
    {
        public OrderDTO()
        {
           OrderItems = new HashSet<OrderItemDTO>();
        }

        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? OrderSum { get; set; }
        public int? UserId { get; set; }

        // [JsonIgnore]
        //public string FirstName { get; set; }
        //public string LastName { get; set; }

        // public int Id { get; set; }
        // //  public virtual User User { get; set; }
        // //  [JsonIgnore]

        //public int OrderItemId { get; set; }
      public virtual ICollection<OrderItemDTO> OrderItems { get; set; }
    }
}
