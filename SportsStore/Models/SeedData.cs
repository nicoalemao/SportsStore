using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(
            IApplicationBuilder app
        ){ 
            StoreDbContext context = 
                app.ApplicationServices
                    .CreateScope()
                    .ServiceProvider
                    .GetRequiredService<StoreDbContext>();

            if ( !context.Products.Any() )
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Perfume H20",
                        Category = "Cosmético",
                        Price = 150
                    },
                    new Product
                    {
                        Name = "Perfume Portinari",
                        Category = "Cosmético",
                        Price = 75
                    },
                    new Product
                    {
                        Name = "Perfume Ferrari",
                        Category = "Cosmético",
                        Price = 200
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
