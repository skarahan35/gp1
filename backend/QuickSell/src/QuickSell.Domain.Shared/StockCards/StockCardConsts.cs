

namespace QuickSell.StockCards
{
    public static class StockCardConsts
    {
        private const string DefaultSorting = "{0}Id asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "StockCard." : string.Empty);
        }

    }
}