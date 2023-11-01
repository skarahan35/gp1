namespace QuickSell;

public static class QuickSellDbProperties
{
    public static string DbTablePrefix { get; set; } = "QuickSell";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "QuickSell";
}
