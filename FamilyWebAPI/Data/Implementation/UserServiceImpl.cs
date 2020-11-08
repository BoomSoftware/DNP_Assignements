using System.Security.Claims;
using System.Threading.Tasks;
using FamilyWebAPI.Models;

namespace FamilyWebAPI.Data.Implementation
{
    public class UserServiceImpl : IUserService
    {
        private IDataAccessService dataService;

        public UserServiceImpl(IDataAccessService dataService)
        {
            this.dataService = dataService;
        }


        public async Task<APIUser> LoginAsync(string username, string password)
        {
          return await dataService.LoginAsync(username, password);
            
        }

        public async Task RegisterAsync(APIUser user)
        {
            await dataService.RegisterAsync(user);
        }
    }
}