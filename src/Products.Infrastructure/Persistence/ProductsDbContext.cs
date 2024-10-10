using Microsoft.EntityFrameworkCore;
using Products.Core.Domain;

namespace Products.Infrastructure.Persistence;

public class ProductsDbContext(DbContextOptions<ProductsDbContext> options) 
    : DbContext(options)
{
    public DbSet<Product> Products {get; set;}
    public DbSet<Category> Categories {get; set;}
    public DbSet<ProductCategory> ProductCategories {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure many-to-many relationship
        modelBuilder.Entity<ProductCategory>()
            .HasKey(pc => new {pc.ProductId, pc.CategoryId});
        
        modelBuilder.Entity<ProductCategory>()
            .HasOne(pc => pc.Product)
            .WithMany(p => p.ProductCategories)
            .HasForeignKey(pc => pc.ProductId);

        modelBuilder.Entity<ProductCategory>()
            .HasOne(pc => pc.Category)
            .WithMany(c => c.ProductCategories)
            .HasForeignKey(pc => pc.CategoryId);
        
         // Specify precision and scale for Price
        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasColumnType("decimal(18, 2)");
        
        modelBuilder.Entity<Product>()
            .Property(p => p.ProductId)
            .ValueGeneratedOnAdd();
        
         modelBuilder.Entity<Category>()
            .Property(c => c.CategoryId)
            .ValueGeneratedOnAdd();
    }
}