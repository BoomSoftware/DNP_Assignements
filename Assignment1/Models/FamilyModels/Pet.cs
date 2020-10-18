using System.ComponentModel.DataAnnotations;

namespace Models {
public class Pet {
    public int Id { get; set; }
    [Required]
    public string Species { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int Age { get; set; }
    
    public void Update(Pet pet)
    {
        Species = pet.Species;
        Name = pet.Name;
        Age = pet.Age;
    }
}
}