using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Models;

namespace Assignment1.Data.Implementation
{
    public class UserJSONManager : IUserService
    {
        private List<User> users;
        private readonly string userFile = "wwwroot/json/users.json";

        public UserJSONManager()
        {
            users = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(userFile));
        }

        public User ValidateUser(string username, string password)
        {
            return users.FirstOrDefault(user => user.Username.Equals(username) && user.Password.Equals(password));
        }

        public void AddUser(string username, string password)
        {
            users.Add(new User
            {
                Username = username,
                Password = password,
                SecurityLevel = "RegularUser"
            });
            WriteUsersToFile();
        }

        private void WriteUsersToFile()
        {
            File.WriteAllText(userFile, JsonSerializer.Serialize(users));
        }
    }
}