using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OllivandersShopAPI.Models.DTO
{
    public class GetWandDto
    {
        public string Core { get; set; }
        public string Wood { get; set; }
        public decimal LengthInInches { get; set; }
        public string? TrueOwner { get; set; }
    }
}
