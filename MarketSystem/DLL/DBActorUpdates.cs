using StoreSystem;
using StoreSystem.Models.DataEntities;
using StoreSystem.Models.QueryComposition;
using System.Text;
using System;

namespace StoreSystem.Data;

public partial class DBActor
{
    public void Update<TItem>(TItem newItem) where TItem : StrongEntity, new()
    {
        WhereCondition condition = new("Id", newItem.Id.ToString(),
             Models.QueryComposition.EComparers.Equal);
        
        StringBuilder sqlQuery = new 
        ($"""
            UPDATE [{newItem.Table.Name}]
            SET
        """);

        var columns = newItem.Table.columns;

        for (int i = 0; i < columns.Count; i++)
        {
            if (i < columns.Count - 1)
                sqlQuery.Append($" {columns[i]} = @{columns[i]},");
            else
                sqlQuery.Append($" {columns[i]} = @{columns[i]}" + Environment.NewLine);
        }

        sqlQuery.Append($"WHERE {condition};");
        
        _sqlConnection.Execute(sqlQuery.ToString(), newItem.GetPropertiesDynParams());
    }
}