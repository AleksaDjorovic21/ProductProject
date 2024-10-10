using Microsoft.AspNetCore.Mvc;
using Products.Api.DTOs;
using Products.Core.Domain;
using Products.Core.Interfaces;

namespace Products.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController(ICategoryRepository categoryRepository) 
    : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await _categoryRepository.GetAllAsync();
        return Ok(categories);
    }

    [HttpGet("{id}", Name = "GetCategoryById")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        
        if (category == null)
            return NotFound();
        
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CategoryDto categoryDto)
    {
        var category = new Category
        {
            CategoryName = categoryDto.CategoryName,
            CreatedAt = DateTime.UtcNow
        };

        await _categoryRepository.AddAsync(category);

        if (category.CategoryId == 0) 
        {
            return StatusCode(500, "Category ID was not generated.");
        }

        return CreatedAtRoute("GetCategoryById", new { id = category.CategoryId }, category);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category category)
    {
        if (id != category.CategoryId)
            return BadRequest("Category ID mismatch");

        await _categoryRepository.UpdateAsync(category);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        await _categoryRepository.DeleteAsync(id);
        return NoContent();
    }
}

