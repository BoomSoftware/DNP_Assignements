using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FamilyWebAPI.Models
{
    public class APIUser
    {
        [Key]
        [JsonPropertyName("username")]
        [Required]
        public string Username { get; set; }
        
        [JsonPropertyName("password")]
        [Required]
        public string Password { get; set; }
        
        [JsonPropertyName("securityLevel")]
        public string SecurityLevel { get; set; }
    }
}