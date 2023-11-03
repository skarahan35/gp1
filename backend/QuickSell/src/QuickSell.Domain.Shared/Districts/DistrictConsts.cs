

namespace QuickSell.Districts
{
    public static class DistrictConsts
    {
        private const string DefaultSorting = "{0}Id asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "District." : string.Empty);
        }

    }
}