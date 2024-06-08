using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoralSafe.Models
{
    [Table("T_CORALSAFE_USUARIO")]
    public class User
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(100)]
        [Column("Name_Usuario")]
        public string name { get; set; }
        [Required]
        [Column("Email_Usuario")]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        [Column("Senha_Do_Usuario")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required]
        [Column("Status_Usuario")]
        public int IsActive { get; set; } = 1;
        [Required]
        [Column("Data_Cadastro")]
        public DateTime timeRegister { get; set; } = DateTime.UtcNow;
        [Required]
        [Column("Pontos")]
        public int pontos { get; set; } = 0;
        [Required]
        public ICollection<Donate> donates { get; set; } = new List<Donate>();



    }
}
