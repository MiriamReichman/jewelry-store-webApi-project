using System;
using System.Collections.Generic;

#nullable disable

namespace MyLibrary
{
    public partial class ProductCategorie
    {
        public ProductCategorie()
        {
            Products = new HashSet<Product>();
        }

        public int CategoresId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
