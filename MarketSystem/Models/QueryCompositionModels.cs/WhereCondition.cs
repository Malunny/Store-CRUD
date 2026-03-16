namespace StoreSystem.Models.QueryComposition;

public struct WhereCondition
{
    public string Property 
    { 
        get => $"[{field}]";
    } 
    public string Comparer { get; }
    public string ConditionValue 
    {
         get => (int.TryParse(field, out int result) ? result.ToString() : $"'{field}'");
    }
    public string LogicalOperator { get; } = "";

    public WhereCondition(string property, string condition, EComparers comparer)
    {
        Property = property;
        ConditionValue = condition;
        Comparer = QueryComparer.GetComparer(comparer);
    }

    public WhereCondition(string property, string condition, EComparers comparer, ELogicalOperators logicalOperator)
    {
        Property = property;
        ConditionValue = condition;
        Comparer = QueryComparer.GetComparer(comparer);
        LogicalOperator = QueryLogicalOperators.GetLogicalOperator(logicalOperator);
    }

    public override string ToString()
    {
        return $"{Property} {Comparer} {ConditionValue} {LogicalOperator} ";
    }
}