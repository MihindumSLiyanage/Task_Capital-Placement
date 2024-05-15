using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Task.Models
{
    public class Employee
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [Required]
        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [Required]
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("idNumber")]
        [RegularExpression(@"^\d{10}V$", ErrorMessage = "Id number must be 10 digits followed by 'V'")]
        public string IdNumber { get; set; }

        [JsonProperty("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [JsonProperty("phoneNumber")]
        [RegularExpression(@"^0\d{9}$", ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("nationality")]
        public string Nationality { get; set; }

        [JsonProperty("currentResidence")]
        public string CurrentResidence { get; set; }

        [JsonProperty("gender")]
        public Gender Gender { get; set; }

        public List<string> QuestionIds { get; set; }
    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }
}
