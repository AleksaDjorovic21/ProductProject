using Microsoft.EntityFrameworkCore;
using Products.Core.Domain;
using Products.Core.DTOs;
using Products.Core.Interfaces;
using Products.Infrastructure.Persistence;

namespace Products.Infrastructure.Repositories;

public class ProductRepository(ProductsDbContext productsDbContext) 
    : IProductRepository
{
    private readonly ProductsDbContext _productsDbContext = productsDbContext;

    public async Task AddAsync(Product product)
    {
        await _productsDbContext.AddAsync(product);
        await _productsDbContext.SaveChangesAsync();
    }

    public async Task<bool> CategoryExistsAsync(int categoryId)
    {
        return await _productsDbContext.Categories.AnyAsync(c => c.CategoryId == categoryId);
    }

    public async Task DeleteAsync(int id)
    {
        var product = await GetByIdAsync(id);
        if (product != null)
        {
            _productsDbContext.Products.Remove(product);
            await _productsDbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _productsDbContext.Products.ToListAsync();
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        var product = await _productsDbContext.Products.FindAsync(id) 
            ?? throw new Exception($"Product with ID: {id} is not found.");

        return product;
    }

    public async Task<IEnumerable<ProductDto>> GetProductsWithCategoriesAsync()
    {
        var products = await _productsDbContext.Products
            .Include(p => p.ProductCategories)
                .ThenInclude(pc => pc.Category)
            .ToListAsync();

        foreach (var product in products)
        {
            if (product.ProductCategories.Any())
            {
                var categoryNames = string.Join(", ", product.ProductCategories.Select(pc => pc.Category?.CategoryName 
                    ?? "No Category"));

                Console.WriteLine($"ProductId: {product.ProductId}, Categories: {categoryNames}");
            }
            else
            {
                Console.WriteLine($"ProductId: {product.ProductId}, No categories found");
            }
        }

        return products.Select(p => new ProductDto
        {
            ProductId = p.ProductId,
            ProductName = p.ProductName,
            Price = p.Price,
            Description = p.Description,
            StockQuantity = p.StockQuantity,
            CreatedAt = p.CreatedAt,
            CategoryId = p.ProductCategories.FirstOrDefault()?.CategoryId ?? 0, 
            CategoryName = p.ProductCategories.FirstOrDefault()?.Category?.CategoryName ?? string.Empty, 
        }).ToList();
    }

    public async Task UpdateAsync(Product product)
    {
        _productsDbContext.Products.Update(product);
        await _productsDbContext.SaveChangesAsync();
    }
}