using DL;
using MyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ProductBl : IProductBl
    {
        IProductDl ProductDl;
        public ProductBl(IProductDl ProductDl)
        {
            this.ProductDl = ProductDl;
        }
        public async Task<List<Product>> GetGames()
        {
            return await ProductDl.GetGames();
        }
        public async Task<List<Product>> GetGamesByCategorie(int id)
        {
            return await ProductDl.GetGamesByCategorie(id);
        }
        public async Task<Product> GetProductById(int id)
        {
            return await ProductDl.GetProductById(id);
        }

        }
}
