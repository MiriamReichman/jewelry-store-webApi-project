using MyLibrary;
using System.Threading.Tasks;

namespace BL
{
    public interface IUserBL
    {
        Task<User> GetUserAsync(string email, string password);
        Task<User> postUserAsync(User user);
        Task putUserAsync(User user,int id);
    }
}