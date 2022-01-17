using MyLibrary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IProductBl
    {
        Task<List<Game>> GetGames();
        Task<List<Game>> GetGamesByCategorie(int id);
    }
}