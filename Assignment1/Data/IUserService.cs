using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Assignment1.Data
{
    public interface IUserService
    {
        Task<User> ValidateUserAsync(string username, string password);
        Task AddUserAsync(string username, string password);

    }
}