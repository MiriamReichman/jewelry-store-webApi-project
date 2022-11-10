using System;
using System.Collections.Generic;

#nullable disable

namespace logInHW.Models3
{
    public partial class Game
    {
        public int ProdId { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public string Description { get; set; }
        public int? CategorieId { get; set; }
        public string Image { get; set; }

        public virtual GameCategorie Categorie { get; set; }
    }
}
