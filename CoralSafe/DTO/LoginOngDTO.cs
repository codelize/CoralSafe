using System.ComponentModel.DataAnnotations;

namespace CoralSafe.DTO
{
    public class LoginOngDTO
    {
        [Required]
        [EmailAddress]
        public string email { get; set; }
    }
}
