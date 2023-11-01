using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace QuickSell;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(QuickSellHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class QuickSellConsoleApiClientModule : AbpModule
{

}
