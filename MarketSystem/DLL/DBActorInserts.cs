using StoreSystem;
using StoreSystem.Models.DataEntities;
using System.Text;
using System;

namespace StoreSystem.Data;

public partial class DBActor
{
    public int Insert(BaseDataModel item)
    {
        return _sqlConnection.ExecuteScalar<int>(item.GetInsert() + 
        " SELECT SCOPE_IDENTITY()", item.GetPropertiesDynParams());
    }

    public void Insert(IEnumerable<BaseDataModel> items)
    {
        if (items.Any())
        {
            List<DynamicParameters> itemsToInsert = new();
            string insert = items.ElementAt(0).GetInsert();

            foreach (var item in items)
                itemsToInsert.Add(item.GetPropertiesDynParams());
            _sqlConnection.Execute(insert, itemsToInsert);
        }
        else
            System.Console.WriteLine("There aren't Items on the insert");
    }
}