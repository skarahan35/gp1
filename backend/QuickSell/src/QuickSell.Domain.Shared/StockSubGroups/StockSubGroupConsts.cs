

namespace QuickSell.StockSubGroups
{
    public static class StockSubGroupConsts
    {
        private const string DefaultSorting = "{0}Id asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "StockSubGroup." : string.Empty);
        }

    }
}