using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyWebAPI.Models;

namespace FamilyWebAPI.Data
{
    public interface IFamilyService
    {
        Task<IList<Family>> GetAllFamiliesAsync();
        Task<Family> GetFamilyByAddress(string streetName, int? houseNumber);
        Task CreateFamilyAsync(Family family);
        Task UpdateFamilyAsync(Family family);
        Task DeleteFamilyAsync(string streetName, int? houseNumber);
        
        Task AddAdultToFamilyAsync(string streetName, int houseNumber, Adult adult);
        
        Task AddChildToFamilyAsync(string streetName, int houseNumber, Child child);
        
        Task AddPetToFamilyAsync(string streetName, int houseNumber, Pet pet);

        Task UpdateAdultInFamilyAsync(string streetName, int houseNumber, Adult adult);
        
        Task UpdateChildInFamilyAsync(string streetName, int houseNumber, Child child);
        
        Task UpdatePetInFamilyAsync(string streetName, int houseNumber, Pet pet);
        
        Task DeleteMemberFromFamilyAsync(string streetName, int houseNumber, string memberType, int memberId);
    }
}