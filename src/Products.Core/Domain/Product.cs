using System.Text.Json.Serialization;

namespace Products.Core.Domain;

public class Product
{
    public int ProductId {get; set;}
    public required string ProductName { get; set; }
    public required decimal Price {get; set;}
    public required string Description { get; set; }
    public int StockQuantity { get; set; }
    public DateTime CreatedAt {get; set;} = DateTime.UtcNow;

    [JsonIgnore]
    public ICollection<ProductCategory> ProductCategories { get; set; } = []; 
}