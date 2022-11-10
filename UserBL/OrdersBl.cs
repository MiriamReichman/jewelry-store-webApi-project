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
        IProductBl IproductBl;

        public OrdersBl(IOrdersDl iOrdersDl,IProductBl IproductBl)
        {
            this.iOrdersDl = iOrdersDl;
            this.IproductBl = IproductBl;
        }

        public async Task<Order> PostOrderAsync(Order order)
        {
            int sumOfItems = 0;

            for (int i = 0; i < order.OrderItems.Count; i++)
            {
                var arr = order.OrderItems.ToArray();
                Product p = await IproductBl.GetProductById((int)arr[i].ProuductId);
                sumOfItems += (p.Price) * (arr[i].Quantity);
            }
            if (sumOfItems != order.OrderSum)
                throw new Exception("the order sum is incurrect!");
            var awaitorder = await iOrdersDl.PostOrderAsync(order);
            return awaitorder;
        }
        
    }
}
