using System;
using System.Collections.Generic;

#nullable disable

namespace logInHW.Models
{
    public partial class GameCategorie
    {
        public GameCategorie()
        {
            Games = new HashSet<Game>();
        }

        public int CategoresId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
