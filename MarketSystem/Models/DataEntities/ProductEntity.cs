namespace StoreSystem.Models.DataEntities;

public class ProductEntity : StrongEntity
{
  public int SubCategoryId { get; set; }
  public string Name { get; set; }
  public string? Description { get; set; }
  public decimal Price { get; set; }
  public string? ImageUrl { get; set; }

  public ProductEntity()
  {
    Table = Table with {Name = "Products"};
  }
}
