using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoralSafe.Models
{
    [Table("T_CORALSAFE_ONG")]
    public class Ong
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column("NOME_ONG")]
        public string Name { get; set; }
        [Required]
        [Column("DESCRICAO")]
        public string Description { get; set; }
        [Required]
        [Column("DATA_CRIACAO")]
        public DateTime CreatedOng { get; set; }
        [Required]
        [Column("ENDERECO")]
        public string endereco { get; set; }
        [Required]
        [Column("ESTADO")]
        public string estado { get; set; }
        [Required]
        [Column("TELEFONE_ONG")]
        public long telefone { get; set; }
        [Required]
        [EmailAddress]
        [Column("EMAIL_ONG")]
        public string email { get; set; }
        [Required]
        [Column("CNPJ")]
        public long cnpj { get; set; }
        public ICollection<Campanha> Campanhas { get; set; } = [];

    }
}
