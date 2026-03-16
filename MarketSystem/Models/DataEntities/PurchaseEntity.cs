namespace StoreSystem.Models.DataEntities;

public class PurchaseEntity : StrongEntity
{
  public int ClientId { get; set; }
  public int EmployeeId { get; set; }
  public int NumberProducts { get; set; }
  public decimal TotalPrice { get; set; }
  public DateTime Date { get; set; }

  public PurchaseEntity()
  {
    Table = Table with {Name = "Purchases"};
  }
}