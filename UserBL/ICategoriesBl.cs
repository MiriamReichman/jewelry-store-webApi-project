using MyLibrary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface ICategoriesBl
    {
        Task<List<GameCategorie>> GetCategoriesAsync();
    }
}