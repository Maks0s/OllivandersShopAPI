using System.ComponentModel.DataAnnotations;

namespace OllivandersShopAPI.Models
{
    public class Wand
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Core { get; set; }
        [Required]
        [MaxLength(10)]
        public string Wood { get; set; }
        [Required]
        [Range(6, 17)]
        public decimal LengthInInches { get; set; }
        [MaxLength(80)]
        public string? TrueOwner { get; set; }
    }

}
