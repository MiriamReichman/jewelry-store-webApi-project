using System;
using System.Collections.Generic;

#nullable disable

namespace MyLibrary
{
    public partial class Product
    {
        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int ProdId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int? CategorieId { get; set; }
        public string Image { get; set; }

        public virtual ProductCategorie Categorie { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
