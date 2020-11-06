using System.Security.Claims;
using System.Threading.Tasks;
using Models;

namespace FamilyWebAPI.Data
{
    public interface IUserService
    {
        Task<User>LoginAsync (string username, string password);
        Task RegisterAsync(User user);

    }
}