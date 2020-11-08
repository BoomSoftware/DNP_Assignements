using System.Security.Claims;
using System.Threading.Tasks;
using FamilyWebAPI.Models;

namespace FamilyWebAPI.Data
{
    public interface IUserService
    {
        Task<APIUser>LoginAsync (string username, string password);
        Task RegisterAsync(APIUser user);

    }
}