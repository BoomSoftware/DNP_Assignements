using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Models;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Assignment1.Data.Implementation
{
    // this is for troels's API, it doesn't really work I guess, idk
    public class WebClientFamilyService : IFamilyService
    {
        private string uri = "http://dnp.metamate.me";
        private readonly HttpClient client;

        public WebClientFamilyService()
        {
            client = new HttpClient();
        }

        public async Task<List<Family>> GetAllFamiliesAsync()
        {
            Console.WriteLine("\t\tGet all families async called");
            string message = await client.GetStringAsync(uri + "/Families");
            return JsonSerializer.Deserialize<List<Family>>(message);
        }

        public async Task CreateFamilyAsync(Family family)
        {
            string familyAsJson = JsonSerializer.Serialize(family);
            HttpContent content = new StringContent(familyAsJson, Encoding.UTF8, "application/json");
            var httpResponseMessage = await client.PutAsync(uri + "/Families", content);
            Console.WriteLine("Add: " + httpResponseMessage.StatusCode);
        }

        public async Task UpdateFamilyAsync(Family family)
        {
            string familyAsJson = JsonSerializer.Serialize(family);
            HttpContent content = new StringContent(familyAsJson, Encoding.UTF8, "application/json");
            var httpResponseMessage = await client.PutAsync(uri + "/Families", content);
            Console.WriteLine("Update: " + httpResponseMessage.StatusCode);
        }

        public async Task DeleteFamilyAsync(Family family)
        {
            // /Families?streetname=farvergade&housenumber=3
            string finalUrl = uri + "/Families?streetname=" + family.StreetName + "&housenumber=" + family.HouseNumber;
            Console.WriteLine("Final url for delete family: " + finalUrl);
            var httpResponseMessage = await client.DeleteAsync(finalUrl);
            Console.WriteLine("Delete: " + httpResponseMessage.StatusCode);
        }

        public async Task EditPersonAsync(Family family, Person person)
        {
            string personAsJson = JsonSerializer.Serialize(person);
            HttpContent content = new StringContent(personAsJson, Encoding.UTF8, "application/json");
            string finalUrl = uri;
            if (person is Child)
            {
                finalUrl += "/Children";
                var httpResponseMessage = await client.PutAsync(finalUrl, content);
                Console.WriteLine("Update: " + httpResponseMessage.StatusCode);
            }
            else if (person is Adult)
            {
                finalUrl += "/Adults";
                var httpResponseMessage = await client.PatchAsync(finalUrl, content);
                Console.WriteLine("Update: " + httpResponseMessage.StatusCode);
            }
        }

        public async Task EditPetAsync(Family family, Pet pet)
        {
            await UpdateFamilyAsync(family);
        }

        public async Task AddPersonAsync(Family family, Person person, string memberType)
        {
            string personAsJson = JsonSerializer.Serialize(person);
            HttpContent content = new StringContent(personAsJson, Encoding.UTF8, "application/json");
            string finalUrl = uri;
            if (memberType.Equals("Child"))
            {
                finalUrl += "/Children";
            }
            else if (memberType.Equals("Adult"))
            {
                finalUrl += "/Adults";
            }
            var httpResponseMessage = await client.PutAsync(finalUrl, content);
            Console.WriteLine("Update: " + httpResponseMessage.StatusCode);
        }

        public async Task AddPetAsync(Family family, Pet pet)
        {
            await UpdateFamilyAsync(family);
        }

        public async Task RemovePersonAsync(Family family, Person person, string memberType)
        {
            string personAsJson = JsonSerializer.Serialize(person);
            HttpContent content = new StringContent(personAsJson, Encoding.UTF8, "application/json");
            string finalUrl = uri;
            if (memberType.Equals("Child"))
            {
                finalUrl += "/Children/";
            }
            else if (memberType.Equals("Adult"))
            {
                finalUrl += "/Adults/";
            }
            var httpResponseMessage = await client.DeleteAsync(finalUrl + person.Id);
            Console.WriteLine("Update: " + httpResponseMessage.StatusCode);
        }

        public async Task RemovePetAsync(Family family, Pet pet)
        {
            await UpdateFamilyAsync(family);
        }

        public List<Family> GetCachedFamilies()
        {
            return new List<Family>();
        }
    }
}