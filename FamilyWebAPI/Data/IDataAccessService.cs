using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using Adult = FamilyWebAPI.Models.Adult;
using Child = FamilyWebAPI.Models.Child;
using Family = FamilyWebAPI.Models.Family;
using Pet = FamilyWebAPI.Models.Pet;

namespace FamilyWebAPI.Data
{
    public interface IDataAccessService
    {
        Task<IList<Family>> GetAllFamiliesAsync();

        Task AddFamilyAsync(Family family);

        Task<Family> GetFamilyByAddressAsync(string streetName, int houseNumber);
        Task UpdateFamilyAsync(Family family);

        Task DeleteFamilyAsync(string streetName, int houseNumber);

        Task AddAdultToFamilyAsync(string streetName, int houseNumber, Adult adult);

        Task AddChildToFamilyAsync(string streetName, int houseNumber, Child child);

        Task AddPetToFamilyAsync(string streetName, int houseNumber, Pet pet);

        Task UpdateAdultInFamilyAsync(string streetName, int houseNumber, Adult adult);

        Task UpdateChildInFamilyAsync(string streetName, int houseNumber, Child child);

        Task UpdatePetInFamilyAsync(string streetName, int houseNumber, Pet pet);

        Task DeleteAdultFromFamilyAsync(string streetName, int houseNumber, int adultId);

        Task DeleteChildFromFamilyAsync(string streetName, int houseNumber, int childId);

        Task DeletePetFromFamilyAsync(string streetName, int houseNumber, int petId);
        
        Task<User>LoginAsync (string username, string password);
        Task RegisterAsync(User user);

    }
}