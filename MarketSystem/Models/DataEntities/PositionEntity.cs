namespace StoreSystem.Models.DataEntities;

public class PositionEntity : StrongEntity
{
    public int DepartmentId { get; set; }
    public string Title { get; set; }
    public decimal Wage { get; set; }

    public PositionEntity()
    {
        Table = Table with { Name = "Positions" };
    }
}