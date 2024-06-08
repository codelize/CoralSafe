using System.ComponentModel.DataAnnotations;

namespace CoralSafe.DTO
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }

    }
}
