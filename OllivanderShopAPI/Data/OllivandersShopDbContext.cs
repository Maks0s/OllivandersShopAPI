using Microsoft.EntityFrameworkCore;
using OllivandersShopAPI.Models;

namespace OllivandersShopAPI.Data
{
    public class OllivandersShopDbContext : DbContext
    {
        public DbSet<Wand> Wands { get; set; }

        public OllivandersShopDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
