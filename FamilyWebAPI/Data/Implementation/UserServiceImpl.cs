using System.Security.Claims;
using System.Threading.Tasks;
using Models;

namespace FamilyWebAPI.Data.Implementation
{
    public class UserServiceImpl : IUserService
    {
        private IDataAccessService dataService;

        public UserServiceImpl(IDataAccessService dataService)
        {
            this.dataService = dataService;
        }


        public async Task<User> LoginAsync(string username, string password)
        {
          return await dataService.LoginAsync(username, password);
            
        }

        public async Task RegisterAsync(User user)
        {
            await dataService.RegisterAsync(user);
        }
    }
}