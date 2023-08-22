using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OllivandersShopAPI.Models.DTO
{
    public class PutWandDto
    {
        [MaxLength(25)]
        public string Core { get; set; }
        [MaxLength(15)]
        public string Wood { get; set; }
        [Range(6, 17)]
        [Column(TypeName = "decimal(4,2)")]
        public decimal LengthInInches { get; set; }
        [MaxLength(80)]
        public string? TrueOwner { get; set; }
    }
}
