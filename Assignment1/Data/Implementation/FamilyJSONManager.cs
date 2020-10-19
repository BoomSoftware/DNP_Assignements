using System;
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

        public void EditPerson(Family family, Person person)
        {
            List<Family> families = GetAllFamilies();
            foreach (var f in families.ToList())
            {
                if (f.HouseNumber.Equals(family.HouseNumber) && f.StreetName.Equals(family.StreetName))
                {
                    if (person is Adult)
                    {
                        f.EditAdult((Adult)person);
                    }

                    if (person is Child)
                    {
                        f.EditChild((Child)person);
                    }
                    
                }
            }
            WriteFamiliesToFile(families);
            
        }

        public void EditPet(Family family, Pet pet)
        {
            List<Family> families = GetAllFamilies();
            foreach (var f in families.ToList())
            {
                if (f.HouseNumber.Equals(family.HouseNumber) && f.StreetName.Equals(family.StreetName))
                {
                    f.EditPet(pet);
                }
            }
            WriteFamiliesToFile(families);
        }

        public void AddPerson(Family family, Person person, string memberType)
        {
            List<Family> families = GetAllFamilies();
            foreach (var f in families)
            {
                if (f.HouseNumber.Equals(family.HouseNumber) && f.StreetName.Equals(family.StreetName))
                {
                    f.AddPerson(person, memberType);
                }
            }
            WriteFamiliesToFile(families);
        }

        public void AddPet(Family family, Pet pet)
        {
            List<Family> families = GetAllFamilies();
            foreach (var f in families)
            {
                if (f.HouseNumber.Equals(family.HouseNumber) && f.StreetName.Equals(family.StreetName))
                {
                    f.AddPet(pet);
                }
            }
            WriteFamiliesToFile(families);
        }

        public void RemovePerson(Family family, Person person, string memberType)
        {
            List<Family> families = GetAllFamilies();
            foreach (var f in families)
            {
                if (f.HouseNumber.Equals(family.HouseNumber) && f.StreetName.Equals(family.StreetName))
                {
                    f.RemoveMember(memberType, person.Id);
                }
            }
            WriteFamiliesToFile(families);
        }

        public void RemovePet(Family family, Pet pet)
        {
            List<Family> families = GetAllFamilies();
            foreach (var f in families)
            {
                if (f.HouseNumber.Equals(family.HouseNumber) && f.StreetName.Equals(family.StreetName))
                {
                    f.RemovePet(pet.Id);
                }
            }
            WriteFamiliesToFile(families);
        }

        private void WriteFamiliesToFile(List<Family> families)
        {
            string famList = JsonSerializer.Serialize(families, new JsonSerializerOptions {
                WriteIndented = true
            });
            File.WriteAllText(jsonFile,famList);
        }
    }
}