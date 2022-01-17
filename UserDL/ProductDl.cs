using Microsoft.EntityFrameworkCore;
using MyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class ProductDl : IProductDl
    {

        api212796Context dbContext;

        public ProductDl(api212796Context dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Game>> GetGames()
        {
          
             return await dbContext.Games.ToListAsync();
        }
        public async Task<List<Game>> GetGamesByCategorie(int id)
        {
           
            List<Game> a =await dbContext.Games.Where(e=>e.Categorie.CategoresId == id).ToListAsync();
            return a;
        }
    }
}

