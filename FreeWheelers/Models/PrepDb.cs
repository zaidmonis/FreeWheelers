using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FreeWheelers.Models
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<ProductContext>());
            }
            
        }

        public static void SeedData(ProductContext context)
        {
            System.Console.WriteLine("Applying migrations...");
            
            context.Database.Migrate();

            if (!context.Products.Any())
            {
                System.Console.WriteLine("Adding data - seeding...");
                context.Products.AddRange(
                    new Product(){Name = "Some product"},
                    new Product(){Name = "Some Other product"},
                    new Product(){Name = "Another product"});
            }
            else
            {
                System.Console.WriteLine("Already have data - not seeding.");
            }

            context.SaveChanges();
        }
    }
}