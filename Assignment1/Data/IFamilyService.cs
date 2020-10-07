using System.Collections.Generic;
using Models;

namespace Assignment1.Data
{
    public interface IFamilyService
    {
        List<Family> GetAllFamilies();
        void WriteAllFamilies(IList<Family> families);
    }
}