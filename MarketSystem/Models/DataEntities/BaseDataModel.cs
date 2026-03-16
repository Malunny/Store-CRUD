using System.Text;
using Dapper.Contrib.Extensions;

namespace StoreSystem.Models.DataEntities;

public abstract class BaseDataModel
{
    public Table Table { get; init; } 
    public string GetInsert()
    {
        StringBuilder insert = new($"INSERT INTO [{Table.Name}]"+ Environment.NewLine);

        int maxIterationn = Table.columns.Count();

        for (int i = 0; i < maxIterationn; i++)
        {
            if(i == 0)
                insert.Append("(");
            if (i != maxIterationn - 1)
                insert.Append($"[{Table.columns[i]}], " + Environment.NewLine);
            else
                insert.Append($"[{Table.columns[i]}])" + Environment.NewLine);
        }
            
        insert.Append("VALUES" + Environment.NewLine);

        for (int i = 0; i < maxIterationn; i++)
        {
            if(i == 0)
                insert.Append("(");
            if (i != maxIterationn - 1)
                insert.Append($"@{Table.columns[i]}, " + Environment.NewLine);
            else
                insert.Append($"@{Table.columns[i]})" + Environment.NewLine);
        }

        return insert.ToString();
    }
    public DynamicParameters GetPropertiesDynParams()
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
                if (prop.Name != "Id" && prop.Name != "Table")
                    propertiesAndValues.Add("@" + prop.Name, value);
            }
        }
        return propertiesAndValues;
    }
    public BaseDataModel()
    {
        var columnsProps = this.GetType().GetProperties();

        IList<string> columns = new List<string>();

        foreach(var column in columnsProps)
            if (column.Name != "Id" && column.Name != "Table" && column.Name != "TableName")
                columns.Add(column.Name);
                
        Table = new("Item", columns);
    }
}