using System;
using System.Collections.Generic;
using Models;

namespace Assignment1.Data
{
    public interface IFamilyService
    {
        List<Family> GetAllFamilies();
       // void WriteAllFamilies(List<Family> families);
        void CreateFamily(Family family);
        void UpdateFamily(Family family);
        void DeleteFamily(Family family);
        Dictionary<string, int> GetNumberOfAdultsByEyeColor();
        void EditPerson(Family family, Person person);

        void EditPet(Family family, Pet pet);
        void AddPerson(Family family, Person person, string memberType);

        void AddPet(Family family, Pet pet);
        void RemovePerson(Family family, Person person, string memberType);
        void RemovePet(Family family, Pet pet);
    }
}