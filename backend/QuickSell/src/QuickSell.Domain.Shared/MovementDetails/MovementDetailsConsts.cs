

namespace QuickSell.MovementDetails
{
    public static class MovementDetailsConsts
    {
        private const string DefaultSorting = "{0}Id asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "MovementDetails." : string.Empty);
        }

    }
}