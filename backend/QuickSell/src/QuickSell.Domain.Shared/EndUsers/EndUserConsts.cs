

namespace QuickSell.EndUsers
{
    public static class EndUserConsts
    {
        private const string DefaultSorting = "{0}Id asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "EndUser." : string.Empty);
        }

    }
}