using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyWebAPI.Models;
using FamilyWebAPI.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FamilyWebAPI.Data.Implementation
{
    public class FamilyRepo : IFamilyRepo
    {
        public async Task<IList<Family>> GetAllFamiliesAsync()
        {
            using (FamilyDbContext dbContext = new FamilyDbContext())
            {
                Console.WriteLine("\tGetting families");
                List<Family> families = dbContext.Families.Include(f => f.Adults)
                    .Include(f => f.Pets)
                    .Include(f => f.Children)
                    .ThenInclude(c => c.ChildInterests)
                    .ThenInclude(i => i.Interest)
                    .ToList();
                return families;
            }
        }

        public async Task<Family> GetFamilyByAddress(string streetName, int? houseNumber)
        {
            using (FamilyDbContext dbContext = new FamilyDbContext())
            {
                Console.WriteLine("\tGetting family at address");
                Family family = dbContext.Families.Where(f =>
                        f.StreetName.Equals(streetName) && f.HouseNumber == houseNumber)
                    .Include(f => f.Adults)
                    .Include(f => f.Pets)
                    .Include(f => f.Children)
                    .ThenInclude(c => c.ChildInterests)
                    .ThenInclude(i => i.Interest).FirstOrDefault();
                return family;
            }
        }

        public async Task CreateFamilyAsync(Family family)
        {
            Console.WriteLine("\tCreating family");
            using (FamilyDbContext dbContext = new FamilyDbContext())
            {
                await dbContext.Families.AddAsync(family);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateFamilyAsync(Family family)
        {
            Console.WriteLine("\tUpdating");
            using (FamilyDbContext dbContext = new FamilyDbContext())
            {
                dbContext.Update(family);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteFamilyAsync(string streetName, int? houseNumber)
        {
            Console.WriteLine("\tDeleting family");
            using (FamilyDbContext dbContext = new FamilyDbContext())
            {
                Family family = await GetFamilyByAddress(streetName, houseNumber);
                dbContext.Remove(family);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task AddAdultToFamilyAsync(string streetName, int houseNumber, Adult adult)
        {
            Console.WriteLine("\tAdding adult to family " + adult.Id);
            using (FamilyDbContext dbContext = new FamilyDbContext())
            {
                Family family = await GetFamilyByAddress(streetName, houseNumber);
                family.Adults.Add(adult);
                dbContext.Add(adult);
                dbContext.Update(family);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task AddChildToFamilyAsync(string streetName, int houseNumber, Child child)
        {
            Console.WriteLine("\tAdding child to family " + child.Id);
            using (FamilyDbContext dbContext = new FamilyDbContext())
            {
                Family family = await GetFamilyByAddress(streetName, houseNumber);
                family.Children.Add(child);
                dbContext.Add(child);
                dbContext.Update(family);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task AddPetToFamilyAsync(string streetName, int houseNumber, Pet pet)
        {
            Console.WriteLine("\tAdding pet to family " + pet.Id);
            using (FamilyDbContext dbContext = new FamilyDbContext())
            {
                Family family = await GetFamilyByAddress(streetName, houseNumber);
                family.Pets.Add(pet);
                dbContext.Add(pet);
                dbContext.Update(family);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateAdultInFamilyAsync(string streetName, int houseNumber, Adult adult)
        {
            Console.WriteLine("\tUpdating adult in family");
            using (FamilyDbContext dbContext = new FamilyDbContext())
            {
                Family family = await GetFamilyByAddress(streetName, houseNumber);
                family.EditAdult(adult);
                dbContext.Update(adult);
               // dbContext.Update(family);
               Console.WriteLine("Before saving changes");
                await dbContext.SaveChangesAsync();
                Console.WriteLine("Saved changes to update adult");
            }
        }

        public async Task UpdateChildInFamilyAsync(string streetName, int houseNumber, Child child)
        {
            Console.WriteLine("\tUpdating child in family");
            using (FamilyDbContext dbContext = new FamilyDbContext())
            {
                Family family = await GetFamilyByAddress(streetName, houseNumber);
                family.EditChild(child);
                dbContext.Update(child);
                //dbContext.Update(family);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdatePetInFamilyAsync(string streetName, int houseNumber, Pet pet)
        {
            Console.WriteLine("\tUpdating pet in family");
            using (FamilyDbContext dbContext = new FamilyDbContext())
            {
                Family family = await GetFamilyByAddress(streetName, houseNumber);
                family.EditPet(pet);
                dbContext.Update(pet);
                //dbContext.Update(family);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteMemberFromFamilyAsync(string streetName, int houseNumber, string memberType, int memberId)
        {
            Console.WriteLine("\tDeleting member from family");
            using (FamilyDbContext dbContext = new FamilyDbContext())
            {
                Family family = await GetFamilyByAddress(streetName, houseNumber);
                switch (memberType)
                {
                    case "adults":
                        Adult adult = family.Adults.First(a => a.Id == memberId);
                        dbContext.Remove(adult);
                        break;
                    case "children":
                        Child child = family.Children.First(c => c.Id == memberId);
                        dbContext.Remove(child);
                        break;
                    case "pets":
                        Pet pet = family.Pets.First(p => p.Id == memberId);
                        dbContext.Remove(pet);
                        break;
                }

                dbContext.Update(family);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}