

namespace QuickSell.Prefixes
{
    public static class PrefixConsts
    {
        private const string DefaultSorting = "{0}Id asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Prefix." : string.Empty);
        }

    }
}