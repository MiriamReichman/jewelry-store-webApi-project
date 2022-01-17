using Microsoft.EntityFrameworkCore;
using MyLibrary;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DL
{
    public class UserDL : IUserDL
    {
        api212796Context dbContext;

        public UserDL(api212796Context dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> GetUserAsync(string email, string password)
        {
          var u = await dbContext.Users.Where((u) =>  u.Email==email && u.Password==password).FirstOrDefaultAsync();
        
            return u;
          
            
          
        }
        public async Task<User> postUserAsync(User user)
        {
      
           await  dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
           
            return user;
        }
        //לשנות שתקבל ID
        public async Task putUserAsync(User userToUpdate,int id)
        {
            User userToUpdate1 = await dbContext.Users.FindAsync(id);
            if(userToUpdate1 == null)
            {
                return ;
            }
            userToUpdate.Id = userToUpdate1.Id;
            dbContext.Entry(userToUpdate1).CurrentValues.SetValues(userToUpdate);
            await dbContext.SaveChangesAsync();
           

           
        }
    }
}
