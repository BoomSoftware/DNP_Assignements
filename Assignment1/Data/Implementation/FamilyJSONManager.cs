using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Models;

namespace Assignment1.Data.Implementation
{
    public class FamilyJsonManager : IFamilyService
    {
        private readonly string jsonFile = "wwwroot/json/families.json";
        private List<Family> families;

        public FamilyJsonManager()
        {
            families = GetAllFamilies();
        }

        public List<Family> GetAllFamilies()
        {
            string content = File.ReadAllText(jsonFile);
            return JsonSerializer.Deserialize<List<Family>>(content);
        }

        public Dictionary<string, int> GetNumberOfAdultsByEyeColor()
        {
            Dictionary<string, int> adultsByEyeColor = new Dictionary<string, int>()
            {
                ["Brown"] = 0,
                ["Black"] = 0,
                ["Grey"] = 0,
                ["Green"] = 0,
                ["Blue"] = 0,
                ["Amber"] = 0,
                ["Hazel"] = 0
            };
            foreach (var family in families)
            {
                foreach (var adult in family.Adults)
                {
                    adultsByEyeColor[adult.EyeColor]++;
                }
            }

            return adultsByEyeColor;
        }

        public void CreateFamily(Family family)
        {
            // List<Family> families = GetAllFamilies();
            int lastChildId = GetLastChildId();
            int lastAdultId = GetLastAdultId();
            int lastPetId = GetLastPetId();

            foreach (var child in family.Children)
            {
                child.Id = ++lastChildId;
                foreach (var childPet in child.Pets)
                {
                    childPet.Id = ++lastPetId;
                }
            }

            foreach (var adult in family.Adults)
            {
                adult.Id = ++lastAdultId;
            }

            foreach (var familyPet in family.Pets)
            {
                familyPet.Id = ++lastPetId;
            }
            
            families.Add(family);
            WriteFamiliesToFile();
        }

        public void UpdateFamily(Family family)
        {
            // List<Family> families = GetAllFamilies();
            foreach (var fam in families)
            {
                if (fam.StreetName == family.StreetName && fam.HouseNumber == family.HouseNumber)
                {
                    // fam.StreetName = family.StreetName;
                    // fam.HouseNumber = family.HouseNumber;
                    fam.Adults = family.Adults;
                    fam.Children = family.Children;
                    fam.Pets = family.Pets;
                }
            }

            WriteFamiliesToFile();
        }

        public void DeleteFamily(Family family)
        {
            // List<Family> families = GetAllFamilies();
            families.Remove(family);
            WriteFamiliesToFile();
        }

        private void WriteFamiliesToFile()
        {
            string famList = JsonSerializer.Serialize(families);
            File.WriteAllText(jsonFile,famList);
        }

        private int GetLastChildId()
        {
            Family lastFamily = families.Last();
            if (lastFamily == null)
                return -1;
            Child lastChild = lastFamily.Children.Last();
            return lastChild.Id;
        }

        private int GetLastAdultId()
        {
            Family lastFamily = families.LastOrDefault();
            if (lastFamily == null)
                return -1;
            Adult lastAdult = lastFamily.Adults.Last();
            return lastAdult.Id;
        }

        private int GetLastPetId()
        {
            for (var i = families.Count - 1; i >= 0; i--)
            {
                if (families[i].Pets.Any())
                    return families[i].Pets.Last().Id;

                List<Child> kids = families[i].Children;

                for (var j = kids.Count - 1; j >= 0; j--)
                {
                    if (kids[j].Pets.Any())
                        return kids[j].Pets.Last().Id;
                }
            }

            return -1;
        }
    }
}