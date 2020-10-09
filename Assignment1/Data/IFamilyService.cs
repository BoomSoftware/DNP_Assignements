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
    }
}