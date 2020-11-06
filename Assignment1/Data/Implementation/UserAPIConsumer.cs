using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Models;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Assignment1.Data.Implementation
{
    public class UserAPIConsumer : IUserService
    {
        private string uri = "https://localhost:5003/user";
        private readonly HttpClient client;

        public UserAPIConsumer()
        {
            client = new HttpClient();
        }

        public async Task<User> ValidateUserAsync(string username, string password)
        {
            Console.WriteLine("\t\t Validate user called");
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync($"{uri}/{username}&{password}");
            return JsonSerializer.Deserialize<User>(response);
        }

        public async Task AddUserAsync(string username, string password)
        {
            User user = new User
            {
                Username = username, Password = password, SecurityLevel = "RegularUser"
            };
            string userAsJson = JsonSerializer.Serialize(user);
            HttpContent content = new StringContent(userAsJson, Encoding.UTF8, "application/json");
            var httpResponseMessage = await client.PostAsync(uri, content);
            Console.WriteLine("Add: " + httpResponseMessage.StatusCode);
        }

    }
}