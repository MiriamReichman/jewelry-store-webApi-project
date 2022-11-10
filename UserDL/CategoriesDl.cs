using Microsoft.EntityFrameworkCore;
using MyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class CategoriesDl : ICategoriesDl
    {
        api212796Context dbContext;

        public CategoriesDl(api212796Context dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<ProductCategorie>> GetCategoriesAsync()
        {
            ////להחזיר את רשימת הקגורית
            var u = await dbContext.ProductCategories.ToListAsync();
            return u;
                }

    }
}
