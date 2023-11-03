

namespace QuickSell.StockGroups
{
    public static class StockGroupConsts
    {
        private const string DefaultSorting = "{0}Id asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "StockGroup." : string.Empty);
        }

    }
}