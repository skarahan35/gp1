using Volo.Abp.Reflection;

namespace QuickSell.Permissions;

public class QuickSellPermissions
{
    public const string GroupName = "QuickSell";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(QuickSellPermissions));
    }
}
