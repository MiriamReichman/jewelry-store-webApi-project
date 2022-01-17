using MyLibrary;
using System.Threading.Tasks;

namespace DL
{
    public interface IUserDL
    {
        Task<User> GetUserAsync(string email, string password);
        Task<User> postUserAsync(User user);
        Task putUserAsync(User userToUpdate,int id);
    }
}