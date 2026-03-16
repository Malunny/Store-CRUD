using StoreSystem;
using StoreSystem.Models.DataEntities;
using StoreSystem.Models.QueryComposition;
using System.Text;
using System;
using StoreSystem.Models.DataBase;

namespace StoreSystem.Data;

public partial class DBActor
{
    public IEnumerable<IDictionary<string,object>> SelectView(EViews view)
    {
        List<IDictionary<string,object>> columnsWithValues = new();
        foreach(var item in _sqlConnection.Query($"SELECT * FROM [{Views.GetView(view)}]"))
        {
            columnsWithValues.Add((IDictionary<string,object>)item);
        }

        return columnsWithValues;
    }

    public IEnumerable<TItem> Select<TItem>() where TItem : BaseDataModel, new()
    {
        return _sqlConnection.Query<TItem>
        (
            $"""
                SELECT * FROM [{new TItem().Table.Name}];
            """
        );

    }
    public IEnumerable<TItem> Select<TItem>(WhereCondition where) where TItem : BaseDataModel, new()
    {
        StringBuilder query = new($"SELECT * FROM [{new TItem().Table.Name}]");
        query.Append(Environment.NewLine + $"WHERE {where.Property} {where.Comparer} {where.ConditionValue};");

        return _sqlConnection.Query<TItem>(query.ToString());
    }

    public IEnumerable<TItem> Select<TItem>
    (IEnumerable<WhereCondition> whereConditions) where TItem : BaseDataModel, new()
    {
        StringBuilder query = new($"SELECT * FROM [{new TItem().Table.Name}]" + Environment.NewLine +
        "WHERE ");
       
        int count = whereConditions.Count();
        int nowCount = 1;
        foreach(var condition in whereConditions)
        {
            if (nowCount < count)
                if(string.IsNullOrEmpty(condition.LogicalOperator))
                    query.Append(condition + "AND ");
                else 
                    query.Append(condition);
            else
                query.Append($"{condition.Property} {condition.Comparer} {condition.ConditionValue};");
            nowCount++;
        }

        return _sqlConnection.Query<TItem>(query.ToString());
    }
}