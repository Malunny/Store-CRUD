namespace StoreSystem.Models.DataEntities;

public class DepartmentEntity : StrongEntity
{
    public string Name { get; set; }
    public DateTime CreationDate { get; set; }
    public DepartmentEntity() : base()
    {
        Table = Table with
        {
            Name = "Departments"
        };
    }
}