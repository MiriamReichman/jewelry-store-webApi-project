using DL;
using MyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CategoriesBl : ICategoriesBl
    {
        ICategoriesDl ICategoriesDL;
        public CategoriesBl(ICategoriesDl ICategoriesDL)
        {
            this.ICategoriesDL = ICategoriesDL;
        }
        public async Task<List<GameCategorie>> GetCategoriesAsync()
        {
            var user = await ICategoriesDL.GetCategoriesAsync();
            return user;
        }

    }
}
