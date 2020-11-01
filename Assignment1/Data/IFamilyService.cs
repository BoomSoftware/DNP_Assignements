using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Assignment1.Data
{
    public interface IFamilyService
    {
        Task<List<Family>> GetAllFamiliesAsync();
       // void WriteAllFamilies(List<Family> families);
        Task CreateFamilyAsync(Family family);
        Task UpdateFamilyAsync(Family family);
        Task DeleteFamilyAsync(Family family);
        Task EditPersonAsync(Family family, Person person);

        Task EditPetAsync(Family family, Pet pet);
        Task AddPersonAsync(Family family, Person person, string memberType);

        Task AddPetAsync(Family family, Pet pet);
        Task RemovePersonAsync(Family family, Person person, string memberType);
        Task RemovePetAsync(Family family, Pet pet);

        List<Family> GetCachedFamilies();
    }
}