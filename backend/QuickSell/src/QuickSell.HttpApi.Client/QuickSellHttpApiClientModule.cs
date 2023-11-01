using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace QuickSell;

[DependsOn(
    typeof(QuickSellApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class QuickSellHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(QuickSellApplicationContractsModule).Assembly,
            QuickSellRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<QuickSellHttpApiClientModule>();
        });

    }
}
