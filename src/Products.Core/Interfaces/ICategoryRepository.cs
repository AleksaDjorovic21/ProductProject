using Products.Core.Domain;

namespace Products.Core.Interfaces;

public interface ICategoryRepository
{
    Task<Category> GetByIdAsync(int categoryId);
    Task<List<Category>> GetAllAsync();
    Task AddAsync(Category category);
    Task UpdateAsync(Category category);
    Task DeleteAsync(int categoryId);
}

