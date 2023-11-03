using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace QuickSell;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class QuickSellInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<QuickSellInstallerModule>();
        });
    }
}
