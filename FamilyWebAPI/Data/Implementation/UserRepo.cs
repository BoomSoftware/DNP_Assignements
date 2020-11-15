using System;
using System.Linq;
using System.Threading.Tasks;
using FamilyWebAPI.Models;
using FamilyWebAPI.Persistence;
using Microsoft.EntityFrameworkCore;
using Models;

namespace FamilyWebAPI.Data.Implementation
{
    public class UserRepo : IUserRepo
    {
        public async Task<APIUser> LoginAsync(string username, string password)
        {
            using (FamilyDbContext dbContext = new FamilyDbContext())
            {
                APIUser user = await dbContext.Users.FirstOrDefaultAsync(u => u.Username.Equals(username)
                                                                && u.Password.Equals(password));
                return user;
            }
        }

        public async Task RegisterAsync(APIUser user)
        {
            using (FamilyDbContext dbContext = new FamilyDbContext())
            {
                await dbContext.Users.AddAsync(user);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}