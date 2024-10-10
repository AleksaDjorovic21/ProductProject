using Microsoft.AspNetCore.Mvc;
using Products.Core.Domain;
using Products.Core.DTOs;

namespace Products.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet("with-categories")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsWithCategories()
    {
        var productsWithCategories = await _unitOfWork.Products.GetProductsWithCategoriesAsync();
        return Ok(productsWithCategories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(id);
        if (product == null)
            return NotFound();

        var productDto = new ProductDto
        {
            ProductId = product.ProductId,
            ProductName = product.ProductName,
            Price = product.Price,
            Description = product.Description,
            StockQuantity = product.StockQuantity,
            CreatedAt = product.CreatedAt,
            CategoryId = product.ProductCategories?.FirstOrDefault()?.CategoryId ?? 0
        };

        return Ok(productDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(ProductDto productDto)
    {
        var categoryExists = await _unitOfWork.Products.CategoryExistsAsync(productDto.CategoryId);
        if (!categoryExists)
        {
            return BadRequest("The specified category does not exist.");
        }

        var product = new Product
        {
            ProductName = productDto.ProductName,
            Price = productDto.Price,
            Description = productDto.Description,
            CreatedAt = DateTime.UtcNow,
            StockQuantity = productDto.StockQuantity,
            ProductCategories = new List<ProductCategory>
            {
                new ProductCategory { CategoryId = productDto.CategoryId }
            }
        };

        await _unitOfWork.Products.AddAsync(product);
        await _unitOfWork.SaveAsync(); 

        return CreatedAtAction(nameof(GetProductById), new { id = product.ProductId }, product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDto productDto)
    {
        var existingProduct = await _unitOfWork.Products.GetByIdAsync(id);
        if (existingProduct == null)
            return NotFound();

        existingProduct.ProductName = productDto.ProductName;
        existingProduct.Price = productDto.Price;
        existingProduct.Description = productDto.Description;
        existingProduct.StockQuantity = productDto.StockQuantity;

        await _unitOfWork.Products.UpdateAsync(existingProduct);
        await _unitOfWork.SaveAsync(); 

        return NoContent(); 
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(id);
        if (product == null)
            return NotFound();

        await _unitOfWork.Products.DeleteAsync(id);
        await _unitOfWork.SaveAsync(); 

        return NoContent();
    }
}

