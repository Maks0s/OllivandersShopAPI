using Microsoft.EntityFrameworkCore;
using OllivandersShopAPI.Models;

namespace OllivandersShopAPI.Data.Seeder
{
    public class DataSeederMiddleware
    {
        private readonly RequestDelegate _next;
        public DataSeederMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, OllivandersShopDbContext dbContext)
        {
            dbContext.Wands.ExecuteDelete();
            SeedData(dbContext);
            await _next.Invoke(context);
        }

        private void SeedData(OllivandersShopDbContext dbContext)
        {
            var elderWand = new Wand
            {
                Core = "Thestral Tail Hair",
                Wood = "Elder Wood",
                LengthInInches = 15,
                TrueOwner = "Albus Dumbledore"
            };

            var harryPotterWand = new Wand
            {
                Core = "Phoenix Feather",
                Wood = "Holly Wood",
                LengthInInches = 11,
                TrueOwner = "Harry Potter"
            };

            var hermioneWand = new Wand
            {
                Core = "Dragon Heartstring",
                Wood = "Vine Wood",
                LengthInInches = 10.75M,
                TrueOwner = "Hermione Granger"
            };

            var ronWand = new Wand
            {
                Core = "Unicorn Hair",
                Wood = "Willow Wood",
                LengthInInches = 14,
                TrueOwner = "Ron Weasley"
            };

            var voldemortWand = new Wand
            {
                Core = "Phoenix Feather",
                Wood = "Yew Wood",
                LengthInInches = 13.5M,
                TrueOwner = "Lord Voldemort"
            };

            var bellatrixWand = new Wand
            {
                Core = "Dragon Heartstring",
                Wood = "Walnut Wood",
                LengthInInches = 12.75M,
                TrueOwner = "Bellatrix Lestrange"
            };

            dbContext.Wands.AddRange(elderWand, harryPotterWand, hermioneWand, ronWand, voldemortWand, bellatrixWand);

            dbContext.SaveChanges();
        }
    }
}
