namespace StoreSystem.Models.DataEntities;

public record Table(string Name, params IList<string> columns);