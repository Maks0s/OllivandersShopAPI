using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OllivandersShopAPI.Models.DTO
{
    public class PostWandDto
    {
        [Required]
        [MaxLength(25)]
        public string Core { get; set; }
        [Required]
        [MaxLength(15)]
        public string Wood { get; set; }
        [Required]
        [Range(6, 17)]
        [Column(TypeName = "decimal(4,2)")]
        public decimal LengthInInches { get; set; }
    }
}
