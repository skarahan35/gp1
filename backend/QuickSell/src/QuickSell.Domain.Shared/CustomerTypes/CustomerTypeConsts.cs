

namespace QuickSell.CustomerTypes
{
    public static class CustomerTypeConsts
    {
        private const string DefaultSorting = "{0}Id asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "CustomerType." : string.Empty);
        }

    }
}