using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Models;

namespace Assignment1.Data.Implementation
{
    public class FamilyJsonImplementation : IFamilyService
    {
        private readonly string jsonFile = "wwwroot/json/families.json";


        public List<Family> GetAllFamilies()
        {
            string content = File.ReadAllText(jsonFile);
            return JsonSerializer.Deserialize<List<Family>>(content);
        }


        public void CreateFamily(Family family)
        {
            List<Family> families = GetAllFamilies();
            families.Add(family);
            WriteFamiliesToFile(families);
        }

        public void UpdateFamily(Family family)
        {
            List<Family> families = GetAllFamilies();
            foreach (var fam in families)
            {
                if (fam.Id == family.Id)
                {
                    fam.StreetName = family.StreetName;
                    fam.HouseNumber = family.HouseNumber;
                    fam.Adults = family.Adults;
                    fam.Children = family.Children;
                    fam.Pets = family.Pets;
                }
            }

            WriteFamiliesToFile(families);
        }

        public void DeleteFamily(Family family)
        {
            List<Family> families = GetAllFamilies();
            families.Remove(family);
            WriteFamiliesToFile(families);
        }

        private void WriteFamiliesToFile(List<Family> families)
        {
            string famList = JsonSerializer.Serialize(families);
            File.WriteAllText(jsonFile,famList);
        }
    }
}