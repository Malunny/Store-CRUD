namespace StoreSystem.Models.DataEntities;
public class ProductSubCategory : StrongEntity
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public DateTime CreationDate { get; set; }
    public byte Active{ get; set; }

    public ProductSubCategory()
    {
        this.Table = Table with {Name = "ProductSubCategories"};
    }
}