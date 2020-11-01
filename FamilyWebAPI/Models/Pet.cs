using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FamilyWebAPI.Models
{
    public class Pet
    {
        //[JsonPropertyName("id")]
        public int Id { get; set; }
    
        //[JsonPropertyName("species")]
        [Required]
        public string Species { get; set; }
    
       // [JsonPropertyName("name")]
        [Required]
        public string Name { get; set; }
    
        //[JsonPropertyName("age")]
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