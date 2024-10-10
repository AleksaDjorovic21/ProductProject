namespace Products.Core.DTOs;

public class ProductDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }= string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; }= string.Empty;
    public int StockQuantity { get; set; }
    public DateTime CreatedAt { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }= string.Empty;
}

