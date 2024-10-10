using Microsoft.EntityFrameworkCore;
using Products.Core.Domain;
using Products.Core.Interfaces;
using Products.Infrastructure.Persistence;

namespace Products.Infrastructure.Repositories;

public class CategoryRepository(ProductsDbContext context) 
    : ICategoryRepository
{
    private readonly ProductsDbContext _context = context;

    public async Task<Category> GetByIdAsync(int categoryId)
    {
        var category =  await _context.Categories.FindAsync(categoryId)
             ?? throw new Exception($"Product with ID: {categoryId} is not found.");
        
        return category;
    }

    public async Task<List<Category>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task AddAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int categoryId)
    {
        var category = await GetByIdAsync(categoryId);
        if (category != null)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}

