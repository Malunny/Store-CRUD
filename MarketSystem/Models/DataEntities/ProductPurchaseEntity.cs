namespace StoreSystem.Models.DataEntities;

public class ProductPurchaseEntity : RelationalEntity
{
  public int PurchaseId { get; set; }
  public int ProductId { get; set; }
  public ProductPurchaseEntity()
  {
    Table = Table with { Name = "ProductPurchase" };
  }
}
