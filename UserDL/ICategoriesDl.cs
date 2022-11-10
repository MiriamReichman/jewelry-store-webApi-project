using MyLibrary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface ICategoriesDl
    {
        Task<List<ProductCategorie>> GetCategoriesAsync();
    }
}