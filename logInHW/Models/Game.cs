using System;
using System.Collections.Generic;

#nullable disable

namespace logInHW.Models
{
    public partial class Game
    {
        public Game()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int ProdId { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public string Description { get; set; }
        public int? CategorieId { get; set; }
        public string Image { get; set; }

        public virtual GameCategorie Categorie { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
