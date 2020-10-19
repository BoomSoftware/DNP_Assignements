using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Family
    {
        public int Id { get; set; }
        [Required] public string StreetName { get; set; }
        [Required] public int HouseNumber { get; set; }
        public List<Adult> Adults { get; set; }
        public List<Child> Children { get; set; }
        public List<Pet> Pets { get; set; }

        public Family()
        {
            Adults = new List<Adult>();
            Children = new List<Child>();
            Pets = new List<Pet>();
        }

        public void AddPerson(Person person, string memberType)
        {
            if (memberType.Equals("Adult"))
            {
                Adults.Add((Adult) person);
                Console.WriteLine(person);
            }

            if (memberType.Equals("Child"))
            {
                Children.Add((Child) person);
            }
        }

        public void AddPet(Pet pet)
        {
            Pets.Add(pet);
        }

        public void EditAdult(Adult updatedAdult)
        {
            foreach (var adult in Adults)
            {
                if (adult.Id == updatedAdult.Id)
                {
                    adult.Update(updatedAdult);
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
                }
            } 
        }

        public void EditPet(Pet updatedPet)
        {
            foreach (var pet in Pets)
            {
                if (pet.Id == updatedPet.Id)
                {
                    pet.Update(updatedPet);
                }
            }
        }
        
        public void RemoveMember(string memberType, int id)
        {
            if (memberType.Equals("Adult"))
            {
                Adults.RemoveAll(adult => adult.Id == id);
            }

            if (memberType.Equals("Child"))
            {
                Children.RemoveAll(child => child.Id == id);
            }
        }

        public void RemovePet(int id)
        {
            Pets.RemoveAll(pet => pet.Id == id);
        }
    }
}