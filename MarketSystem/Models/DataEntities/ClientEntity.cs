namespace StoreSystem.Models.DataEntities;

public class ClientEntity : StrongEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string ContactNumber { get; set; }
    public DateTime FirstVisit { get; set; }

    public ClientEntity()
    {
        Table = Table with {Name = "Clients"};
    }
}