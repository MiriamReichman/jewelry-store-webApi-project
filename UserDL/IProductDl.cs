using MyLibrary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IProductDl
    {
        Task<List<Product>> GetGames();
        Task<List<Product>> GetGamesByCategorie(int id);
        Task<Product> GetProductById(int id);
    }
}