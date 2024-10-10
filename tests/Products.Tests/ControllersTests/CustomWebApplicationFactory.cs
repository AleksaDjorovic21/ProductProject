using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Products.Core.Domain;
using Products.Infrastructure.Persistence;

namespace Products.Tests.Controllers;

public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ProductsDbContext>));
            if (descriptor != null)
            {
                services.Remove(descriptor);
            }

            services.AddDbContext<ProductsDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDbForTesting");
            });

            // Build the service provider
            var serviceProvider = services.BuildServiceProvider();

            // Create a scope to initialize the database
            using (var scope = serviceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var context = scopedServices.GetRequiredService<ProductsDbContext>();

                context.Database.EnsureCreated();

                // Seed the database with test data
                SeedDatabase(context);
            }
        });
    }

    private void SeedDatabase(ProductsDbContext context)
    {
        context.Categories.AddRange(
        new Category { CategoryId = 1, CategoryName = "Category 1" },
        new Category { CategoryId = 2, CategoryName = "Category 2" }
    );
    context.SaveChanges();

        context.Products.AddRange(
            new Product { ProductId = 1, ProductName = "Product 1", Description = "Description 1", Price = 10.99m },
            new Product { ProductId = 2, ProductName = "Product 2", Description = "Description 2", Price = 20.99m },
            new Product { ProductId = 3, ProductName = "Product 3", Description = "Description 3", Price = 30.99m }
        );
        context.SaveChanges();
    }
}

