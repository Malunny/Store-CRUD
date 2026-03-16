namespace StoreSystem.Models.QueryComposition;

public static class QueryLogicalOperators
{
    private static string[] _logicalOperators = ["AND", "OR"];
    public static string GetLogicalOperator (ELogicalOperators logicalOperator) 
        => _logicalOperators[(int)logicalOperator];
}

public enum ELogicalOperators
{
    And = 0,
    Or
}