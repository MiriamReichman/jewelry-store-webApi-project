using MyLibrary;
using System.Threading.Tasks;

namespace DL
{
    public interface IOrdersDl
    {
        Task<Order> PostOrderAsync(Order order);

    }
}