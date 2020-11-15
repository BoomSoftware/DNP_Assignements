using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyWebAPI.Models;

namespace FamilyWebAPI.Data.Implementation
{
    public class FamilyServiceImpl : IFamilyRepo
    {
        private IDataAccessService dataService;

        public FamilyServiceImpl(IDataAccessService dataService)
        {
            this.dataService = dataService;
        }

        public async Task<IList<Family>> GetAllFamiliesAsync()
        {
            return await dataService.GetAllFamiliesAsync();
        }

        public async Task<Family> GetFamilyByAddress(string streetName, int? houseNumber)
        {
            if (!string.IsNullOrEmpty(streetName) && houseNumber != null)
            {
                return await dataService.GetFamilyByAddressAsync(streetName, houseNumber.Value);
            }
            //ask troels about it
            return null;
        }

        public async Task CreateFamilyAsync(Family family)
        {
            await dataService.AddFamilyAsync(family);
        }

        public async Task UpdateFamilyAsync(Family family)
        {
            await dataService.UpdateFamilyAsync(family);
        }

        public async Task DeleteFamilyAsync(string streetName, int? houseNumber)
        {
            if (!string.IsNullOrEmpty(streetName) && houseNumber != null)
            {
                await dataService.DeleteFamilyAsync(streetName, houseNumber.Value);
            }
        }

        public async Task AddAdultToFamilyAsync(string streetName, int houseNumber, Adult adult)
        {
            if (adult != null)
            {
                await dataService.AddAdultToFamilyAsync(streetName, houseNumber, adult);
            }
        }

        public async Task AddChildToFamilyAsync(string streetName, int houseNumber, Child child)
        {
            if (child != null)
            {
                await dataService.AddChildToFamilyAsync(streetName, houseNumber, child);
            }
        }

        public async Task AddPetToFamilyAsync(string streetName, int houseNumber, Pet pet)
        {
            if (pet != null)
            {
                await dataService.AddPetToFamilyAsync(streetName, houseNumber, pet);
            }
        }

        public async Task UpdateAdultInFamilyAsync(string streetName, int houseNumber, Adult adult)
        {
            if (adult != null)
            {
                await dataService.UpdateAdultInFamilyAsync(streetName, houseNumber, adult);
            }
        }

        public async Task UpdateChildInFamilyAsync(string streetName, int houseNumber, Child child)
        {
            if (child != null)
            {
                await dataService.UpdateChildInFamilyAsync(streetName, houseNumber, child);
            }
        }

        public async Task UpdatePetInFamilyAsync(string streetName, int houseNumber, Pet pet)
        {
            if (pet != null)
            {
                await dataService.UpdatePetInFamilyAsync(streetName, houseNumber, pet);
            }
        }

        public async Task DeleteMemberFromFamilyAsync(string streetName, int houseNumber, string memberType, int memberId)
        {
            switch (memberType)
            {
                case "adults":
                    await dataService.DeleteAdultFromFamilyAsync(streetName, houseNumber, memberId);
                    break;
                case "children":
                    await dataService.DeleteChildFromFamilyAsync(streetName, houseNumber, memberId);
                    break;
                case "pets":
                    await dataService.DeletePetFromFamilyAsync(streetName, houseNumber, memberId);
                    break;
            }
        }
    }
}