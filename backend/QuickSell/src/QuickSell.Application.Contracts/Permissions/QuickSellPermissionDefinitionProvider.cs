using QuickSell.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace QuickSell.Permissions;

public class QuickSellPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(QuickSellPermissions.GroupName, L("Permission:QuickSell"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<QuickSellResource>(name);
    }
}
