using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ASiteToOrderStuff.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<ASiteToOrderStuffDbContext>();
                if (!context.Products.Any())
                {
                    var products = new List<Product>
                    {
                        new Product { Amount = 50, Name = "Sweatshirt" },
                        new Product { Amount = 30, Name = "T-Shirt" },
                        new Product { Amount = 5, Name = "Sticker Pack" },
                        new Product { Amount = 15, Name = "Mug" },
                        new Product { Amount = 10, Name = "Coasters" },
                    };
                    context.AddRange(products);
                    context.SaveChanges();
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
