using Birlik.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Birlik.Api.Preparations
{
    public static class MigrationImplementer
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<BirlikDbContext>());
            }
        }
        public static void SeedData(BirlikDbContext context)
        {
            System.Console.WriteLine("Applying migrations...");
            context.Database.Migrate();
        }
    }
}