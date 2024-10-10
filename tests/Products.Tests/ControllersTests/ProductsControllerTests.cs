using FluentAssertions;
using Products.Api.Controllers;
using Products.Core.DTOs;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Products.Tests.Controllers;

public class ProductsControllerTests : IClassFixture<CustomWebApplicationFactory<ProductsController>> 
{
    private readonly HttpClient _client;

    public ProductsControllerTests(CustomWebApplicationFactory<ProductsController> factory) 
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetProductsWithCategories_ShouldReturnProductsWithCategories()
    {
        // Act
        var response = await _client.GetAsync("/api/products/with-categories");
        response.EnsureSuccessStatusCode();

        // Deserialize response
        var products = await response.Content.ReadFromJsonAsync<List<ProductDto>>(new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
        });

        // Assert
        products.Should().NotBeNull();
        products.Should().HaveCountGreaterThan(0); 
    }

    [Fact]
    public async Task GetProductById_ShouldReturnSpecificProduct()
    {
        // Act
        var response = await _client.GetAsync("/api/products/1"); 
        response.EnsureSuccessStatusCode();

        // Deserialize response
        var product = await response.Content.ReadFromJsonAsync<ProductDto>(new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
        });

        // Assert
        product.Should().NotBeNull("because the product with ID 1 should exist in the test database"); 
        product!.ProductId.Should().Be(1); 
    }

    [Fact]
    public async Task CreateProduct_ShouldReturnCreatedProduct()
    {
        // Arrange
        var newProduct = new ProductDto
        {
            ProductName = "Test Product",
            Price = 10.99m,
            Description = "This is a test product.",
            StockQuantity = 100,
            CategoryId = 1 
        };

        // Act
        var response = await _client.PostAsJsonAsync("/api/products", newProduct);
        response.EnsureSuccessStatusCode();

        // Deserialize response
        var createdProduct = await response.Content.ReadFromJsonAsync<ProductDto>(new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
        });

        // Assert
        createdProduct.Should().NotBeNull("because the product should have been created successfully");
        createdProduct!.ProductName.Should().Be(newProduct.ProductName);
    }

    [Fact]
    public async Task UpdateProduct_ShouldReturnNoContent()
    {
        // Arrange
        var updatedProduct = new ProductDto
        {
            ProductName = "Updated Product",
            Price = 12.99m,
            Description = "This is an updated test product.",
            StockQuantity = 150,
            CategoryId = 1 
        };

        // Act
        var response = await _client.PutAsJsonAsync("/api/products/1", updatedProduct); 
        response.EnsureSuccessStatusCode();

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task DeleteProduct_ShouldReturnNoContent()
    {
        // Act
        var response = await _client.DeleteAsync("/api/products/1"); 
        response.EnsureSuccessStatusCode();

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
    }
}

