using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace Assignment1.Data.Implementation
{
    public class CustomFamilyAPIConsumer : IFamilyService
    {
        private string uri = "https://localhost:5003/families";
        private readonly HttpClient client;
        private List<Family> cachedFamilies;

        public CustomFamilyAPIConsumer()
        {
            client = new HttpClient();
            cachedFamilies = new List<Family>();
        }

        public async Task<List<Family>> GetAllFamiliesAsync()
        {
            Console.WriteLine("Before GetStringAsync API request for retrieving all families");
            string message = await client.GetStringAsync(uri + "");
            Console.WriteLine("After getting all the families from the API");
            cachedFamilies = JsonSerializer.Deserialize<List<Family>>(message);
            return cachedFamilies;
        }

        public async Task CreateFamilyAsync(Family family)
        {
            string familyAsJson = JsonSerializer.Serialize(family);
            HttpContent content = new StringContent(familyAsJson, Encoding.UTF8, "application/json");
            var httpResponseMessage = await client.PostAsync(uri, content);
            Console.WriteLine("Add: " + httpResponseMessage.StatusCode);
        }

        public async Task UpdateFamilyAsync(Family family)
        {
            string finalUrl = $"{uri}/{family.StreetName}&{family.HouseNumber}";
            string familyAsJson = JsonSerializer.Serialize(family);
            HttpContent content = new StringContent(familyAsJson, Encoding.UTF8, "application/json");
            var httpResponseMessage = await client.PutAsync(finalUrl, content);
            Console.WriteLine("Update: " + httpResponseMessage.StatusCode);
        }

        public async Task DeleteFamilyAsync(Family family)
        {
            // /families/streetname=farvergade&housenumber=3
            string finalUrl = $"{uri}/{family.StreetName}&{family.HouseNumber}";
            Console.WriteLine("Final url for delete family: " + finalUrl);
            var httpResponseMessage = await client.DeleteAsync(finalUrl);
            Console.WriteLine("Delete: " + httpResponseMessage.StatusCode);
        }

        public async Task EditPersonAsync(Family family, Person person)
        {
            string finalUrl = $"{uri}/{family.StreetName}&{family.HouseNumber}/";
            if (person is Adult)
                finalUrl += "adults";
            if (person is Child)
                finalUrl += "children";

            string personAsJson = JsonSerializer.Serialize(person);
            HttpContent content = new StringContent(personAsJson, Encoding.UTF8, "application/json");
            Console.WriteLine("Before making PutAsync API request for edit person");
            var httpResponseMessage = await client.PutAsync(finalUrl, content);
            Console.WriteLine("After getting the edit person request response");
        }

        public async Task EditPetAsync(Family family, Pet pet)
        {
            string finalUrl = $"{uri}/{family.StreetName}&{family.HouseNumber}/pets";
            string petAsJson = JsonSerializer.Serialize(pet);
            HttpContent content = new StringContent(petAsJson, Encoding.UTF8, "application/json");
            Console.WriteLine("Before editing pet");
            var httpResponseMessage = await client.PutAsync(finalUrl, content);
            Console.WriteLine("Edit pet " + httpResponseMessage.StatusCode);
        }

        public async Task AddPersonAsync(Family family, Person person, string memberType)
        {
            string finalUrl = $"{uri}/{family.StreetName}&{family.HouseNumber}/";
            if (person is Adult)
                finalUrl += "adults";
            if (person is Child)
                finalUrl += "children";

            string personAsJson = JsonSerializer.Serialize(person);
            HttpContent content = new StringContent(personAsJson, Encoding.UTF8, "application/json");
            var httpResponseMessage = await client.PostAsync(finalUrl, content);
            Console.WriteLine("Add person " + httpResponseMessage.StatusCode);
        }

        public async Task AddPetAsync(Family family, Pet pet)
        {
            string finalUrl = $"{uri}/{family.StreetName}&{family.HouseNumber}/pets";
            string petAsJson = JsonSerializer.Serialize(pet);
            HttpContent content = new StringContent(petAsJson, Encoding.UTF8, "application/json");
            var httpResponseMessage = await client.PostAsync(finalUrl, content);
            Console.WriteLine("Edit pet " + httpResponseMessage.StatusCode);
        }

        public async Task RemovePersonAsync(Family family, Person person, string memberType)
        {
            string finalUrl = $"{uri}/{family.StreetName}&{family.HouseNumber}/{memberType}/{person.Id}";
            Console.WriteLine("Final url for delete person: " + finalUrl);
            var httpResponseMessage = await client.DeleteAsync(finalUrl);
            Console.WriteLine("Delete person: " + httpResponseMessage.StatusCode);
        }

        public async Task RemovePetAsync(Family family, Pet pet)
        {
            string finalUrl = $"{uri}/{family.StreetName}&{family.HouseNumber}/pets/{pet.Id}";
            Console.WriteLine("Final url for delete pet: " + finalUrl);
            var httpResponseMessage = await client.DeleteAsync(finalUrl);
            Console.WriteLine("Delete pet: " + httpResponseMessage.StatusCode);
        }

        public List<Family> GetCachedFamilies()
        {
            return cachedFamilies;
        }
    }
}