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

        public async Task<List<Product>> GetGames()
        {
            //dbContext.Products


           //return await dbContext.Games.ToListAsync();
              return await dbContext.Products.ToListAsync();
        }
        public async Task<List<Product>> GetGamesByCategorie(int id)
        {
           
            List<Product> a =await dbContext.Products.Where(e=>e.Categorie.CategoresId == id).ToListAsync();
            return a;
        }
        public async Task<Product> GetProductById(int id)
        {

            Product a = await dbContext.Products.Where(e => e.ProdId == id).FirstOrDefaultAsync();
            return a;
        }
    }
}

