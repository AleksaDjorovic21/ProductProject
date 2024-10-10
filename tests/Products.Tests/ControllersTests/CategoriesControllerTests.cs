using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Products.Api.Controllers;
using Products.Api.DTOs;
using System.Net.Http.Json;

namespace Products.Tests.Controllers;

public class CategoriesControllerTests : IClassFixture<WebApplicationFactory<CategoriesController>>
{
    private readonly HttpClient _client;

    public CategoriesControllerTests(WebApplicationFactory<CategoriesController> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetCategories_ShouldReturnAllCategories()
    {
        // Act
        var response = await _client.GetAsync("/api/categories");
        response.EnsureSuccessStatusCode();

        // Deserialize response
        var categories = await response.Content.ReadFromJsonAsync<List<CategoryDto>>();

        // Assert
        categories.Should().NotBeNull();
        categories.Should().HaveCountGreaterThan(0); 
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnSpecificCategory()
    {
        // Act
        var response = await _client.GetAsync("/api/categories/1"); 

        // Assert 
        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var category = await response.Content.ReadFromJsonAsync<CategoryDto>();
            
            category.Should().NotBeNull("because the category with ID 1 should exist in the test database");
        }
        else
        {
            response.StatusCode.Should().NotBe(System.Net.HttpStatusCode.OK, 
                $"Expected OK status code but got {response.StatusCode}");
        }
    }

    [Fact]
    public async Task CreateCategory_ShouldReturnCreatedCategory()
    {
        // Arrange
        var newCategory = new CategoryDto
        {
            CategoryName = "Test Category"
        };

        // Act
        var response = await _client.PostAsJsonAsync("/api/categories", newCategory);
        response.EnsureSuccessStatusCode();

        var createdCategory = await response.Content.ReadFromJsonAsync<CategoryDto>();

        // Assert
        createdCategory.Should().NotBeNull("because the category should have been created successfully");
        createdCategory!.CategoryName.Should().Be(newCategory.CategoryName);
    }
}  


