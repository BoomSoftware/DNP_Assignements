using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FamilyWebAPI.Models
{
    public class Person
    {
        //[JsonPropertyName("id")]
        public int Id { get; set; }
    
        //[JsonPropertyName("firstName")]
        [Required]
        public string FirstName { get; set; }
    
        //[JsonPropertyName("lastName")]
        [Required]
        public string LastName { get; set; }
    
        //[JsonPropertyName("hairColor")]
        [Required]
        public string HairColor { get; set; }
    
        //[JsonPropertyName("eyeColor")]
        [Required]
        public string EyeColor { get; set; }
    
        //[JsonPropertyName("age")]
        [Required, Range(0, 125)]
        public int Age { get; set; }
    
        //[JsonPropertyName("weight")]
        [Required, Range(1, 250)]
        public float Weight { get; set; }
    
        //[JsonPropertyName("height")]
        [Required, Range(30, 250)]
        public int Height { get; set; }
    
        //[JsonPropertyName("sex")]
        [Required]
        public string Sex { get; set; }

        public void Update(Person toUpdate) {
            Age = toUpdate.Age;
            Height = toUpdate.Height;
            HairColor = toUpdate.HairColor;
            Sex = toUpdate.Sex;
            Weight = toUpdate.Weight;
            EyeColor = toUpdate.EyeColor;
            FirstName = toUpdate.FirstName;
            LastName = toUpdate.LastName;
        }
    }
}