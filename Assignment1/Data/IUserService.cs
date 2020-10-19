using Models;

namespace Assignment1.Data
{
    public interface IUserService
    {
        User ValidateUser(string username, string password);
        void AddUser(string username, string password);
    }
}