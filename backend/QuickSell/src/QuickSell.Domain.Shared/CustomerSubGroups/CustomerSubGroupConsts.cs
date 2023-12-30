

namespace QuickSell.CustomerSubGroups
{
    public static class CustomerSubGroupConsts
    {
        private const string DefaultSorting = "{0}Id asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "CustomerSubGroup." : string.Empty);
        }

    }
}