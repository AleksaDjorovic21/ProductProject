using Products.Core.Interfaces;
using Products.Infrastructure.Persistence;

namespace Products.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ProductsDbContext _context;
    private IProductRepository _productRepository;
    private ICategoryRepository _categoryRepository;

    public UnitOfWork(ProductsDbContext context, IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _context = context;
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public IProductRepository Products => _productRepository ??= new ProductRepository(_context);
    public ICategoryRepository Categories => _categoryRepository ??= new CategoryRepository(_context);

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
