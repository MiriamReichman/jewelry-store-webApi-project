using MyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOEntity;
using DL;
namespace BL
{
    public class OrdersBl : IOrdersBl
    {
        IOrdersDl iOrdersDl;

        public OrdersBl(IOrdersDl iOrdersDl)
        {
            this.iOrdersDl = iOrdersDl;
        }

        public async Task<Order> PostOrderAsync(Order order)
        {

              var awaitorder = await iOrdersDl.PostOrderAsync(order);
            return awaitorder;
        }
        
    }
}
