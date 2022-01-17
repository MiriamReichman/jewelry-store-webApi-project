using DTOEntity;
using MyLibrary;
using System.Threading.Tasks;

namespace BL
{
    public interface IOrdersBl
    {
        Task<Order> PostOrderAsync(Order order);
 
    }
}