namespace Products.Core.DTOs;
public class UpdateProductDto
{
    public string ProductName { get; set; } = string.Empty;
    public decimal? Price { get; set; } 
    public string Description { get; set; }= string.Empty;
    public int? StockQuantity { get; set; } 
    public int? CategoryId { get; set; } 
}
