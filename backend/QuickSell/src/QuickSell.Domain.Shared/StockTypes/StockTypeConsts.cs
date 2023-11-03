

namespace QuickSell.StockTypes
{
    public static class StockTypeConsts
    {
        private const string DefaultSorting = "{0}Id asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "StockType." : string.Empty);
        }

    }
}