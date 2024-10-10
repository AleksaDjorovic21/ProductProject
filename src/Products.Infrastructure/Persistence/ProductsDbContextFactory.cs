using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Products.Infrastructure.Persistence;

//IDesignTimeDbContextFactory<>: An interface that allows you to create a DbContext at design time.
public class ProductsDbContextFactory : IDesignTimeDbContextFactory<ProductsDbContext>
{
    public ProductsDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
        .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..\\Products.Api"))
        .AddJsonFile("appsettings.json")
        .Build();

        var optionsBuilder = new DbContextOptionsBuilder<ProductsDbContext>();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly("Products.Infrastructure"));

        return new ProductsDbContext(optionsBuilder.Options);
    }
}