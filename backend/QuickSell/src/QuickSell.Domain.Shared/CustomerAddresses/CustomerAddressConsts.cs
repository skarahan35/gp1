

namespace QuickSell.CustomerAddresses
{
    public static class CustomerAddressConsts
    {
        private const string DefaultSorting = "{0}Id asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "CustomerAddress." : string.Empty);
        }

    }
}