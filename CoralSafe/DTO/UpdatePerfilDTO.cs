using System.ComponentModel.DataAnnotations;

namespace CoralSafe.DTO
{
    public class UpdatePerfilDTO
    {
        public string? name { get; set; }
        [EmailAddress]
        public string? email { get; set; }



    }
}
