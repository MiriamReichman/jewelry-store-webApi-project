using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOEntity
{
    public class ProductDTO
    {
        public ProductDTO()
        {
            //OrderItems = new HashSet<OrderItem>();
        }

        public int ProdId { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public string Description { get; set; }
        public int? CategorieId { get; set; }
        public string Image { get; set; }

        //public virtual ProductCategorieDTO Categorie { get; set; }
        //public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
