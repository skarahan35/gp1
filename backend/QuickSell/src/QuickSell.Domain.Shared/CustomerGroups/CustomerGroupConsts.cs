

namespace QuickSell.CustomerGroups
{
    public static class CustomerGroupConsts
    {
        private const string DefaultSorting = "{0}Id asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "CustomerGroup." : string.Empty);
        }

    }
}