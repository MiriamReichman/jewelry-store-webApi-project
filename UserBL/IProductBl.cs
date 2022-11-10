using MyLibrary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IProductBl
    {
        Task<List<Product>> GetGames();
        Task<List<Product>> GetGamesByCategorie(int id);
        Task<Product> GetProductById(int id);
    }
}