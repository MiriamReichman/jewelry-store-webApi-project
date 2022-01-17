using MyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class OrdersDl : IOrdersDl
    {
        api212796Context dbContext;

        public OrdersDl(api212796Context dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Order> PostOrderAsync(Order order)
        {

            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();
            return order;
        }
    }
}
