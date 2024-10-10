namespace Products.Core.Domain;

public class Category
{
    public int CategoryId {get; set;}
    public required string CategoryName {get; set;}
    public DateTime CreatedAt {get; set;}
    public ICollection<ProductCategory> ProductCategories { get; set; } = [];
}