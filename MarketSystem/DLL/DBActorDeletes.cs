using StoreSystem;
using StoreSystem.Models;
using System.Text;
using System;
using StoreSystem.Models.DataEntities;

namespace StoreSystem.Data;

public partial class DBActor
{
    public int Delete(StrongEntity entity)
    {
        int id = entity.Id;
        _sqlConnection.Execute($"DELETE FROM [{entity.Table.Name}] WHERE [Id] = @Id", new { Id = entity.Id});
        return id;
    }
    public void Delete(RelationalEntity entity)
    {
        StringBuilder query = new($"DELETE FROM [{entity.Table.Name}] WHERE");

        var relationalColumns = entity.GetRelationalColumns();
        int count = relationalColumns.Count();
        int nowCounter = 1;

        foreach (var relational in relationalColumns)
        {
            if (nowCounter < count)
                query.Append($"[{relational}] = @{relational} AND ");
            else
                query.Append($"[{relational}] = @{relational};");
            nowCounter++;
        }

        _sqlConnection.Execute(query.ToString(), entity.GetRelationalDynamicParameters());
    }
}