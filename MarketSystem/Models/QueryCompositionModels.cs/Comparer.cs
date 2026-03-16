namespace StoreSystem.Models.QueryComposition;

public static class QueryComparer
{
    private static string[] Comparers = ["=","!=","<",">",
                                        "<=",">=","LIKE",
                                        "IN"];
    public static string GetComparer (EComparers comparerType) => Comparers[(int)comparerType];
}

public enum EComparers
{
    Equal = 0,
    Different,
    LessThan,
    MoreThan,
    LessOrEqual,
    MoreOrEqual,
    Like,
    In
}