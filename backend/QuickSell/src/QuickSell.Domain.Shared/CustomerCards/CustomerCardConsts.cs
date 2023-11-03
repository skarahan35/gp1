

namespace QuickSell.CustomerCards
{
    public static class CustomerCardConsts
    {
        private const string DefaultSorting = "{0}Id asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "CustomerCard." : string.Empty);
        }

    }
}