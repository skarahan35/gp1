

namespace QuickSell.MovementHeaders
{
    public static class MovementHeaderConsts
    {
        private const string DefaultSorting = "{0}Id asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "MovementHeader." : string.Empty);
        }

    }
}