using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Models;
using Adult = FamilyWebAPI.Models.Adult;
using Child = FamilyWebAPI.Models.Child;
using Family = FamilyWebAPI.Models.Family;
using Pet = FamilyWebAPI.Models.Pet;

namespace FamilyWebAPI.Data.Implementation
{
    public class DataAccessServiceImpl : IDataAccessService
    {
        private string familiesFile = "families.json";
        private IList<Family> families;
        private int lastAdultId;
        private int lastChildId;
        private int lastPetId;
        private IList<User> _users;
        private string userFile = "users.json";
        

        public DataAccessServiceImpl()
        {
            families = new List<Family>();
        }

        public async Task<IList<Family>> GetAllFamiliesAsync()
        {
            if (!families.Any())
            {
                Console.WriteLine("\tHere");
                string familiesAsJson = File.ReadAllText(familiesFile);
                families = JsonSerializer.Deserialize<List<Family>>(familiesAsJson);
                Console.WriteLine("Families: " + families.Count + " " + families[0].StreetName);
                RetrieveLastIds();
            }

            return families;
        }

        public async Task AddFamilyAsync(Family family)
        {
            // the validation has been done by the controller right?
            families.Add(family);
            await WriteFamiliesToFile();
        }

        public async Task<Family> GetFamilyByAddressAsync(string streetName, int houseNumber)
        {
            if (!families.Any())
            {
                families = await GetAllFamiliesAsync();
            }

            foreach (var family in families)
            {
                if (family.StreetName.Equals(streetName) && family.HouseNumber == houseNumber)
                    return family;
            }

            return null;
        }

        public async Task UpdateFamilyAsync(Family fam)
        {
            if (!families.Any())
            {
                families = await GetAllFamiliesAsync();
            }
            
            foreach (var family in families)
            {
                if (family.StreetName.Equals(fam.StreetName) && family.HouseNumber == fam.HouseNumber)
                    family.EditFamily(fam);
            }

            await WriteFamiliesToFile();
        }

        public async Task DeleteFamilyAsync(string streetName, int houseNumber)
        {
            if (!families.Any())
            {
                families = await GetAllFamiliesAsync();
            }

            foreach (var family in families)
            {
                if (family.StreetName.Equals(streetName) && family.HouseNumber == houseNumber)
                {
                    families.Remove(family);
                    break;
                }
            }
            await WriteFamiliesToFile();
        }

        public async Task AddAdultToFamilyAsync(string streetName, int houseNumber, Adult adult)
        {
            if (!families.Any())
            {
                families = await GetAllFamiliesAsync();
            }

            foreach (var family in families)
            {
                if (family.StreetName.Equals(streetName) && family.HouseNumber == houseNumber)
                {
                    adult.Id = ++lastAdultId;
                    family.AddPerson(adult, "Adult");
                }
            }
            await WriteFamiliesToFile();
        }

        public async Task AddChildToFamilyAsync(string streetName, int houseNumber, Child child)
        {
            if (!families.Any())
            {
                families = await GetAllFamiliesAsync();
            }

            foreach (var family in families)
            {
                if (family.StreetName.Equals(streetName) && family.HouseNumber == houseNumber)
                {
                    child.Id = ++lastChildId;
                    family.AddPerson(child, "Child");
                }
            }
            await WriteFamiliesToFile();
        }

        public async Task AddPetToFamilyAsync(string streetName, int houseNumber, Pet pet)
        {
            if (!families.Any())
            {
                families = await GetAllFamiliesAsync();
            }

            foreach (var family in families)
            {
                if (family.StreetName.Equals(streetName) && family.HouseNumber == houseNumber)
                {
                    pet.Id = ++lastPetId;
                    family.AddPet(pet);
                }
            }
            await WriteFamiliesToFile();
        }

        public async Task UpdateAdultInFamilyAsync(string streetName, int houseNumber, Adult adult)
        {
            if (!families.Any())
            {
                families = await GetAllFamiliesAsync();
            }

            foreach (var family in families)
            {
                if (family.StreetName.Equals(streetName) && family.HouseNumber == houseNumber)
                    family.EditAdult(adult);
            }
            await WriteFamiliesToFile();
        }

        public async Task UpdateChildInFamilyAsync(string streetName, int houseNumber, Child child)
        {
            if (!families.Any())
            {
                families = await GetAllFamiliesAsync();
            }

            foreach (var family in families)
            {
                if (family.StreetName.Equals(streetName) && family.HouseNumber == houseNumber)
                    family.EditChild(child);
            }
            await WriteFamiliesToFile();
        }

        public async Task UpdatePetInFamilyAsync(string streetName, int houseNumber, Pet pet)
        {
            if (!families.Any())
            {
                families = await GetAllFamiliesAsync();
            }

            foreach (var family in families)
            {
                if (family.StreetName.Equals(streetName) && family.HouseNumber == houseNumber)
                    family.EditPet(pet);
            }
            await WriteFamiliesToFile();
        }

        public async Task DeleteAdultFromFamilyAsync(string streetName, int houseNumber, int adultId)
        {
            if (!families.Any())
            {
                families = await GetAllFamiliesAsync();
            }

            foreach (var family in families)
            {
                if (family.StreetName.Equals(streetName) && family.HouseNumber == houseNumber)
                    family.RemoveMember("Adult", adultId);
            }
            await WriteFamiliesToFile();
        }

        public async Task DeleteChildFromFamilyAsync(string streetName, int houseNumber, int childId)
        {
            if (!families.Any())
            {
                families = await GetAllFamiliesAsync();
            }

            foreach (var family in families)
            {
                if (family.StreetName.Equals(streetName) && family.HouseNumber == houseNumber)
                    family.RemoveMember("Child", childId);
            }
            await WriteFamiliesToFile();
        }

        public async Task DeletePetFromFamilyAsync(string streetName, int houseNumber, int petId)
        {
            if (!families.Any())
            {
                families = await GetAllFamiliesAsync();
            }

            foreach (var family in families)
            {
                if (family.StreetName.Equals(streetName) && family.HouseNumber == houseNumber)
                    family.RemovePet(petId);
            }
            await WriteFamiliesToFile();
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            List<User> users = new List<User>();
            string userAsJson = await File.ReadAllTextAsync(userFile);
            users = JsonSerializer.Deserialize<List<User>>(userAsJson);
            foreach (var user in users)
            {
                if (user.Username.Equals(username) && user.Password.Equals(password))
                {
                    return user;
                }
            }

            return null;
        }

        public async Task RegisterAsync(User user)
        {
            List<User> users = new List<User>();
            string userAsJson = await File.ReadAllTextAsync(userFile);
            users = JsonSerializer.Deserialize<List<User>>(userAsJson);
            users.Add(user);
            userAsJson = JsonSerializer.Serialize(users);
            await File.WriteAllTextAsync(userFile,userAsJson);
        }
        


        private async Task WriteFamiliesToFile()
        {
            await File.WriteAllTextAsync(familiesFile, JsonSerializer.Serialize(families));
        }
        
        private void RetrieveLastIds()
        {
            foreach (var family in families)
            {
                if (family.Adults.Any())
                    lastAdultId = family.Adults[^1].Id;
                if (family.Children.Any())
                    lastChildId = family.Children[^1].Id;
                if (family.Pets.Any())
                    lastPetId = family.Pets[^1].Id;
            }
        }
    }
}