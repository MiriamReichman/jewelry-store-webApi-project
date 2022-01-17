using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOEntity
{
    public class UserDTO
    {
        //public UserDTO()
        //{
        //    Orders = new HashSet<Order>();
        //}

       public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        //public virtual ICollection<Order> Orders { get; set; }
    }
}
