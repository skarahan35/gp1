

namespace QuickSell.StockPrices
{
    public static class StockPriceConsts
    {
        private const string DefaultSorting = "{0}Id asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "StockPrice." : string.Empty);
        }

    }
}