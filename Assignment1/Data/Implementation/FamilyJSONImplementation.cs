using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Models;

namespace Assignment1.Data.Implementation
{
    public class FamilyJSONImplementation : IFamilyService
    { 
        private readonly string jsonFile = "wwwroot/json/families.json";
        
        
        public List<Family> GetAllFamilies()
        {
            string content = File.ReadAllText(jsonFile);
            return JsonSerializer.Deserialize<List<Family>>(content);
        }
    }
}