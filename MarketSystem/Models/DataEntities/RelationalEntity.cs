namespace StoreSystem.Models.DataEntities;

public abstract class RelationalEntity : BaseDataModel
{
    public IEnumerable<string> GetRelationalColumns()
    {
       ICollection<string> properties = [];
       foreach (var prop in this.GetType().GetProperties())
        if (prop.Name != "Table")
            properties.Add($"{prop.Name}");
      return properties ?? [];
    }

    public DynamicParameters GetRelationalDynamicParameters()
    {
        var propertiesAndValues = new DynamicParameters();
        var modelProperties = this.GetType().GetProperties();

        foreach (var prop in modelProperties)
        {
            var value = prop.GetValue(this);

            if (prop.PropertyType.IsPrimitive ||
                prop.PropertyType == typeof(decimal) ||
                prop.PropertyType == typeof(string) ||
                prop.PropertyType == typeof(DateTime) ||
                prop.PropertyType.IsEnum)
            {
                if (prop.Name != "Id" && prop.Name != "Table" && prop.Name.Contains("Id"))
                    propertiesAndValues.Add("@" + prop.Name, value);
            }
        }
        return propertiesAndValues;
    }
}