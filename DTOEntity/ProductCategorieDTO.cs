using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOEntity
{
   public class ProductCategorieDTO
    {
        public ProductCategorieDTO()
        {
            //Games = new HashSet<Game>();
        }

        public int CategoresId { get; set; }
        public string Name { get; set; }


        //public virtual ICollection<Game> Games { get; set; }
    }
}

