namespace StoreSystem.Models.DataBase;

public static class Views
{
    private static string[] viewsName = ["vwClientPurchase"];
    public static string GetView(EViews view) => viewsName[((int)view)];
}