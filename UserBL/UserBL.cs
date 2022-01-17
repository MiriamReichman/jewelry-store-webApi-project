using MyLibrary;
using System;
using DL;
using System.Threading.Tasks;

namespace BL
{
    public class UserBL : IUserBL
    {
        IUserDL IUserDL;
            public UserBL(IUserDL IUserDL)
        {
            this.IUserDL = IUserDL;  
        }
        public async Task<User> GetUserAsync(string email, string password)
        {
            var user = await IUserDL.GetUserAsync(email, password);
            return user;
        }
        public async Task<User> postUserAsync(User user)
        {
            
            var awaituser = await IUserDL.postUserAsync(user);
            return awaituser;
        }
        public async Task putUserAsync(User user,int id)
        {
           
         await IUserDL.putUserAsync(user,id);
        }
    }
}
