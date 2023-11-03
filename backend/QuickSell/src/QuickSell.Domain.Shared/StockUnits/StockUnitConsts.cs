

namespace QuickSell.StockUnits
{
    public static class StockUnitConsts
    {
        private const string DefaultSorting = "{0}Id asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "StockUnit." : string.Empty);
        }

    }
}