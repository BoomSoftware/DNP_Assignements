using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FamilyWebAPI.Models
{
    public class Family
    {
        [Required] 
        public string StreetName { get; set; }
        
        [Required] 
        public int HouseNumber { get; set; }
        
        public List<Adult> Adults { get; set; }
        
        public List<Child> Children { get; set; }
        
        public List<Pet> Pets { get; set; }

        public Family()
        {
            Adults = new List<Adult>();
            Children = new List<Child>();
            Pets = new List<Pet>();
        }

        public void EditFamily(Family family)
        {
            StreetName = family.StreetName;
            HouseNumber = family.HouseNumber;
            Adults = family.Adults;
            Children = family.Children;
            Pets = family.Pets;
        }

        public void AddPerson(Person person, string memberType)
        {
            if (memberType.Equals("Adult"))
            {
                Adults.Add((Adult) person);
                Console.WriteLine("\t\tSuccessfully added adult");
            }

            if (memberType.Equals("Child"))
            {
                Children.Add((Child) person);
                Console.WriteLine("\t\tSuccessfully added child");
            }
        }

        public void AddPet(Pet pet)
        {
            Pets.Add(pet);
            Console.WriteLine("\t\tSuccessfully added pet");
        }

        public void EditAdult(Adult updatedAdult)
        {
            foreach (var adult in Adults)
            {
                if (adult.Id == updatedAdult.Id)
                {
                    Console.WriteLine("\t\tSuccessfully updated adult");
                }
            }
        }

        public void EditChild(Child updatedChild)
        {
            foreach (var child in Children)
            {
                if (child.Id == updatedChild.Id)
                {
                    child.Update(updatedChild);
                    Console.WriteLine("\t\tSuccessfully updated child");
                }
            } 
        }

        public void EditPet(Pet updatedPet)
        {
            Console.WriteLine("Editing pets " + Pets.Count);
            Console.WriteLine("Updated pet is " + updatedPet.Name);
            foreach (var pet in Pets)
            {
                if (pet.Id == updatedPet.Id)
                {
                    pet.Update(updatedPet);
                    Console.WriteLine("\t\tSuccessfully updated pet");
                }
            }
        }
        
        public void RemoveMember(string memberType, int id)
        {
            if (memberType.Equals("Adult"))
            {
                Adults.RemoveAll(adult => adult.Id == id);
                Console.WriteLine("\t\tSuccessfully removed adult");
            }

            if (memberType.Equals("Child"))
            {
                Children.RemoveAll(child => child.Id == id);
                Console.WriteLine("\t\tSuccessfully removed child");
            }
        }

        public void RemovePet(int id)
        {
            Console.WriteLine("\t\tSuccessfully removed pet");
            Pets.RemoveAll(pet => pet.Id == id);
        }
    }
}