using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OllivandersShopAPI.Models
{
    public class Wand
    {
        public int Id { get; set; }
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
        [MaxLength(80)]
        public string? TrueOwner { get; set; }
    }

}
