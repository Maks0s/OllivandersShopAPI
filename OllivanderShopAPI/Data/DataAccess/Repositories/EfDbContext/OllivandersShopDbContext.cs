using Microsoft.EntityFrameworkCore;
using OllivandersShopAPI.Models;

namespace OllivandersShopAPI.Data.DataAccess.Repositories.EfDbContext
{
    public class OllivandersShopDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Wand> Wands { get; set; }

        public OllivandersShopDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
