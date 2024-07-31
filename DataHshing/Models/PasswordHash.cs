using System.ComponentModel.DataAnnotations;

namespace DataHshing.Models
{
    public class PasswordHash
    {
        [Required,Display(Name = "Enter Password For Show Hashing")]
        public string Password { get; set; }
    }
}
