using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoralSafe.Models
{
    [Table("T_CORALSAFE_APOIO")]
    public class Donate
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column("Valor_Doado")]
        public float Valor { get; set; }
        [Required]
        [Column("Data_Doacao")]
        public DateTime DataDonate { get; set; } = DateTime.Now;
        [Required]
        [Column("Id_Doador")]
        public int idUserDonate { get; set; }

        [ForeignKey("idUserDonate")]
        public User? User { get; set; }
    }
}
