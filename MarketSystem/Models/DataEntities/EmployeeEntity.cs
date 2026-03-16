namespace StoreSystem.Models.DataEntities;

public class EmployeeEntity : StrongEntity
{
    public int PositionId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string ContactNumber { get; set; }
    public DateTime BirthDate { get; set; }

    public EmployeeEntity()
    {
        Table = Table with { Name = "Employees" };
    }
}