using MyLibrary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IProductDl
    {
        Task<List<Game>> GetGames();
        Task<List<Game>> GetGamesByCategorie(int id);
    }
}