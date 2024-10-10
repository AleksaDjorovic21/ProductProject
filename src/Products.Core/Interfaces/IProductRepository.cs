using Products.Core.Domain;
using Products.Core.DTOs;

namespace Products.Core.Interfaces;

public interface IProductRepository
{
    Task AddAsync(Product product);
    Task<Product> GetByIdAsync(int id);
    Task<IEnumerable<Product>> GetAllAsync();
    Task UpdateAsync(Product product);
    Task DeleteAsync(int id);
    Task<bool> CategoryExistsAsync(int categoryId);
    Task<IEnumerable<ProductDto>> GetProductsWithCategoriesAsync();
}

