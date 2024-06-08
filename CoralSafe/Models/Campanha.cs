using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoralSafe.Models
{
    [Table("T_CORALSAFE_CAMPANHA")]
    public class Campanha
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column("Name_Campanha")]
        public string name { get; set; }
        [Required]
        [Column("Descricao_Camapanha")]
        public string descricao { get; set; }
        [Required]
        [Column("Valor_Campanha")]
        public float valorMeta { get; set; }
        [Required]
        [Column("Data_Campanha")]
        public DateTime data_publicacao { get; set; } = DateTime.Now;
        public int OngId { get; set; }
        [ForeignKey("OngId")]
        public Ong? Ong { get; set; }
    }
}
