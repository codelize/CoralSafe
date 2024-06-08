using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoralSafe.Models
{
    [Table("T_CORALSAFE_PRODUTOS")]
    public class Produto
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Column("NOME")]
        public string Name { get; set; }
        [Required]
        [Column("DESCRICAO")]
        public string Description { get; set; }
        [Required]
        [Column("QUANTIDADE_PONTOS")]
        public int QntPontos { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
